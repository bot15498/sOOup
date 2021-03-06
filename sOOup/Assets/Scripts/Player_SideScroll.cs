using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SideScroll : MonoBehaviour
{
    public float maxSpeed;
    public float JumpForce;

    public int side = 1;
    private SpriteRenderer sr;
    public Animator anim;
    private Rigidbody2D rb;
    private CollisionCheck cCheck;

    [Space]
    [Header("Booleans")]
    public bool canMove = true;
    public bool NearGround;
    public bool facingRight;
    public bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cCheck = GetComponent<CollisionCheck>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        NearGround = true;
        facingRight = true;
        isWalking = false;
    }


    // Update is called once per frame
    void Update()
    {

        //GroundedCheck OLD
        /*RaycastHit2D GroundInfo = Physics2D.Raycast(groundDetection.position, -transform.up, distance);
        Debug.DrawLine(groundDetection.position, groundDetection.position + -transform.up * distance, Color.green);*/

        if(canMove)
        {
            if (cCheck.onGround == true)
            {
                //Debug.Log("nearground");
                NearGround = true;
            }
            else if (cCheck.onGround == false)
            {
                NearGround = false;
            }

            float x = Input.GetAxisRaw("Horizontal");

            if (x > 0)
            {
                facingRight = true;
            }
            else if (x < 0)
            {
                facingRight = false;
            }

            Vector2 dir = new Vector2(x, 0);
            Walk(dir);
            if (x == 0)
            {
                isWalking = false;
            }

            if (cCheck.onGround == false)
            {
                isWalking = false;
            }
            //rb.velocity = new Vector2(x * maxSpeed, rb.velocity.y);

            if ((Input.GetKeyDown(KeyCode.W) && NearGround == true || Input.GetKeyDown(KeyCode.Space) && NearGround == true))
            {
                rb.velocity = Vector2.up * JumpForce;
                NearGround = false;
            }



            if (x != 0)
            {
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }

            flipping();
        }    
        else
        {
            Vector2 dir = new Vector2(0, 0);
            Walk(dir);
        }
    }


    private void flipping()
    {
        if(facingRight == true)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }else if (facingRight == false)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }

        // Multiply the player's x local scale by -1
        Debug.Log(transform.localScale);
    }

    
    
    void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * maxSpeed, rb.velocity.y);
    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

            transform.parent = null;

        }
    }*/
}
