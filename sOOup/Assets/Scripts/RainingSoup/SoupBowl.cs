using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoupBowl : MonoBehaviour
{
    public Camera camera;
    public float speed = 0.1f;
    public GameObject soupDrop;
    public GameObject evilDrop;
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


    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == soupDrop.tag)
        {
            Destroy(col.gameObject);
            soupCollected++;
            soupCounter.text = "Soup: " + soupCollected.ToString();
        }else if(col.gameObject.tag == evilDrop.tag)
        {
            Destroy(col.gameObject);
            soupCollected-=5;
            soupCounter.text = "Soup: " + soupCollected.ToString();
            StartCoroutine(flash(Color.red));
            StartCoroutine(Rotate(1));
        }
        
    }


    IEnumerator flash(Color color)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); 
        Color currentColor = spriteRenderer.color;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = currentColor;
    }

    IEnumerator Rotate(float duration)
    {
        Vector3 startRotation = transform.eulerAngles;
        float endRotation = startRotation.z + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation.z, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(startRotation.x, yRotation, startRotation.z);
            yield return null;
        }
    }
}
