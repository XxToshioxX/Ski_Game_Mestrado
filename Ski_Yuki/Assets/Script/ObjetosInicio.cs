using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosInicio : MonoBehaviour
{
    public GameObject TrofeuTutorial;
    public GameObject TrofeuJogo;

    public int count = 0;
   
    void Start()
    {
        if (PlayerPrefs.GetString("JogoClear") == "Completo" && PlayerPrefs.GetString("TutorialClear") == "Completo" && count > 2)
        {
            ResetVar();
        }
        if (PlayerPrefs.GetString("TutorialClear") == "Completo")
        {
            TrofeuTutorial.SetActive(true);
            if (PlayerPrefs.GetString("JogoClear") == "Completo")
            {
                count++;
            }
            else
            {
                count = 1;
            }
            
        }
        else
        {
            
                TrofeuTutorial.SetActive(false);
            
                
        }
        if(PlayerPrefs.GetString("JogoClear") == "Completo")
        {
            TrofeuJogo.SetActive(true);
           
            if(PlayerPrefs.GetString("TutorialClear") == "Completo")
            {
                count++;
            }
            else
            {
                count = 1;
            }
            
        }
        else
        {
           
                TrofeuJogo.SetActive(false);
            
            
        }
      
    }

    public void ResetVar()
    {
        PlayerPrefs.SetString("JogoClear", "");
        PlayerPrefs.SetString("TutorialClear", "");
        count = 0;
    }
}
