using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupCustomer : MonoBehaviour
{
    public GameObject buttonPrompt;
    private TalkingController tc;

    void Start()
    {
        tc = FindObjectOfType<TalkingController>();
        buttonPrompt.SetActive(false);
    }

    void Update()
    {
        if (tc == null)
        {
            tc = FindObjectOfType<TalkingController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tc.canStartDialogue = true;
        buttonPrompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tc.canStartDialogue = false;
        buttonPrompt.SetActive(false);
    }
}
