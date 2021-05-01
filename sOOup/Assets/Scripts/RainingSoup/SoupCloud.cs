using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupCloud : MonoBehaviour
{
    public float speed = 10.0f;
    public Camera camera;
    public GameObject soupDrop;
    public float chanceToSpawnDrop = .5f;

    private Vector2 target;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnDrop",.5f,1f);
        InvokeRepeating("updateTarget", .0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        if (Vector2.Distance(transform.position, target) <= 1)
        {
            updateTarget();
        }

    }


    private void spawnDrop()
    {
        if(Random.value <= chanceToSpawnDrop)
        {
            GameObject spawnedDrop = Instantiate(soupDrop);
            spawnedDrop.transform.position = this.transform.position;
        }
    }


    private void updateTarget()
    {
        target = camera.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Screen.height));
    }




}
