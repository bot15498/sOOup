using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoupBowl : MonoBehaviour
{
    public Camera camera;
    public float speed = 0.1f;
    public GameObject soupDrop;
    public Text soupCounter;
    private int soupCollected = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        //transform.position = Vector2.Lerp(transform.position, camera.ScreenToWorldPoint(Input.mousePosition), speed*Time.deltaTime);
        Vector2 cameraPos = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cameraPos.x,cameraPos.y,0);

    }


    // called when the cube hits the floor
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == soupDrop.tag)
        {
            Debug.Log("OnCollisionEnter2D");
            Destroy(col.gameObject);
            soupCollected++;
            soupCounter.text = "Soup: " + soupCollected.ToString();
        }
        
    }
}
