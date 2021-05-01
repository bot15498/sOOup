using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinderThrowaway : MonoBehaviour
{
    public float force = 3f;
    public SpriteRenderer renderer;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    void Update()
    {
        
    }

    public void SendFlying(bool sendLeft)
    {
        rb2d.gravityScale = 5f;
        if(sendLeft)
        {
            rb2d.AddForce(new Vector2(-1f,0f) * force);
        }
        else
        {
            rb2d.AddForce(new Vector2(1f, 0f) * force);
        }
    }
}
