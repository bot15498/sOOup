using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    private Camera camera;
    public float speed = 10f;
    public float boundsPad = .8f;
    public int wanderRadius = 4;

    private Vector2 wanderTarget;
    private Vector2 bounds;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>() as Camera;
        InvokeRepeating("updateTarget", Random.value * 5f, 2f);
        updateTarget();
        bounds = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //Debug.Log("Bounds:"+bounds);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,wanderTarget, step);
    }


    void updateTarget()
    {
        Vector2 unitVector = Random.insideUnitCircle * wanderRadius;
        float wanderX = transform.position.x + unitVector.x;
        float wanderY = transform.position.y + unitVector.y;
        //Debug.Log("WanderOG:" + wanderX + " " + wanderY);
        if (wanderX < 0)
        {
            // If our x is neg, make sure its at least -bounds.x
            wanderX = Mathf.Max(wanderX, -bounds.x + boundsPad);
        }else if (wanderX > 0)
        {
            // If our x is pos, make sure its less than bounds.x
            wanderX = Mathf.Min(wanderX, bounds.x - boundsPad);
        }

        if (wanderY < 0)
        {
            //If our y is neg, make sure its at least -bounds.y
            wanderY = Mathf.Max(wanderY, -bounds.y + boundsPad + 1.8f);
        }
        else if (wanderY > 0)
        {
            //If our y is pos, make sure its less than bounds.y
            wanderY = Mathf.Min(wanderY, bounds.y - boundsPad);
        }
        //Debug.Log("WanderNew:" + wanderX + " " + wanderY);

        wanderTarget = new Vector2(wanderX,wanderY);
        //Debug.Log(wanderTarget + "   " + transform.position);
    }
}
