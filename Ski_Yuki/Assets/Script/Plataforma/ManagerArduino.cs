using System.Collections;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using System.Threading;
using UnityEngine.UI;

public class ManagerArduino : MonoBehaviour
{
    public static ManagerArduino instance;

    public static string ArdPortMotor = "COM24";
    public static string ArdPortSensor = "COM25";
    public bool ArdCon = false;
    SerialPort porta = new SerialPort(ArdPortMotor, 74880);
    SerialPort porta2 = new SerialPort(ArdPortSensor, 74880);

    public string XY = "y";
    public int Inicial = 0;
    //public int Max = 0;
   // public int Min = 0;
   

    //public string Y = "y";
    //public int InicialY = 0;
    //public int MaxY = 0;
    //public int MinY = 0;

    public static float S1;
    public static float S2;
    public static float S3;
    public static float S4;

    public static float S5;
    public static float S6;
    public static float S7;
    public static float S8;

    public static float X;
    public static float Y;
    public static float Z;

    public static float ZS1 = 0;
    public static float ZS2 = 0;
    public static float ZS3 = 0;
    public static float ZS4 = 0;

    public static float ZS5 = 0;
    public static float ZS6 = 0;
    public static float ZS7 = 0;
    public static float ZS8 = 0;

    public float timer = 0f;

    public bool Raw;
    public bool Ace;
    //public bool PF;

   // public GameObject BTN;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        

            DontDestroyOnLoad(gameObject);
    }

       void Update()
    {
       //Debug.Log(ZS1);
        timer += Time.deltaTime;
        if (timer > 0.3f)
        {
            if (Raw == true) ////
            {
                LerRaw();
            }

            if (Ace == true)
            {
                LerAce();
            }

            timer = 0f;

        }

        if (Input.GetKey(KeyCode.C)) //Conectar Arduino
        {
            ConectarArd();
        }
        if (Input.GetKey(KeyCode.P)) //Se apertar ESC, o arduino é desconectado, mudar para a forma mais conveniente
        {
            DesconectarArd();
        }
        if (Input.GetKey(KeyCode.S)) //Soltar Plataforma
        {
            SoltarPlat();
        }
        if (Input.GetKey(KeyCode.T)) //Prender Plataforma
        {
            PrenderPlat();
        }

        if(PlayerPrefs.GetInt("Inicio")== 1)
        {
            PlayerPrefs.SetInt("Inicio",0);
            PlayerPrefs.SetString("Plataforma", "Desconectado");
            
           Calibrar();
            
        }

    }
    public void ConectarArd() //Função que conecta o arduino
    {
        porta.Open();
        if(porta.IsOpen)
        {
          print("ArdMotor");
        }
        porta2.Open();
         if(porta2.IsOpen)
        {
          print("ArdSensor");
        }
        porta.ReadTimeout = 1000;
        porta2.ReadTimeout = 1000;
        if (porta.IsOpen && porta2.IsOpen)
        {
            ArdCon = true;
            Debug.Log("Arduino Conectado");
            porta.WriteLine("C");
            porta2.WriteLine("c");
            porta.WriteLine("X"); //x or y
            porta.WriteLine("0" + "c"); //Inclinação

            StartCoroutine("TempoCalibrarY");
            
            Calibrar();
        }

    }
    IEnumerator TempoCalibrarY()
    {
        yield return new WaitForSeconds(3);

        porta.WriteLine("Y"); //x or y
        porta.WriteLine("0" + "c"); //iNCLINAÇÃO
      
    }
    public void DesconectarArd() //Função que desconecta o arduino
    {
            porta.WriteLine("s");
            porta.Close();
            porta2.Close();
            ArdCon = false;
            Debug.Log("Arduino Desconectado");
           

    }
    public void SoltarPlat() //Soltar Plataforma
    {
        porta.WriteLine("s");
    }
    public void PrenderPlat() //Prender Plataforma
    {
        porta.WriteLine("t");
    }
    
    public void MovPlataform()
    {
        if (porta.IsOpen)
        {
            //DefineVelocidadePlataforma();
            porta.WriteLine(XY + "" + "c"); //x or y
            Debug.Log(XY + "" + "c");
            porta.WriteLine(Inicial + "" + "c"); //Ponto Inicial
            Debug.Log(Inicial + "" + "c");
            //porta.WriteLine(Max + ""); //Max
            //Debug.Log(Max + "");
            //porta.WriteLine(Min + ""); //Min
            //Debug.Log(Min + "");
            
         }
            
    }
    public void LerRaw()
    {
        if (porta2.IsOpen)
        {

            porta2.WriteLine("c");

            string value = porta2.ReadLine();

            string[] vec3 = value.Split(null);

            S1 = (float.Parse(vec3[1]));
            S2 = (float.Parse(vec3[2]));
            S3 = (float.Parse(vec3[3]));
            S4 = (float.Parse(vec3[4]));

            S5 = (float.Parse(vec3[5]));
            S6 = (float.Parse(vec3[6])); ///
            S7 = (float.Parse(vec3[7]));
            S8 = (float.Parse(vec3[8]));


        }
    }

    public void LerAce()
    {
        if (porta2.IsOpen)
        {

            porta2.WriteLine("a");

            string value = porta.ReadLine();

            string[] vec3 = value.Split(null);

            X = (float.Parse(vec3[0]));
            Y = (float.Parse(vec3[1]));

        }
    }

    public void Calibrar()
    {
        Debug.Log(S1 + "a");
        ZS1 = S1;
        ZS2 = S2;
        ZS3 = S3;
        ZS4 = S4;

        ZS5 = S5;
        ZS6 = S6;
        ZS7 = S7;
        ZS8 = S8;

        Debug.Log("Rodou");
        //BTN.SetActive(false);
       
    }
    public void DefineVelocidadePlataforma()
    {
            porta.WriteLine("V");
            porta.WriteLine("10" + "c");
    }
}

