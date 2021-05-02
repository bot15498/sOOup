using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool playerInRange;
    

    void Start()
    {
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange == true && Input.GetKeyDown(KeyCode.E)) {
            FindObjectOfType<WinController>().SetWin();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
