using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationLevel : MonoBehaviour
{
    private Player_Plat Player;
    
    [Header("Prefabs parte da pista")]
    public GameObject[] Section;
    public GameObject SectionEnd;
    public GameObject Colliders;
    //public GameObject Cenario;
    public Vector3 CenarioPos;
    
    [Range(5, 1000)]
    public int CollidersFrequencia;
    private int ColliderSpawn;
    [Header("Posição inicial do Spawn da Pista")]
    public float xPos = 0;
    public float yPos = 0;
    public float zPos = 0;
    public float YPosEnd = 0;
    private bool creatingSection = false;
    private int RandomSize;
    private int secNum;
    [Header("Rotação da Pista")]
    public float xRot; //8.5f
    public float yRot; //0
    public float zRot; //0
    
    [Header("Distancias entre um spaw e outro / Quantidade Max de Spawns")]
    public float secSizeZ;
    public int Quantidade;
    private int loop;
    private bool stop = false;

    private bool FirstSpawn = true;
    private float VariacaoX = 0;
    private float VariacaoY = 0;
    
    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player_Plat>();
      
        RandomSize = Mathf.Max(Section.Length);
       
    }
    void Update()
    {

        //CenarioPos = transform.position;
        //CenarioPos += new Vector3(xPos - 455.5f, yPos + 2, zPos - 300);
        //Cenario.transform.position = CenarioPos;
        if (creatingSection == false && stop == false)
        {
            creatingSection = true;
            StartCoroutine(GenerationSection());
        }
    }

    IEnumerator GenerationSection()
    {
        Quaternion myRotationInicio = Quaternion.identity; //Rotação Primeira Parte Pista
        myRotationInicio.eulerAngles = new Vector3(4.5f, 0, 0);


        secNum = Random.Range(0, RandomSize);

        if (loop == ColliderSpawn && stop == false)
        {
            Instantiate(Colliders, new Vector3(xPos, yPos, zPos), myRotationInicio);
            ColliderSpawn += CollidersFrequencia;

        }

        else if (loop == 0) //Primeira Parte Pista
        {
            //altura após a pista spawnada
            Instantiate(Section[secNum], new Vector3(xPos, yPos - 0.5f, zPos), myRotationInicio);
            zPos += secSizeZ;
            yPos -= 1f;
        }
        else //Demais Parte da Pista
        {
            SpawnInclinacao();
        }

        yield return new WaitForSeconds(0.01666666666666666666666666666667f); // 1 segundo dividido por 60 frames
        loop++;
        creatingSection = false;
        if (loop >= Quantidade) //Spawn da Ultima Parte da Pista
        {

            Quaternion myRotationEnd = Quaternion.identity;  //Rotação das demais Partes Pistas
            myRotationEnd.eulerAngles = new Vector3(xRot, yRot, zRot);
            if (FirstSpawn == true)
            {
                PlayerPrefs.SetFloat("Inclinacao",0);
                xRot = 0;
                yRot = 0;
                zRot = 0;
                              
                Instantiate(SectionEnd, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                YPosEnd += yPos;
               
                stop = true;

            }


        }
    }
    public void SpawnInclinacao()
    {
        Quaternion myRotation = Quaternion.identity;  //Rotação das demais Partes Pistas
        myRotation.eulerAngles = new Vector3(xRot, yRot, zRot);
       
        if (1 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if(FirstSpawn == true)
            {
                xRot = 5.5f;
                yRot = 0;
                zRot = 0;

                

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();


                //xPos -= 1;
            }
          
        }
        else if (2 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 10.5f;
                yRot = 0;
                zRot = 0;

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();
                //xPos -= 0;
                //yPos -= 1f;
                //zPos -= 1;

            }
           
        }
        else if (3 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 15.5f;
                yRot = 0;
                zRot = 0;

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();
                //xPos -= 0;
                //yPos -= 0.1f;
                //zPos -= 0;

            }
           
        }
        else if (4 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 20.5f;
                yRot = 0;
                zRot = 0;

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();
                //xPos -= 0;
                //yPos -= 0.1f;
                //zPos -= 1;

            }
         
        }
        else if (5 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 25.5f;
                yRot = 0;
                zRot = 0;

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();
                //xPos -= 0;
                //yPos -= 0.9f;
                //zPos -= 0.4f;

            }
           
        }
        else if (6 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 30.5f;
                yRot = 0;
                zRot = 0;

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();
                //xPos -= 0;
                //yPos -= 1.4f;
                //zPos -= 1;

            }
          
        }
        else if (7 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 35.5f;
                yRot = 0;
                zRot = 0;

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();
                //xPos -= 0;
                //yPos -= 1.9f;
                //zPos -= 2;

            }
          
        }
        else if (8 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 40.5f;
                yRot = 0;
                zRot = 0;

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();
                //xPos -= 0;
                //yPos -= 3;
                //zPos -= 1;

            }
          
        }
        else if (9 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 45.5f;
                yRot = 0;
                zRot = 0;

                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
                AjustePista();
                //xPos -= 0;
                //yPos -= 3.2f;
                //zPos -= 2;

            }
           
        }
        else if (10 == PlayerPrefs.GetFloat("Inclinacao"))
        {
            if (FirstSpawn == true)
            {
                xRot = 50.5f;
                yRot = 0;
                zRot = 0;
                Instantiate(Section[secNum], new Vector3(xPos, yPos, zPos), myRotation);
               
                //xPos -= 0;
                //yPos -= 0;
                //zPos -= 0;

            }
          
        }
    }

    public void AjustePista()
    {
        zPos -= ((13.5132f - Mathf.Cos((xRot * Mathf.PI) / 180) * 13.5132f) / 2) + VariacaoX;
        yPos -= ((Mathf.Sin((xRot * Mathf.PI) / 180) * 13.5132f) / 2) + VariacaoY ;
        zPos += secSizeZ;

        VariacaoX = (13.5132f - Mathf.Cos((xRot * Mathf.PI) / 180) * 13.5132f) / 2;
        VariacaoY = (Mathf.Sin((xRot * Mathf.PI) / 180) * 13.5132f) / 2;
     
    }
    public void SwitchBool()
    {
        FirstSpawn = false;
    }
     
}
