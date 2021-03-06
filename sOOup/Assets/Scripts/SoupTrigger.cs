using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool playerInRange;
    public GameObject buttonprompt;
    AudioSource AS;

    void Start()
    {
        playerInRange = false;
        buttonprompt.SetActive(false);
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange == true && Input.GetKeyDown(KeyCode.E)) {
            AS.Play();

            FindObjectOfType<WinController>().SetWin();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            buttonprompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            buttonprompt.SetActive(false);
            playerInRange = false;
        }
    }
}
