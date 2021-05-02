using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTinter : MonoBehaviour
{
    public GameObject phone;
    public GameObject player;
    private bool canOpenPhone = false;
    void Start()
    {
        
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canOpenPhone = false;
    }
}
