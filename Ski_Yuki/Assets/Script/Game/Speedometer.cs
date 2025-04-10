using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Text SpeedText;

    private Player_Plat Player;

    private int Speed;
    public void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player_Plat>();
        PlayerPrefs.SetFloat("VelocidadeMax", 0);
    }
    public void Update()
    {
        Speed = Mathf.FloorToInt(Player.Ace);
        SpeedText.text = Speed.ToString();
        if(Speed >= PlayerPrefs.GetFloat("VelocidadeMax"))
        {
            PlayerPrefs.SetFloat("VelocidadeMax", Speed);
        }
    }
}
