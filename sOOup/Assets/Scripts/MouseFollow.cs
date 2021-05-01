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

    // Start is called before the first frame update
    void Start()
    {
        wc = GetComponent<WinController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4));
        bool click = Input.GetKey(KeyCode.Mouse0);
        if (click && lastClick != click)
        {
            if (goodBounds.bounds.Contains(spawnpoint.transform.position))
            {
                GameObject stamp = Instantiate(stampPrefab);
                stamp.transform.position = spawnpoint.transform.position;
                lastClick = click;
                wc.SetWin();
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
}
