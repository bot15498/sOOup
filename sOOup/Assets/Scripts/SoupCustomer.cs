using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupCustomer : MonoBehaviour
{
    private TalkingController tc;

    void Start()
    {
        tc = FindObjectOfType<TalkingController>();
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tc.canStartDialogue = false;
    }
}
