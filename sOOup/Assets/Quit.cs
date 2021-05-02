using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Quit : MonoBehaviour
{
    public GameObject controlsCanvas;
    public int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        controlsCanvas.SetActive(true);
    }

    public void CloseControls()
    {
        controlsCanvas.SetActive(false);
    }
}
