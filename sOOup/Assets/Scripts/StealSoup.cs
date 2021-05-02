using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealSoup : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GuardIsPissed;
    public float SoupEatTimer;
    float timer;
    bool playerInRange;
    public Text timerText;
    SpriteRenderer sr;
    public GameObject pivot;
    AudioSource AS;

    void Start()
    {
        GuardIsPissed = false;
        playerInRange = false;
        timer = SoupEatTimer;
        timerText.enabled = false;
        sr = GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("SOUP");
            GuardIsPissed = true;
            timerText.enabled = true;
        }

        if(GuardIsPissed == true)
        {
            timer -= Time.deltaTime;
            timerText.text = "EVADE GUARD:" + timer.ToString("F2");
            pivot.SetActive(false);
        }
        
        if(timer <= 0)
        {
            AS.Play();
            Debug.Log("PLAYER WIN");
            FindObjectOfType<WinController>().SetWin();
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
