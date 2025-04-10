using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.IO;

public class Plat_Controller : MonoBehaviour
{
    public int speed = 5;
    public float Velocidade_mov = 10.0f; //cria uma variavel float com acesso pelo unity
    public float Velocidade_rot = 10.0f;
    public float Zona_de_equilibrio = 0.0f;

    public bool Movimento_Y;
    public bool Rotacao_Y;

    public bool Movimento_X;
    public bool Rotacao_X;

    public float HorizontalAxis = 0.0f; //vai mostrar o valor da variavel no unity
    public float VerticalAxis = 0.0f; //vai mostrar o valor da variavel no unity

    public string name = @"Teste";

    private Rigidbody rb;

   


    SerialPort porta = new SerialPort(@"\\.\COM14", 74880);
    //SerialPort portaM = new SerialPort(@"\\.\COM7", 74880);
    // Start is called before the first frame update
    void Start()
    {
        porta.Open();
        porta.ReadTimeout = 1000;

        //portaM.Open();
        //portaM.ReadTimeout = 1000;

        if (porta.IsOpen)
        {
            porta.WriteLine("c");
        }

        //if (portaM.IsOpen)
        //{
        //    portaM.WriteLine("t");
        //}
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }
    void FixedUpdate()
    {

        Vector3 movement = new Vector3(HorizontalAxis, 0.0f, VerticalAxis);

        rb.AddForce(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) //Conectar Arduino
        {
            ConectarArd();
        }
        if (Input.GetButton("Cancel")) //Se apeertar ESC, o arduino � desconectado, mudar para a forma mais conveniente
        {
            DesconectarArd();
        }
        if (porta.IsOpen)
        {

            porta.WriteLine("c");

            string value = porta.ReadLine(); //Read the information

            string[] vec3 = value.Split(null);

            

            float S1 = (float.Parse(vec3[1])) - 0;
            float S2 = (float.Parse(vec3[2])) - 24;
            float S3 = (float.Parse(vec3[3])) - 86;
            float S4 = (float.Parse(vec3[4])) - 65;

            float S5 = (float.Parse(vec3[5])) - 13;
            float S6 = ((float.Parse(vec3[6])) - 134) / 10;
            float S7 = (float.Parse(vec3[7])) - 26;
            float S8 = (float.Parse(vec3[8])) - 3;

            float x = S5 + S6 + S7 + S8 - S1 - S2 - S3 - S4;

            float y = S1 + S2 + S5 + S6 - S3 - S4 - S8 - S8;

            float EquiP = Zona_de_equilibrio;

            float EquiN = Zona_de_equilibrio * -1;

            if (Movimento_X)
            {
                if (x > EquiP)
                {
                    HorizontalAxis = 1.0f;
                }

                else if (x < EquiN)
                {
                    HorizontalAxis = -1.0f;
                }
                else
                {
                    HorizontalAxis = 0.0f;
                }
            }

            if (Movimento_Y)
            {
                if (y > EquiP)
                {
                    VerticalAxis = 1.0f;

                    //icone flecha para cima
                }

                else if (y < EquiN)
                {
                    VerticalAxis = -1.0f;

                    //icone flecha para baixo
                }
                else
                {
                    VerticalAxis = 0.0f;
                }
            }

            if (Rotacao_X)
            {
                if (x > EquiP)
                {
                    HorizontalAxis = 1.0f;
                    //icone flecha para direita
                }

                else if (x < EquiN)
                {
                    HorizontalAxis = -1.0f;
                    //icone flecha para esquerda
                }
                else
                {
                    HorizontalAxis = 0.0f;
                }
            }
            if (Rotacao_Y)
            {
                if (y > EquiP)
                {
                    VerticalAxis = 1.0f;
                    //icone flecha para cima
                }

                else if (y < EquiN)
                {
                    VerticalAxis = -1.0f;
                    //icone flecha para baixo
                }
                else
                {
                    VerticalAxis = 0.0f;
                }
            }
        }
    }
    public void DesconectarArd() //Fun��o que desconecta o arduino
    {
        porta.Close();
        Debug.Log("Arduino Desconectado");

    }
    public void ConectarArd() //Fun��o que desconecta o arduino
    {
        porta.Open();
        Debug.Log("Arduino Conectado");
    }
}
