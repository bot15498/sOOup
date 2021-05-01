using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timerBar;
    public float timerLength = 20f;

    private WinController wc;
    [SerializeField]
    private float timeElapsed = 0f;
    private float maxwidth = 0f;
    private float height = 0f;

    void Start()
    {
        wc = FindObjectOfType<WinController>();
        maxwidth = timerBar.rectTransform.sizeDelta.x;
        height = timerBar.rectTransform.sizeDelta.y;
    }

    void Update()
    {
        if(wc == null)
        {
            wc = FindObjectOfType<WinController>();
        }
        
        if(!wc.isAnimating)
        {
            timeElapsed += Time.deltaTime;

            timerBar.rectTransform.sizeDelta = new Vector2(maxwidth * (timerLength - timeElapsed) / timerLength, height);
            if(timeElapsed > timerLength)
            {
                wc.SetLose();
            }
        }
    }
}
