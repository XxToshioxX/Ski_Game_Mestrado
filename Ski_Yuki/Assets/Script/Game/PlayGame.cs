using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;

public class PlayGame : MonoBehaviour
{
    private Timer cronometer;
    private Player_Plat Player;
    private ManagerArduino Ard;
    private Audio audio;
   

    [Header("Botões")]
    public GameObject SwitchPlatBTN;
    public GameObject SwitchTecladoBTN;
    public GameObject RealidadeVirtualBTN;

    public GameObject ConectarBTN;
    public GameObject CalibrarBTN;
    public GameObject StartBTN;
    public GameObject ControleBTN;
   
    [Header("UI Interface")]
    public GameObject Timer;
    public GameObject Speedometer;
    private string Stopwatch;
    private int Erros;
    public Text ShowError;
    public GameObject EndBTN;
    public GameObject EndBTN2;

    [Header("LOG")]
    public GameObject Canvaslog;


    [Header("Cameras")]
    public GameObject CameraInicio;
    public GameObject CameraJogo;
    public GameObject CameraJogoVR;
    public bool VR = false;
    public Animator AnimatorCamera;


    [Header("Variaveis")]
    public bool Run = false;
    public bool End = false;
    public bool Tutorial = false;

    [Header("Audio Alternativo /Mari Agressora")]
    public bool MariMa = false;

    [Header("Variaveis Save")]
    public bool SaveExc = false;
    public string filename = "";
    public PlayerList myPlayerList = new PlayerList();
    

    [Header("Mudança de Tela")]
    public string Cena;
    //public GameObject CameraCalibrarVR;
    //public GameObject VoltarInicioBTN;

    [Header("InputField")]
    public GameObject mainInputField;
    public GameObject mainIutputFieldBTN;
    private bool Log = true;

    [System.Serializable]
    public class PlayerStats
    {
        public string Nome;
        public string Tempo;
        public string Colisoes;
        public string Data;
    }
    [System.Serializable]
    public class PlayerList
    {
        public PlayerStats[] player;
    }

    void Start()
    {
        PlayerPrefs.SetInt("Inicio", 0);

        cronometer = GameObject.Find("Canvas_UI_Player").GetComponent<Timer>();
        Player = GameObject.Find("Player").GetComponent<Player_Plat>();
        Ard = GameObject.Find("ManagerArd").GetComponent<ManagerArduino>();
        audio = GameObject.Find("Cenario").GetComponent<Audio>();

        if(Tutorial == false)
        {
        CameraInicio.SetActive(true);
        CameraJogo.SetActive(false);
        CameraJogoVR.SetActive(false);
        //CameraCalibrarVR.SetActive(false);
        //VoltarInicioBTN.SetActive(false);
        Timer.SetActive(false);
        Speedometer.SetActive(false);
        StartBTN.SetActive(true);
        ControleBTN.SetActive(true);
        mainInputField.SetActive(false);
        mainIutputFieldBTN.SetActive(false);
        EndBTN.SetActive(false);
        EndBTN2.SetActive(false);
        ShowError.text = "";
        ConectarBTN.SetActive(true);
        CalibrarBTN.SetActive(true);
        SwitchPlatBTN.SetActive(true);
        SwitchTecladoBTN.SetActive(true);
        //AnimatorCamera.SetBool("Play", false);

        RealidadeVirtualBTN.SetActive(true);

        Canvaslog.SetActive(false);
       
        } 
        else
        {
        CameraJogo.SetActive(false);
        CameraJogoVR.SetActive(false);
        //CameraCalibrarVR.SetActive(false);
        //VoltarInicioBTN.SetActive(false);
        Timer.SetActive(false);
        Speedometer.SetActive(false);
        StartBTN.SetActive(false);
        ControleBTN.SetActive(false);
        mainInputField.SetActive(false);
        mainIutputFieldBTN.SetActive(false);
        EndBTN.SetActive(false);
        EndBTN2.SetActive(false);
        ShowError.text = "";
        ConectarBTN.SetActive(false);
        CalibrarBTN.SetActive(false);
        SwitchPlatBTN.SetActive(false);
        SwitchTecladoBTN.SetActive(false);
        //AnimatorCamera.SetBool("Play", false);
        RealidadeVirtualBTN.SetActive(false); 

        StartCoroutine(SwitchCamera());
        Ard.DefineVelocidadePlataforma();

        Canvaslog.SetActive(false);
        }
        
    }
    private void Update()
    {
        EndGame();
        
    }
    public void Play()
    {
        StartBTN.SetActive(false);
        ControleBTN.SetActive(false);
        CalibrarBTN.SetActive(false);
        ConectarBTN.SetActive(false);
        mainInputField.SetActive(false);
        mainIutputFieldBTN.SetActive(false);
        SwitchPlatBTN.SetActive(false);
        SwitchTecladoBTN.SetActive(false);
        RealidadeVirtualBTN.SetActive(false);
       // AnimatorCamera.SetBool("Play", true);
        StartCoroutine(SwitchCamera());
        Ard.DefineVelocidadePlataforma();
      
       

    }

