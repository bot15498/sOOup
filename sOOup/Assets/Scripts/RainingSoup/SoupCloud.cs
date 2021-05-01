using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupCloud : MonoBehaviour
{
    public float speed = 10.0f;
    public Camera camera;
    public SoupDrop soupDrop;
    public EvilSoupDrop evilDrop;
    public float chanceToSpawnDrop = .5f;

    public Vector2 target;
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
            if(Random.value >= .1)
            {
                SoupDrop leftDrop = Instantiate(soupDrop);
                leftDrop.parent = this;
                leftDrop.transform.position = new Vector3(this.transform.position.x - spriteWidth / 2, this.transform.position.y, 0);
            }
            else
            {
                EvilSoupDrop leftDrop = Instantiate(evilDrop);
                leftDrop.parent = this;
                leftDrop.transform.position = new Vector3(this.transform.position.x - spriteWidth / 2, this.transform.position.y, 0);
            }

        }
    }

    private void spawnMiddleDrop()
    {
        //  Middle Drop
        if (Random.value <= chanceToSpawnDrop)
        {
            if (Random.value >= .1)
            {
                SoupDrop middleDrop = Instantiate(soupDrop);
                middleDrop.parent = this;
                middleDrop.transform.position = this.transform.position;
            }else
            {
                EvilSoupDrop middleDrop = Instantiate(evilDrop);
                middleDrop.parent = this;
                middleDrop.transform.position = this.transform.position;
            }

        }
    }

    private void spawnRightDrop()
    { 
        //Right drop
        if (Random.value <= chanceToSpawnDrop)
        {
            if (Random.value >= .1)
            {
                SoupDrop rightDrop = Instantiate(soupDrop);
                rightDrop.parent = this;
                rightDrop.transform.position = new Vector3(this.transform.position.x + spriteWidth / 2, this.transform.position.y, 0);
            }else
            {
                EvilSoupDrop rightDrop = Instantiate(evilDrop);
                rightDrop.parent = this;
                rightDrop.transform.position = new Vector3(this.transform.position.x + spriteWidth / 2, this.transform.position.y, 0);
            }

        }
    }


    private void updateTarget()
    {
        target = camera.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Screen.height));
    }




}
