using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float timerLength = 20;
    //GetComponent<ReferencedScript>();
    // Start is called before the first frame update
    void Start()
    {
        timer.text = "20s";
    }

    // Update is called once per frame
    void Update()
    {
        float currentTimerValue = float.Parse(timer.text.Substring(0, timer.text.Length - 1));
        
        if(currentTimerValue <= 0)
        {
            timer.text = "You had " + GetComponent<Victim>().health + " hp left.";
        }else
        {
        timer.text = (currentTimerValue - Time.deltaTime).ToString("F2")+"s";
        }


    }
}