    IEnumerator SwitchCamera()
    {
        if(Tutorial == false)
        {
            yield return new WaitForSeconds(0); //Tempo da Anima�ao Inicio at� o come�o do jogo
        }
        else
        {
           // VR = true;
            yield return new WaitForSeconds(0); //Tempo da Anima�ao Inicio at� o come�o do jogo
        }
        CameraInicio.SetActive(false);
        if(VR == false)
        {
            CameraJogo.SetActive(true);
        }
        else
        {
            CameraJogoVR.SetActive(true);
        }
        Timer.SetActive(true);
        Speedometer.SetActive(true);
        Run = true;
        if(Tutorial == false)
        {
            audio.Musica = 2;
            audio.Stop = true;
            audio.Play = true;
        }
       
        PlayerPrefs.SetInt("Inicio", 1);

    }
    public void EndGame()
    {
        if (Run == false && End == true)
        {
            if (Tutorial == true)
            {
                PlayerPrefs.SetString("TutorialClear", "Completo");
            }
            else
            {
                PlayerPrefs.SetString("JogoClear", "Completo");
            }
            Stopwatch = cronometer.timerText.text;
            Erros = Player.Quantidade;
            Canvaslog.SetActive(true);
            PlayerPrefs.SetInt("Batidas",Erros);
            PlayerPrefs.SetString("Timer", Stopwatch);
            Speedometer.SetActive(false);
            EndBTN2.SetActive(true); //BOtao fim aparecer no final
            ShowError.text = PlayerPrefs.GetInt("Batidas", Erros).ToString();
            End = false;
            
            if(Log == true)
            {
                
                Log = false;
                CreateText();
                
            }
           
        }
    }
    public void Fim()
    {
        
        PlayerPrefs.SetString("Timer", "");
        PlayerPrefs.SetInt("Batidas", 0);
        SceneManager.LoadScene("Demo_Scene");
       
    }
    void CreateText()
    {
        if(SaveExc == false)
        {
            //Caminho do arquivo

            string path = Application.dataPath + "/Log.txt";

            //Criar se n�o existir

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Log \n\n");
            }

            //Conteudo no arquivo

            string content = "\n" + "Nome:" + " " + PlayerPrefs.GetString("Nome") + "\n" + "Tempo: " + PlayerPrefs.GetString("Timer") + "\n" + "Erros: " + " " + PlayerPrefs.GetInt("Batidas") + "\n" + "Data:"+ " " + System.DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");

            //Adicionar texto
            File.AppendAllText(path, content);
        }
        else
        {
           
            filename = Application.dataPath + "/test.csv";

            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, "test \n\n");
            }

            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Nome / Tempo Total / Colisão Ocorridas / Data");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(int i = 0; i < myPlayerList.player.Length; i++)
            {
                myPlayerList.player[i].Nome = PlayerPrefs.GetString("Nome");
                myPlayerList.player[i].Tempo = PlayerPrefs.GetString("Timer");
                myPlayerList.player[i].Colisoes = PlayerPrefs.GetInt("Batidas").ToString();
                myPlayerList.player[i].Data = System.DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss"); //Colocar Data
                tw.WriteLine(myPlayerList.player[i].Nome + "/" + myPlayerList.player[i].Tempo + "/" + myPlayerList.player[i].Colisoes + "/" + myPlayerList.player[i].Data);
               
            }
            tw.Close();
         }

    }
    public void Teclado()
    {
        Player.Plataforma = false;
        Player.Controle = false;
    }
    public void Plataforma()
    {
        Player.Plataforma = true;
        Ard.ConectarArd();

    }
    public void Controle()
    {
        Player.Controle = true;
    }
    public void RealidadeVirtual()
    {
        VR = true;
    }
    public void TelaCalibrarVR()
    {
        SceneManager.LoadScene(Cena);
        //CameraInicio.SetActive(false);
        //CameraCalibrarVR.SetActive(true);
        //VoltarInicioBTN.SetActive(true);
        //StartBTN.SetActive(false);
        //CalibrarBTN.SetActive(false);
        //ConectarBTN.SetActive(false);
        //mainInputField.SetActive(false);
        //mainIutputFieldBTN.SetActive(false);
        //SwitchPlatBTN.SetActive(false);
        //SwitchTecladoBTN.SetActive(false);
        //RealidadeVirtualBTN.SetActive(false);
    }
}
