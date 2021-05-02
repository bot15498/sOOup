using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupPray : MonoBehaviour
{
    public Player_SideScroll player;
    bool playerInRange;
    bool ispraying;
    public float PrayerTime;
    public GameObject buttonprompoty;
    [SerializeField]
    float timer;
    private WinController wc;
    private Animator anime;
    AudioSource AS;
    void Start()
    {
        playerInRange = false;
        timer = 0;
        ispraying = false;
        wc = FindObjectOfType<WinController>();
        AS = GetComponent<AudioSource>();
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
            AS.Play();
        }

        if(ispraying == true)
        {
            
            player.anim.SetBool("pray", true);
            player.GetComponent<Player_SideScroll>().enabled = false;
            timer += Time.deltaTime;
            anime = GetComponent<Animator>();
            anime.SetBool("startPraying", true);


            if (timer >= PrayerTime)
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
            buttonprompoty.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
            buttonprompoty.SetActive(false);

            if (ispraying == true)
            {
                Debug.Log("SOUP FAIL");
                //wc.SetLose();
            }
        }
    }
}
