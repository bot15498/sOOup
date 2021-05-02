using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    public Sprite[] damageStates;
    public int damagePerState;
    public int health;
    private WinController wc;


    void Start()
    {
        // Set our initial variables
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = damagePerState * damageStates.Length;
        spriteRenderer.sprite = damageStates[damageStates.Length-1];
        wc = FindObjectOfType<WinController>();
    }

    void Update()
    {
        if(wc == null)
            wc = FindObjectOfType<WinController>();


        // Check for user input
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            health--;

            if (health <= 0)
            {
                // WE WON
                wc.SetWin();

            }
            else
            {
                // StartCoroutine(flash(Color.red));
            }

            // If our health has dropped below a damage threshhold
            if (health % damagePerState == damagePerState-1 && health != (damagePerState*damageStates.Length)-1)
            {
                // Go ahead and update the sprite to the next damageState
                Debug.Log("We crossed a state with health:" + health + " the new state is:" + health / damagePerState);
                spriteRenderer.sprite = damageStates[health / damagePerState];
            }
            
        }

    }

    IEnumerator flash(Color color)
    {
        //Debug.Log("Flash");
        Color currentColor = spriteRenderer.color;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = currentColor;
    }

}
