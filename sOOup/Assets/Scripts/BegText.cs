using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegText : MonoBehaviour
{
    // Start is called before the first frame update

    public bool RightLaunch;
    Rigidbody2D rb2d;
    public Vector2 left;
    public Vector2 right;
    public float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (RightLaunch == false)
        {
            rb2d.AddRelativeForce(left * speed);
        } else
        {
            rb2d.AddRelativeForce(right * speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        





    }
}
