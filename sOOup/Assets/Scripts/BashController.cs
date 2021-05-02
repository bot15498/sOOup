using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashController : MonoBehaviour
{
    public GameObject victim;
    public GameObject victimbg;
    public GameObject hand;
    public GameObject prompt2;
    public GameObject buttonPrompt;
    public Player_SideScroll player;
    [SerializeField]
    private bool canbeat = false;

    void Start()
    {
        buttonPrompt.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canbeat && !victim.activeSelf)
        {
            victim.SetActive(true);
            victimbg.SetActive(true);
            prompt2.SetActive(true);
            hand.SetActive(true);
            player.canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canbeat = true;
        buttonPrompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canbeat = false;
        buttonPrompt.SetActive(false);
    }
}
