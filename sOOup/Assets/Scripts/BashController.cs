using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashController : MonoBehaviour
{
    public GameObject victim;
    public GameObject hand;
    public Player_SideScroll player;
    [SerializeField]
    private bool canbeat = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canbeat && !victim.activeSelf)
        {
            victim.SetActive(true);
            hand.SetActive(true);
            player.canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canbeat = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canbeat = false;
    }
}
