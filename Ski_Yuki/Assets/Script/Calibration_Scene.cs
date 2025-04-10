using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Calibration_Scene : MonoBehaviour
{
    public string Cena;
   public void Voltar()
    {
        SceneManager.LoadScene(Cena);
    }
}
