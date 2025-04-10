using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cena : MonoBehaviour
{
    public string Scene;
    public void Voltar()
    {
        SceneManager.LoadScene(Scene);
    }
}
