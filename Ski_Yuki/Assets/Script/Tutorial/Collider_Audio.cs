using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Audio : MonoBehaviour
{
    private Audio audio;
    private ManagerArduino Ard;
    private Player_Plat Player;
    private PlayGame game;

    [Header("Ordem dos Colisores")]
    public int TriggerOrdem;

    [Header("Mari Agressora")]
    public bool MariMa = false;
   
    


    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("Cenario").GetComponent<Audio>();
        Ard = GameObject.Find("ManagerArd").GetComponent<ManagerArduino>();
        Player = GameObject.Find("Player").GetComponent<Player_Plat>();
        game = GameObject.Find("Game").GetComponent<PlayGame>();

        if (game.MariMa == true)
        {
            MariMa = true;
        }
        else
        {
            MariMa = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if(TriggerOrdem == 1)
        {
            if(MariMa == false)
            {
            StopPlayer();
            audio.Musica = 0;
            audio.Stop = true;
            StartCoroutine("SequenciaAudio");
            }
            else
            {
            StopPlayer();
            audio.Musica = 6;
            audio.Stop = true;
            StartCoroutine("SequenciaAudio");
        }
            
        }
        if (TriggerOrdem == 2)
        {
            if (MariMa == false)
            {
            StopPlayer();
            audio.Musica = 2;
            audio.Stop = true;
            }
            else
            {
            StopPlayer();
            audio.Musica = 8;
            audio.Stop = true;
          
            }
        }
        if (TriggerOrdem == 3)
        {
            if (MariMa == false)
            {
            StopPlayer();
            audio.Musica = 3;
            audio.Stop = true;
            }
            else
            {
            StopPlayer();
            audio.Musica = 9;
            audio.Stop = true;
          
            }
        }
        if (TriggerOrdem == 4)
        {
            if (MariMa == false)
            {
            StopPlayer();
            audio.Musica = 4;
            audio.Stop = true;
            }
            else
            {
            StopPlayer();
            audio.Musica = 10;
            audio.Stop = true;
            
            }

        }
        if (TriggerOrdem == 5)
        {
            if (MariMa == false)
            {
            StopPlayer();
            audio.Musica = 5;
            audio.Stop = true;
            }
            else
            {
            StopPlayer();
            audio.Musica = 11;
            audio.Stop = true;
          
            }

        }
        
    }

    IEnumerator SequenciaAudio()
    {
        if (TriggerOrdem == 1)
        {
            if (MariMa == false)
            {
            StopPlayer();                       
            yield return new WaitForSeconds(4);
            audio.Musica = 1;
            audio.Stop = true;
            }
            else
            {
            StopPlayer();       
            yield return new WaitForSeconds(5);
            audio.Musica = 7;
            audio.Stop = true;
            }
        }
      

    }
    public void StopPlayer()
    {
        Player.Ace = 0;
        Player.HorizontalAxis = 0;
        Player.VerticalAxis = 0;
        Ard.XY = "Y";
        Ard.Inicial = 0;
        Player.Impulso = 0;
      
    }
}
