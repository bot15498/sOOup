using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealSoup : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GuardIsPissed;
    public float SoupEatTimer;
    float timer;
    bool playerInRange;

    void Start()
    {
        GuardIsPissed = false;
        playerInRange = false;
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("SOUP");
            GuardIsPissed = true;
        }

        if(GuardIsPissed == true)
        {
            timer += Time.deltaTime;
        }
        
        if(timer >= SoupEatTimer)
        {
            Debug.Log("PLAYER WIN");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
