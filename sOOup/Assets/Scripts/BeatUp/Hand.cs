using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject target;
    private Vector2 initialPos;
    public float speed = 100.0f;
    private string movementStatus = "IDLE";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Distance to target:" + Vector2.Distance(transform.position, target.transform.position));
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for user input
        if (Input.GetKeyDown("x"))
        {
            movementStatus = "TOWARDS";
        }


        if(movementStatus != "IDLE")
        {
            updatePosition();

        }
        


        
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

        }
        // Are we moving back to the initial pos and further than 1distance
        else if (movementStatus=="RETURN" && Vector2.Distance(transform.position, initialPos) >= 1)
        {
            //Move back towards home pos
            transform.position = Vector2.MoveTowards(transform.position, initialPos, step);
        }else
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
        }
    }
}
