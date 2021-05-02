using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTinter : MonoBehaviour
{
    public GameObject phone;
    public GameObject player;
    public GameObject buttonprompt;
    private bool canOpenPhone = false;
    void Start()
    {
        buttonprompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenPhone)
        {
            phone.SetActive(true);
            player.GetComponent<Player_SideScroll>().canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canOpenPhone = true;
        buttonprompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canOpenPhone = false;
        buttonprompt.SetActive(false);
    }
}
