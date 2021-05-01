using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    public Sprite[] damageStates;
    public int damagePerState;
    private int health;

    void Start()
    {
        // Set our initial variables
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = damagePerState * damageStates.Length;
        spriteRenderer.sprite = damageStates[damageStates.Length-1];
    }

    void Update()
    {
        // Check for user input
        if(Input.GetKeyDown("x"))
        {
            health--;

            if (health <= 0)
            {
                Debug.Log("I AM VERY MUCH DEAD");
                spriteRenderer.color = Color.black;

            }
            else
            {
                StartCoroutine(flash(Color.red));
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
