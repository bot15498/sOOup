using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupTinder : MonoBehaviour
{
    public int numQuestions = 5;
    public int currQuestion = 0;
    public List<Sprite> possibleSprites;
    public List<bool> possibleAnswers;
    public GameObject throwawayPrefab;
    public int numWrong = 0;

    private bool lastA = false;
    private bool lastD = false;
    private GameObject curr;
    private bool currAnswer = false;
    private WinController wc;
    private bool calledEnd = false;
    
    void Start()
    {
        MakeProfile();
        wc = FindObjectOfType<WinController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!wc.isAnimating)
        {
            if (currQuestion <= numQuestions)
            {
                bool ainput = Input.GetKey(KeyCode.A);
                bool dinput = Input.GetKey(KeyCode.D);
                if (ainput && lastA != ainput)
                {
                    curr.GetComponent<TinderThrowaway>().SendFlying(true);
                    numWrong += !currAnswer ? 0 : 1;
                    MakeProfile();
                }
                else if (dinput && lastD != dinput)
                {
                    curr.GetComponent<TinderThrowaway>().SendFlying(false);
                    numWrong += currAnswer ? 0 : 1;
                    MakeProfile();
                }

                lastA = ainput;
                lastD = dinput;
            }
            else if (!calledEnd && currQuestion > numQuestions && numWrong == 0)
            {
                wc.SetWin();
                calledEnd = true;
            }
            else if (!calledEnd && currQuestion > numQuestions && numWrong > 0)
            {
                wc.SetLose();
                calledEnd = true;
            }
        }        
    }

    private void MakeProfile()
    {
        curr = Instantiate(throwawayPrefab);
        int idx = Random.Range(0, possibleSprites.Count);
        curr.GetComponent<TinderThrowaway>().renderer.sprite = possibleSprites[idx];
        currAnswer = possibleAnswers[idx];
        possibleAnswers.RemoveAt(idx);
        possibleSprites.RemoveAt(idx);
        currQuestion++;
        curr.GetComponent<TinderThrowaway>().renderer.sortingOrder = 99 - currQuestion;
    }
}
