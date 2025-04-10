using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opcao : MonoBehaviour
{
    public GameObject PlataformaCheck;
    public GameObject ControleCheck;
    public GameObject TecladoCheck;
    public GameObject VRCheck;


   
    public void Start()
    {
        PlayerPrefs.SetString("Teclado", "nao");
        PlayerPrefs.SetString("Controle", "nao");
        PlayerPrefs.SetString("Plataforma", "nao");
        PlayerPrefs.SetString("VR", "nao");

        if (PlayerPrefs.GetString("Controle") == "nao")
        {
            ControleCheck.SetActive(false);
        }
        if (PlayerPrefs.GetString("Teclado") == "nao")
        {
            TecladoCheck.SetActive(false);
        }
        if (PlayerPrefs.GetString("Plataforma") == "nao")
        {
            PlataformaCheck.SetActive(false);
        }
        if (PlayerPrefs.GetString("VR") == "nao")
        {
            VRCheck.SetActive(false);
        }
    }
    private void Update()
    {
        if (PlayerPrefs.GetString("Controle") == "sim")
        {
            ControleCheck.SetActive(true);
        }
        else
        {
            ControleCheck.SetActive(false);
        }
        if (PlayerPrefs.GetString("Teclado") == "sim")
        {
            TecladoCheck.SetActive(true);
        }
        else
        {
            TecladoCheck.SetActive(false);
        }
        if (PlayerPrefs.GetString("Plataforma") == "sim")
        {
            PlataformaCheck.SetActive(true);
        }
        else
        {
            PlataformaCheck.SetActive(false);
        }
        if (PlayerPrefs.GetString("VR") == "sim")
        {
            VRCheck.SetActive(true);
        }
        else
        {
            VRCheck.SetActive(false);
        }
    }
    public void Teclado()
    {
        if (PlayerPrefs.GetString("Teclado") == "sim" )
        {
            
            PlayerPrefs.SetString("Teclado", "nao");
            PlayerPrefs.SetString("Controle", "nao");
        }
        else if( PlayerPrefs.GetString("Controle") == "nao" || PlayerPrefs.GetString("Teclado") == "nao")
        {
            PlayerPrefs.SetString("Teclado", "sim");
            PlayerPrefs.SetString("Controle", "nao");
        }
        
    }
    public void Controle()
    {
        if(PlayerPrefs.GetString("Controle") == "sim")
        {
            
            PlayerPrefs.SetString("Controle", "nao");
            PlayerPrefs.SetString("Teclado", "nao");
        }
        else if(PlayerPrefs.GetString("Teclado") == "nao" || PlayerPrefs.GetString("Controle") == "nao" )
        {
            PlayerPrefs.SetString("Controle", "sim");
            PlayerPrefs.SetString("Teclado", "nao");
        }
        
    }
    public void Plataforma()
    {
        if (PlayerPrefs.GetString("Plataforma") == "sim")
        {
           
            PlayerPrefs.SetString("Plataforma", "nao");
        }
        else
        {
            PlayerPrefs.SetString("Plataforma", "sim");
        }
    }
    public void VR()
    {
        if (PlayerPrefs.GetString("VR") == "sim")
        {
            
            PlayerPrefs.SetString("VR", "nao");
        }
        else
        {
            PlayerPrefs.SetString("VR", "sim");
        }
           
    }
}
