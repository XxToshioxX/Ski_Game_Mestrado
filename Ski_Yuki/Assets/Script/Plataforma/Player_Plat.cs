using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Player_Plat : MonoBehaviour
{
    private PlayGame game;
    public bool Plataforma;
    public bool Controle;
   

    [Header("Zona Morta")]
    public float COPDZ;

    [Header("Sensores")]
    public float S1;
    public float S2;
    public float S3;
    public float S4;

    public float S5;
    public float S6;
    public float S7;
    public float S8;

    public float HorizontalAxis = 0f; //vai mostrar o valor da variavel no unity
    public float VerticalAxis = 0f; //vai mostrar o valor da variavel no unity

    private Rigidbody Rb;

    [Header("Velocidade do Jogador")]
    //Velocidade Player
    public float Velocidade;
    public float AnguloChao;
    public float AnguloMax;
    public float VelocidadeIncl;
    public float VelocidadeCOP;

    public float AceleracaoIncl;
    private float AceleracaoImp;
    
    public float VelocidadeImp;
    public float AceleracaoCOP;


 
    public float VelocidadeCOPMax;
    public float VelocidadeCOPMin;

    
    
    public float AceleracaoFinal;
    public float Ace;

    //Come�o do Jogo
    [Header("Jogo")]
    public float Impulso;
    private CharacterController controller;
    private float gravityValue = -9.81f;
    public  Vector3 playerVelocity;
    public bool ComecoJogo = false; // Passou do primeiro collider

    [Range(0.05f,1)]
    public float AceleracaoAdicional = 0.05f;
   
    [Header("Debuff")]
    public float DebuffSpeed;
    public int Quantidade;

    //
    private HapticController hapitcControl;

    private void Awake()
    {
        if(PlayerPrefs.GetString("Plataforma") == "Conectado")
        {
            PlayerPrefs.SetInt("Inicio",1);
            Plataforma = true;
        }
      
    }
    void Start()
    {
       
        game = GameObject.Find("Game").GetComponent<PlayGame>();
        controller = gameObject.GetComponent<CharacterController>();
        hapitcControl = GameObject.Find("HapticControll").GetComponent<HapticController>();
        //SetOpcao(); //Configuração da tela de opçao

    }
    void Update()
    {
        
        Rb = GetComponent<Rigidbody>();
       
            AceleracaoIncl = (AnguloChao / AnguloMax) * VelocidadeIncl;
            AceleracaoImp = Impulso * VelocidadeImp;
            AceleracaoCOP = VerticalAxis * VelocidadeCOP;
            AceleracaoFinal = (AceleracaoIncl + AceleracaoImp) * AceleracaoCOP;

        


        if (Ace < AceleracaoFinal)
        {
            Ace += AceleracaoAdicional ;
        }
        if(Ace > AceleracaoFinal)
        {
            Ace -= AceleracaoAdicional ;
        }
        if (Controle == true && game.Run ==true) //Game.Run testar controle
        {
            
            Vector3 move = new Vector3(HorizontalAxis * Velocidade * Time.deltaTime, 0f, Ace * Velocidade * Time.deltaTime); ;
            controller.Move(move);  
            gameObject.transform.position = move;
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && game.Run == true)
        //{
        //    Impulso = 10;
        //    StartCoroutine("Dash");
        //}
        if(Plataforma == true && game.Run == true)
        {
            ControleCOP();
            Vector3 move = new Vector3(HorizontalAxis * Velocidade * Time.deltaTime, 0f, Ace * Velocidade * Time.deltaTime);
            controller.Move(move);
            gameObject.transform.position = move;
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
            PlayerPrefs.SetString("Plataforma", "Conectado");
        }
        else if(Plataforma == false && game.Run == true && Controle == false)
        {
            ControleTeclado();
            Vector3 move = new Vector3(HorizontalAxis * Velocidade * Time.deltaTime, 0f, Ace * Velocidade * Time.deltaTime);
            controller.Move(move);
            gameObject.transform.position = move;
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
            PlayerPrefs.SetString("Plataforma", "Desconectado");
        }
           
       
        //Vector3 move = new Vector3(HorizontalAxis * Velocidade * Time.deltaTime,0f, Ace * Velocidade * Time.deltaTime);
        //controller.Move(move);
        //gameObject.transform.forward = move;
        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }
    IEnumerator Dash()
    {
        yield return new WaitForSeconds(5);
        Impulso = 0;
       
    }
    public void OnMovementChange(InputAction.CallbackContext context) //
    {
        Vector2 direction = context.ReadValue<Vector2>();
       
       
        if(direction.y > 0)
        {
            VerticalAxisPos();
        }
        else if (direction.y < 0)
        {
            VerticalAxisNeg();
        }
        else
        {
            VerticalAxisZer();
        }
        if (direction.x > 0 && ComecoJogo == true)
        {
            HorizontalAxis = 1;
            HorizontalAxisPos();
        }
        else if (direction.x < 0 && ComecoJogo == true)
        {
            HorizontalAxis = -1;
            HorizontalAxisNeg();
        }
        else
        {
            HorizontalAxisZer();
        }
        //moveVector = new Vector3(direction.x * Velocidade * Time.deltaTime, 0, Ace * Velocidade * Time.deltaTime);
        // new Vector3(moveVector * Velocidade * Time.deltaTime, 0f, Ace * Velocidade * Time.deltaTime);
    }
    void ControleTeclado()
    {
        if (Input.GetKey("w"))
        {           
            VerticalAxisPos();
        }
        else if (Input.GetKey("x"))
        {           
            VerticalAxisNeg();
        }
        else
        {
            VerticalAxisZer();
        }
        
        if (Input.GetKey("d") && ComecoJogo == true)
        {
            HorizontalAxis = 1;
            HorizontalAxisPos();
        }
        else if (Input.GetKey("a") && ComecoJogo == true)
        {
           HorizontalAxis = -1;
            HorizontalAxisNeg();
        }
        else
        {
            
            HorizontalAxisZer();
        }
    }
    void ControleCOP()
    {
        S1 = ManagerArduino.S1 - ManagerArduino.ZS1;
        S2 = ManagerArduino.S2 - ManagerArduino.ZS2;
        S3 = ManagerArduino.S3 - ManagerArduino.ZS3;
        S4 = ManagerArduino.S4 - ManagerArduino.ZS4;

        S5 = ManagerArduino.S5 - ManagerArduino.ZS5;
        S6 = ManagerArduino.S6 - ManagerArduino.ZS6;
        S7 = ManagerArduino.S7 - ManagerArduino.ZS7;
        S8 = ManagerArduino.S8 - ManagerArduino.ZS8;
        
        //if(S1 <0)
        //{
        //    S1=0;
        //}
        // if(S2 <0)
        //{
        //    S2=0;
        //}
        // if(S3 <0)
        //{
        //    S3=0;
        //}
        // if(S4 <0)
        //{
        //    S4=0;
        //}
        // if(S5 <0)
        //{
        //    S5=0;
        //}
        // if(S6 <0)
        //{
        //    S6=0;
        //}
        // if(S7 <0)
        //{
        //    S7=0;
        //}
        // if(S8 <0)
        //{
        //    S8=0;
        //}
        if ((S5 + S6 + S7 + S8) - (S1 + S2 + S3 + S4) > COPDZ && ComecoJogo == true)
        {
            HorizontalAxisPos();
        }
        else if ((S5 + S6 + S7 + S8) - (S1 + S2 + S3 + S4) < COPDZ * -1 && ComecoJogo == true)
        {
            HorizontalAxisNeg();
        }
        else
        {
            HorizontalAxisZer();
        }


        if ((S1 + S2 + S5 + S6) - (S3 + S4 + S7 + S8) > COPDZ)
        {
            VerticalAxisPos();
        }
        else if ((S1 + S2 + S5 + S6) - (S3 + S4 + S7 + S8) < COPDZ * -1)
        {
            VerticalAxisNeg();
        }
        else
        {
            VerticalAxisZer();
        }
    }

    void HorizontalAxisPos() //Direita
    {
        if (HorizontalAxis < 0)
        {
            HorizontalAxis = 0;
        }

       HorizontalAxis += AceleracaoAdicional; //* Time.deltaTime;

        if (HorizontalAxis >= 1f)
        {
            HorizontalAxis = VerticalAxis * 3;
        }

    }

    void HorizontalAxisNeg() //Esquerda
    {
        if (HorizontalAxis > 0)
        {
            HorizontalAxis = 0;
        }

       HorizontalAxis -= AceleracaoAdicional ;//* Time.deltaTime;

        if (HorizontalAxis <= -1f)
        {
            HorizontalAxis = -VerticalAxis *3;
        }

    }

    void HorizontalAxisZer() //Parado
    {
        if (HorizontalAxis > 0)
        {
            HorizontalAxis -= 0.05f;
        }

        if (HorizontalAxis < 0)
        {
            HorizontalAxis += 0.05f;
        }

    }

    void VerticalAxisPos() //Frente
    {
        if(ComecoJogo == false)
        {
            Impulso = 10;
            StartCoroutine("Dash");
        }   
        if (VerticalAxis < VelocidadeCOPMin)
        {
            VerticalAxis = VelocidadeCOPMin;
        }

        VerticalAxis += AceleracaoAdicional * Time.deltaTime;

        if (VerticalAxis >   VelocidadeCOPMax)
        {
            VerticalAxis = VelocidadeCOPMax;
        }

    }

    void VerticalAxisNeg() //Tras
    {
        if (VerticalAxis > VelocidadeCOPMax)
        {
            VerticalAxis = VelocidadeCOPMax ;
        }

        VerticalAxis -= AceleracaoAdicional * Time.deltaTime;

        if (VerticalAxis < VelocidadeCOPMin)
        {
            VerticalAxis = VelocidadeCOPMin;
        }

    }

    void VerticalAxisZer() //Parado
    {
        if (VerticalAxis > (VelocidadeCOPMax+VelocidadeCOPMin)/2)
        {
            VerticalAxis -= AceleracaoAdicional * Time.deltaTime;
        }

        if (VerticalAxis < (VelocidadeCOPMax + VelocidadeCOPMin) / 2)
        {
            VerticalAxis += AceleracaoAdicional * Time.deltaTime;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Obstaculo")
        {
            
            VerticalAxis -= 2;
            if(VerticalAxis < 0)
            {
                VerticalAxis = 0;
            }
            
            Ace = Ace - DebuffSpeed;
            AceleracaoFinal = Ace;
            Quantidade++;
            Destroy(other.gameObject);
            hapitcControl.SendHaptics();
        }

    }
   //public void SetOpcao()
   //{
   //     if (PlayerPrefs.GetString("Controle") == "sim")
   //     {
   //         PlayerPrefs.SetString("Teclado","nao");
   //         Controle = true;
   //     }
   //     else if(PlayerPrefs.GetString("Controle") == "nao")
   //     {
   //         Controle = false;
   //     }
   //     else if (PlayerPrefs.GetString("Teclado") == "sim")
   //     {
   //         PlayerPrefs.SetString("Plataforma","nao");
   //         PlayerPrefs.SetString("Controle","nao");
   //         Plataforma = false;
   //         Controle = false;
   //     }
        

   //     if (PlayerPrefs.GetString("Plataforma") == "sim")
   //     {
   //         PlayerPrefs.SetString("Teclado","nao");
   //         Plataforma = true;
   //     }
   //     else if(PlayerPrefs.GetString("Plataforma") == "nao")
   //     {           
   //         Plataforma = false;
   //     }

   //     if (PlayerPrefs.GetString("VR") == "sim")
   //     {
   //         game.VR = true;
   //     }
   //     else if(PlayerPrefs.GetString("VR") == "nao")
   //     {
   //         game.VR = false;
   //     }
        
   //}

}

