using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // update our position to the mouse point
        Vector2 cameraPos = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cameraPos.x, cameraPos.y, 0);


        // Logic to shoot when we click
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(flash(new Color[] { Color.yellow,Color.red}));
            
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
}
