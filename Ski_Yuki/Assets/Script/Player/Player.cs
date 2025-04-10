using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;

public class Player : MonoBehaviour
{
    public bool Plataforma = false;
    CharacterController controller;


    private Player_Plat Plat;


    Vector3 forward; //Frente/Trás Z
    Vector3 strafe; //Esquerda/Direita X
    Vector3 vertical; //Pulo Y

    Vector3 forwardP; //Frente/Trás Z
    Vector3 strafeP;

    float forwardSpeed = 6f; //Velocidade Frente/Tras
    float strafeSpeed = 6f; //Velocidade Esquerda/Direita


    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;


    void Start()
    {
        Plat = GameObject.Find("Player").GetComponent<Player_Plat>(); //Nome do Objeto tem q ser Player

        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight); //Gravidade = 
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

    }

    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical"); // W/S
        float strafeInput = Input.GetAxisRaw("Horizontal"); // A/D

        // force = input * speed * direction
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        if (Plataforma == true)
        {
            float forwardInputPlat = Plat.VerticalAxis;
            float strafeInputPlat = Plat.HorizontalAxis;

            forwardP = forwardInputPlat * forwardSpeed * transform.forward;
            strafeP = strafeInputPlat * strafeSpeed * transform.right;

        }






        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }
        if (Plataforma == true)
        {
            Vector3 finalVelocityP = forwardP + strafeP + vertical;
            controller.Move(finalVelocityP * Time.deltaTime);
        }
        else
        {
            Vector3 finalVelocity = forward + strafe + vertical;

            controller.Move(finalVelocity * Time.deltaTime);

        }



    }

}
