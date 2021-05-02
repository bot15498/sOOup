using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject target;
    private Vector2 initialPos;
    public float speed = 100.0f;
    private string movementStatus = "IDLE";
    private Animator anime;
    private bool lastClick = false;
    private bool isAnimation = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Distance to target:" + Vector2.Distance(transform.position, target.transform.position));
        initialPos = transform.position;
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool click = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0);
        // Check for user input
        if (click && lastClick != click)
        {
            //movementStatus = "TOWARDS";
            anime.SetBool("isMoving", true);
            isAnimation = true;
        }
        else if(anime.GetCurrentAnimatorStateInfo(0).IsName("moving"))
        {
            anime.SetBool("isMoving", false);
        }


        //if(movementStatus != "IDLE")
        //{
        //    updatePosition();

        //}
        lastClick = click;
    }

    void updatePosition()
    {
        


        float step = speed * Time.deltaTime;
        transform.position += new Vector3(0, step / 2, 0);
        // Are we moving towards the target and further than 1distance
        if (movementStatus=="TOWARDS" && Vector2.Distance(transform.position, target.transform.position) >= 1)
        {
            //Move towards the target
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
            anime.SetBool("isMoving", true);
            //Debug.Log(Vector2.Distance(transform.position, target.transform.position));

        }
        // Are we moving back to the initial pos and further than 1distance
        else if (movementStatus=="RETURN" && Vector2.Distance(transform.position, initialPos) >= 1)
        {
            //Move back towards home pos
            transform.position = Vector2.MoveTowards(transform.position, initialPos, step);
            anime.SetBool("isMoving", false);
            //Debug.Log(Vector2.Distance(transform.position, initialPos));
        }
        else
        {
            switch(movementStatus)
            {
                case "TOWARDS":
                    movementStatus = "RETURN";
                    break;
                case "RETURN":
                    movementStatus = "IDLE";
                    break;
            }
            anime.SetBool("isMoving", false);
        }
    }
}
