using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    public int Musica = 0;
    public bool Play = true;
    public bool Stop = false;



    public AudioClip[] Audios;

    void Start()
    {
        AudioSource audios = GetComponent<AudioSource>();
        audios.clip = Audios[Musica];

        if (Play == true)
        {
           
            audios.Play();
            Play = false;
        }

    }
    void Update()
    {

        if (Stop == true)
        {
            AudioSource audios = GetComponent<AudioSource>();
            audios.Stop();
            Stop = false;
            Play = true;
            Start();
        }

    }
   
}
