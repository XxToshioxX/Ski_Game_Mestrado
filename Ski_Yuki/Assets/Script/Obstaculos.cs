using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Obstaculos : MonoBehaviour
{
    private Player_Plat Player;

    [Header("Debuff")]
    public float DebuffSpeed;

    public void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player_Plat>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.AceleracaoFinal = DebuffSpeed;
           
        }
    }
}
