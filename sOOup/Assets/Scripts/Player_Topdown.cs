using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Topdown : MonoBehaviour
{
    public float speed = 12f;

    Rigidbody2D playerRigidbody;

    void Awake()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        Move();


    }

    void Move()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        //Clamp Player X
        //pos.x = Mathf.Clamp(pos.x, -29.25f, -11.4f);

        playerRigidbody.velocity = new Vector2(h * speed, v * speed);
    }


}
