using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWinController : MonoBehaviour
{

    private WinController winController;

    void Start()
    {
        if(winController == null)
        {
            winController = FindObjectOfType<WinController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (winController == null)
        {
            winController = FindObjectOfType<WinController>();
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            winController.SetWin();
        }
    }
}
