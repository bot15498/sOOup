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
    public GameObject instructions;

    private bool lastA = false;
    private bool lastD = false;
    private GameObject curr;
    private bool currAnswer = false;
    private WinController wc;
    private bool calledEnd = false;
    private Animator anime;
    [SerializeField]
    private bool isReadyForSwiping = false;
    AudioSource AS;
    public AudioSource AS2;

    void Start()
    {
        wc = FindObjectOfType<WinController>();
        anime = GetComponent<Animator>();
        instructions.SetActive(false);
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!wc.isAnimating)
        {
            if(!anime.GetBool("openPhone"))
            {
                anime.SetBool("openPhone", true);
                StartCoroutine(WaitForPhoneOpen());
            }

            if(isReadyForSwiping)
            {
                instructions.SetActive(true);
                if (currQuestion <= numQuestions)
                {
                    bool ainput = Input.GetKey(KeyCode.A);
                    bool dinput = Input.GetKey(KeyCode.D);
                    if (ainput && lastA != ainput)
                    {
                        curr.GetComponent<TinderThrowaway>().SendFlying(true);
                        AS2.Play();
                        numWrong += !currAnswer ? 0 : 1;
                        MakeProfile();
                    }
                    else if (dinput && lastD != dinput)
                    {
                        curr.GetComponent<TinderThrowaway>().SendFlying(false);
                        AS2.Play();
                        numWrong += currAnswer ? 0 : 1;
                        MakeProfile();
                    }

                    lastA = ainput;
                    lastD = dinput;
                }
                else if (!calledEnd && currQuestion > numQuestions && numWrong == 0)
                {
                    AS.Play();
                    wc.SetWin();

                    calledEnd = true;
                }
                else if (!calledEnd && currQuestion > numQuestions && numWrong > 0)
                {
                    AS.Play();
                    wc.SetLose();
                    calledEnd = true;
                }
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

    private IEnumerator WaitForPhoneOpen()
    {
        isReadyForSwiping = false;
        while (anime.GetCurrentAnimatorStateInfo(0).IsName("openPhone"))
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        anime.SetBool("screenOn", true);
        MakeProfile();
        isReadyForSwiping = true;
        yield return null;
    }
}
