using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupPray : MonoBehaviour
{
    bool playerInRange;
    bool ispraying;
    public float PrayerTime;
    [SerializeField]
    float timer;
    void Start()
    {
        playerInRange = false;
        timer = 0;
        ispraying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            ispraying = true;
        }

        if(ispraying == true)
        {
            timer += Time.deltaTime;

            if(timer >= PrayerTime)
            {
                Debug.Log("PLAYERWIN GOES HERE");
            }


            if (Input.anyKey)
            {
                
            }


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


            if(ispraying == true)
            {
                Debug.Log("SOUP FAIL");
            }
        }
    }
}
