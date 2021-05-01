using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public List<string> sceneOrder = new List<string>();
    public Animator anime;
    public bool isAnimating = false;

    [SerializeField]
    private bool didWin = false;
    [SerializeField]
    private int currScene = 0;
    private static bool winManagerExists = false;

    void Start()
    {
        anime = GameObject.Find("WinControllerTransition").GetComponent<Animator>();
        anime.SetBool("isFadeout", false);
        if (!winManagerExists)
        {
            winManagerExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(anime == null)
        {
            anime = GameObject.Find("WinControllerTransition").GetComponent<Animator>();
        }
        if(anime.GetCurrentAnimatorStateInfo(0).IsName("notransition"))
        {
            isAnimating = false;
        }
        else
        {
            isAnimating = true;
        }
    }

    public void SetWin()
    {
        didWin = true;
        if(currScene >= sceneOrder.Count)
        {
            // done, so go to main menu / win screen.
        }
        else
        {
            StartCoroutine(TransitionToFadein());
        }
    }

    public void SetLose()
    {
        didWin = false;
        StartCoroutine(TransitionToFadein(false));
    }

    private IEnumerator TransitionToFadein(bool didWin = true)
    {
        anime.SetBool("isFadeout", true);
        isAnimating = true;
        yield return new WaitForSecondsRealtime(0.5f);
        while (anime.GetCurrentAnimatorStateInfo(0).IsName("fadeout"))
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }

        if(didWin)
        {
            currScene++;
            SceneManager.LoadScene(sceneOrder[currScene]);
        }
        else
        {
            SceneManager.LoadScene(sceneOrder[currScene]);
        }
        yield return null;
    }
}
