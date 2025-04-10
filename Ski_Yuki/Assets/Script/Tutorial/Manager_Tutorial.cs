using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Tutorial : MonoBehaviour
{
    private Audio audio;

    [Header("Ordem dos Colisores")]
    public int TriggerOrdem;

    [Header("Quantidade de Pistas")]
    public int Count = 0;

    [Header("Delay entre Audios")]
    public float Time;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("Cenario").GetComponent<Audio>();

        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(TriggerOrdem == 1)
        {
            audio.Musica = 0;
            audio.Stop = true;
        }
        else if (TriggerOrdem == 2)
        {
            audio.Musica = 1;
            audio.Stop = true;
        }
        else if (TriggerOrdem == 3)
        {
            audio.Musica = 2;
            audio.Stop = true;
        }
        else if (TriggerOrdem == 4)
        {
            audio.Musica = 3;
            audio.Stop = true;
        }
    }

    IEnumerator Motivation()
    {
        yield return new WaitForSeconds(Time);

    }
}
