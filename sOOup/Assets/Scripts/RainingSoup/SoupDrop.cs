using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupDrop : MonoBehaviour
{
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("soup is here");
        camera = GameObject.Find("Main Camera").GetComponent<Camera>() as Camera;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.position.y < -camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        if(this.transform.position.y < -camera.ScreenToWorldPoint(new Vector2(0,Screen.height)).y)
        {
            Destroy(this.gameObject);
        }
    }
}
