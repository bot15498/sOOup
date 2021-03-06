using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject murderBody;

    bool startedWin = false;

    bool playerInRange;
    AudioSource AS;

    void Start()
    {
        playerInRange = false;
        murderBody.SetActive(false);
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {

            Player.SetActive(false);
            murderBody.SetActive(true);
            if (!startedWin)
            {
                AS.Play();
                StartCoroutine(DelayWin());
                
                startedWin = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    private IEnumerator DelayWin()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<WinController>().SetWin();
        yield return null;
    }
}
