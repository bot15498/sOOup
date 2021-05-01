using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    bool playerInRange;
    bool isBegging;
    public int begCount;
    int currentBegCount;
    public GameObject[] BegTexts;
    public Vector3 offset;
    public GameObject fired;

    void Start()
    {
        playerInRange = false;
        isBegging = false;
        currentBegCount = 0;
        fired.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            isBegging = true;
            player.GetComponent<Player_SideScroll>().enabled = false;


        }

        if(isBegging == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(BegTexts[currentBegCount], player.transform.position + offset, player.transform.rotation);
                currentBegCount += 1;

            }


            if(currentBegCount >= begCount)
            {
                fired.SetActive(true);

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
}
