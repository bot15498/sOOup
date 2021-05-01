using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public List<string> sceneOrder = new List<string>();

    [SerializeField]
    private bool didWin = false;
    [SerializeField]
    private int currScene = 0;
    private static bool winManagerExists = false;

    void Start()
    {
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
        
    }

    public void SetWin()
    {
        // do animation to transition here


        didWin = true;
        currScene++;
        if(currScene >= sceneOrder.Count)
        {
            // done, so go to main menu / win screen.
        }
        else
        {
            SceneManager.LoadScene(sceneOrder[currScene]);
        }
    }

    public void ResetLevel()
    {
        didWin = false;
        SceneManager.LoadScene(sceneOrder[currScene]);
    }
}
