using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BegBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    bool playerInRange;
    bool isBegging;
    public int begCount;
    int currentBegCount;
    public GameObject buttonpromptText1;
    public GameObject[] BegTexts;
    public Vector3 offset;
    public GameObject fired;

    private bool didwin = false;

    void Start()
    {
        playerInRange = false;
        isBegging = false;
        currentBegCount = 0;
        fired.SetActive(false);
        buttonpromptText1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            isBegging = true;
            player.GetComponent<Player_SideScroll>().canMove = false;
            buttonpromptText1.GetComponent<Text>().text = "\"SPACE\"";
            //player.GetComponent<Player_SideScroll>().enabled = false;
        }

        if (isBegging == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(BegTexts[currentBegCount], player.transform.position + offset, player.transform.rotation);
                currentBegCount += 1;

            }


            if(!didwin && currentBegCount >= begCount)
            {
                fired.SetActive(true);
                buttonpromptText1.SetActive(false);
                didwin = true;
                StartCoroutine(DelayWin());
            }



        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            buttonpromptText1.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
            buttonpromptText1.SetActive(false);
        }
    }

    private IEnumerator DelayWin()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<WinController>().SetWin();
        yield return null;
    }
}
