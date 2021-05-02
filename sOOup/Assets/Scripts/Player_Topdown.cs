using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Topdown : MonoBehaviour
{
    public float speed = 12f;

    Rigidbody2D playerRigidbody;
    Animator anim;

    void Awake()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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



        if (h != 0 || v != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Die
        }
    }


}
