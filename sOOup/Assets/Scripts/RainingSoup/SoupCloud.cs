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
    private float spriteWidth = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteWidth = camera.ScreenToWorldPoint(new Vector3(GetComponent<SpriteRenderer>().sprite.rect.width,0,0)).x;
        InvokeRepeating("spawnLeftDrop",.7f,1f);
        InvokeRepeating("spawnRightDrop", .2f, 1f);
        InvokeRepeating("spawnMiddleDrop", .9f, 1f);
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


    private void spawnLeftDrop()
    {
        //Left Drop
        if (Random.value <= chanceToSpawnDrop)
        {
            GameObject leftDrop = Instantiate(soupDrop);
            leftDrop.transform.position = new Vector3(this.transform.position.x - spriteWidth / 2, this.transform.position.y, 0);
        }
    }

    private void spawnMiddleDrop()
    {
        //  Middle Drop
        if (Random.value <= chanceToSpawnDrop)
        {
            GameObject middleDrop = Instantiate(soupDrop);
            middleDrop.transform.position = this.transform.position;
        }
    }

    private void spawnRightDrop()
    { 
        //Right drop
        if (Random.value <= chanceToSpawnDrop)
        {
            GameObject rightDrop = Instantiate(soupDrop);
            rightDrop.transform.position = new Vector3(this.transform.position.x + spriteWidth / 2, this.transform.position.y, 0);
        }
    }


    private void updateTarget()
    {
        target = camera.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Screen.height));
    }




}
