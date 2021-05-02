using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    public Camera camera;
    public Wander chef;
    public Wander dude;
    public Text scoreDisplay;
    private WinController wc;
    public AudioSource AS2;

    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private int score = 0;
    AudioSource AS;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreDisplay.text = score + "pts";
        wc = FindObjectOfType<WinController>();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wc == null)
            wc = FindObjectOfType<WinController>();

        // update our position to the mouse point
        Vector2 cameraPos = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cameraPos.x, cameraPos.y, 0);


        // Logic to shoot when we click
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            AS.Play();
            killAll(targetsInSight);
            StartCoroutine(flash(new Color[] { Color.yellow,Color.red}));
            
            
        }
        
        if(score <= -2)
        {
            wc.SetLose();
        }else if(score >= 90)
        {
            AS2.Play();
            wc.SetWin();
        }
    }






    // Logic for flashing the crosshair
    private bool flashing = false;
    IEnumerator flash(Color color)
    {
        if (flashing)
            yield break;
        flashing = true;
        Color currentColor = spriteRenderer.color;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = currentColor;
        flashing = false;
    }

    IEnumerator flash(Color[] color)
    {
        if (flashing)
            yield break;
        flashing = true;
        Color currentColor = spriteRenderer.color;
        for(int i=0;i<color.Length;i++)
        {
        spriteRenderer.color = color[i];
        yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.color = currentColor;
        flashing = false;
    }

    private List<GameObject> targetsInSight = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == chef.tag || col.gameObject.tag == dude.tag)
        {
            targetsInSight.Add(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == chef.tag || col.gameObject.tag == dude.tag)
        {
            targetsInSight.Remove(col.gameObject);
        }
    }

    private void killAll(List<GameObject> objs)
    {
        for(int i=0;i<objs.Count;i++)
        {
            GameObject t = objs[i];
            if (t.tag == chef.tag)
            {
                Debug.Log("Shot the chef");
                Destroy(t.gameObject);
                score += 500;
            }else if (t.tag == dude.tag)
            {
                Debug.Log("shot the dude");
                Destroy(t.gameObject);
                score--;
            }
        }
        if(Mathf.Abs(score) == 1)
        {
            scoreDisplay.text = score + "pt";
        }
        else
        {
            scoreDisplay.text = score + "pts";
        }
    }

}
