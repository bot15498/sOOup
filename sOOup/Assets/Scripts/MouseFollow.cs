using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public GameObject stampPrefab;
    public GameObject spawnpoint;
    public BoxCollider2D goodBounds;
    public BoxCollider2D allBounds;
    [SerializeField]
    private bool lastClick = false;
    private WinController wc;
    private bool didbranding = false;

    // Start is called before the first frame update
    void Start()
    {
        wc = FindObjectOfType<WinController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wc == null)
        {
            wc = FindObjectOfType<WinController>();
        }

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4));
        bool click = Input.GetKey(KeyCode.Mouse0);
        if (!didbranding && click && lastClick != click)
        {
            if (goodBounds.bounds.Contains(spawnpoint.transform.position))
            {
                GameObject stamp = Instantiate(stampPrefab);
                stamp.transform.position = spawnpoint.transform.position;
                lastClick = click;
                didbranding = true;
                StartCoroutine(WaitToWin());
            }
            else if (allBounds.bounds.Contains(spawnpoint.transform.position))
            {
                GameObject stamp = Instantiate(stampPrefab);
                stamp.transform.position = spawnpoint.transform.position;
                lastClick = click;
                wc.SetLose();
            }
        }        
    }

    private IEnumerator WaitToWin()
    {
        yield return new WaitForSeconds(1f);
        wc.SetWin();
        yield return null;
    }
}
