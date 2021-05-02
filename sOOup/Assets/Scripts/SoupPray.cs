using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupPray : MonoBehaviour
{
    public Player_SideScroll player;
    bool playerInRange;
    bool ispraying;
    public float PrayerTime;
    [SerializeField]
    float timer;
    private WinController wc;
    void Start()
    {
        playerInRange = false;
        timer = 0;
        ispraying = false;
        wc = FindObjectOfType<WinController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wc == null)
        {
            wc = FindObjectOfType<WinController>();
        }

        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            ispraying = true;
        }

        if(ispraying == true)
        {
            player.anim.SetBool("pray", true);
            timer += Time.deltaTime;

            if(timer >= PrayerTime)
            {
                Debug.Log("PLAYERWIN GOES HERE");
                wc.SetWin();
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
                wc.SetLose();
            }
        }
    }
}
