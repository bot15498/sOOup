using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupDrop : MonoBehaviour
{
    private Camera camera;
    public SoupCloud parent = null;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("soup is here");
        camera = GameObject.Find("Main Camera").GetComponent<Camera>() as Camera;
    }

    // Update is called once per frame
    void Update()
    {
        if(parent != null)
        {
            //this.transform.position = new Vector3(parent.transform.position.x,this.transform.position.y,0);
            float step = parent.speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(parent.target.x,0), step);
        }

        //Debug.Log(this.transform.position.y < -camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        if(this.transform.position.y < -camera.ScreenToWorldPoint(new Vector2(0,Screen.height)).y)
        {
            Destroy(this.gameObject);
        }
    }
}
