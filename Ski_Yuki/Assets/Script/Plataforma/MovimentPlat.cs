using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlat : MonoBehaviour
{
    private ManagerArduino Ard;
    private Player_Plat Player;
    private Audio audio;
    private PlayGame game;
    private Timer timer;
   


    [Header("Inicio/Fim")]
    public bool Comeco = false;
    public bool Fim = false;
    [Header("Plataforma Inclina��o")]
    public bool X = false;
    public bool Y = false;
    private string XY = "x";
    [Range(0, 20)]
    public int Inicial = 0;
    [Range(0, 20)]
    public int Max = 0;
    [Range (0, 20)]
    public int Min = 0;
    [Range (0,20)]
    //public int VelocidadePlataforma = 5;  // Plataforma comando 'V"
    [Header("2�Inclina��o")]
    public bool Inclinacao2 = false;
    private string XY2 = "x";
    [Range(0, 20)]
    public int Inicial2 = 0;
    [Range(0, 20)]
    public int Max2 = 0;
    [Range(0, 20)]
    public int Min2 = 0;
    
   

    [Header("Velocidade do Personagem em rela��o a Inclina��o")]
    [Range(0, 1000)]
    public float Inclinacao;
    public float Inc0 = 0;
    public float Inc1 = 10;
    public float Inc2 = 20;
    public float Inc3 = 30;
    public float Inc4 = 40;
    public float Inc5 = 50;
    public float Inc6 = 60;
    public float Inc7 = 70;
    public float Inc8 = 80;
    public float Inc9 = 90;
    public float Inc10 = 100;

    public bool Zero = false;
    //public string Y = "y";
    //public int InicialY = 0;
    //public int MaxY = 0;
    //public int MinY = 0;
    [Header("Collider que ser� Atuado")]
   // public GameObject collider;

    public int RandomplatIncl;

    void Start()
    {
       
        Ard = GameObject.Find("ManagerArd").GetComponent<ManagerArduino>();
        Player = GameObject.Find("Player").GetComponent<Player_Plat>();
        timer = GameObject.Find("Canvas_UI_Player").GetComponent<Timer>();
        audio = GameObject.Find("Cenario").GetComponent<Audio>();
        game = GameObject.Find("Game").GetComponent<PlayGame>();
       
        RandomplatIncl = Random.Range(1, 10); //Inclina��o Aleatoria da Plataforma de 1 h� 10 graus
        if (Comeco == false && Fim == false && game.Tutorial == false)
        {
            InclinacaoSpeed();
            Inicial = RandomplatIncl;
            Max = Inicial;
            Min = Inicial;

        }

    }
    private void Update()
    {
        if(X == true)
        {
            XY = "X";
            XY2 = "Y";
        }
        else if(Y == true)
        {
            XY= "Y";
            XY2 = "X";
        }
      

    }

    public void OnTriggerEnter(Collider other)
    {
       
        //X
        Ard.XY = XY;
        Ard.Inicial = Inicial;
        //Ard.Max = Max;
        //Ard.Min = Min;
        Player.AnguloChao = Inclinacao;
       
        if(Inclinacao2 == true)
        {
            StartCoroutine("TempoCalibrarY");
           
        }
        //Y
        //Ard.Y = Y;
        //Ard.InicialY = InicialY;
        //Ard.MaxY = MaxY;
        //Ard.MinY = MinY;
        Ard.MovPlataform();
        if (Comeco == true)
        {
            if(game.Tutorial == false)
            {
                audio.Musica = 1;
                audio.Stop = true;
            }
            
            timer.TimerStart = true;
            audio.Play = true;
            Player.ComecoJogo = true;
        }
        if (Fim == true)
        {
           if (game.Tutorial == false)
            {
                audio.Musica = 2;
                audio.Stop = true;
            }
            Player.ComecoJogo = false;
            timer.TimerStart = false;
            Player.Ace = 0;
            Player.HorizontalAxis = 0;
            Player.VerticalAxis = 0;
            game.Run = false;
            game.End = true;
        }
        
       // collider.SetActive(false);
    }
    IEnumerator TempoDalayInclinacao()
    {
        yield return new WaitForSeconds(3);
        Ard.XY = XY2;
        Ard.Inicial = Inicial2;
        //Ard.Max = Max2;
        //Ard.Min = Min2;
        Player.AnguloChao = Inclinacao;
    }
    public void InclinacaoSpeed()
    {
        
            PlayerPrefs.SetFloat("Inclinacao", RandomplatIncl);
       
        if (PlayerPrefs.GetFloat("Inclinacao") ==0)
        {
            //0
           
            Inclinacao = Inc0;
        }
        else if (RandomplatIncl == 1)
        {
            //5.5
         
            Inclinacao = Inc1;
        }
        else if (RandomplatIncl == 2)
        {
            //10.5
           
            Inclinacao = Inc2;
        }
        else if (RandomplatIncl == 3)
        {
            //15.5
         
            Inclinacao = Inc3;
        }
        else if (RandomplatIncl == 4)
        {
            //20.5
        
            Inclinacao = Inc4;
        }
        else if (RandomplatIncl == 5)
        {
            //25.5
          
            Inclinacao = Inc5;
        }
        else if (RandomplatIncl == 6)
        {
            //30.5
           
            Inclinacao = Inc6;
        }
        else if (RandomplatIncl == 7)
        {
            //35.5
          
            Inclinacao = Inc7;
        }
        else if (RandomplatIncl == 8)
        {
            //40.5
          
            Inclinacao = Inc8;
        }
        else if (RandomplatIncl == 9)
        {
            //45.5
      
            Inclinacao = Inc9;
        }
        else if (RandomplatIncl == 10)
        {
            //50.5
           
            Inclinacao = Inc10;
        }

    }

}
