using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{
    public Wander dude;
    public Wander chef;
    public int crowdSize = 30;
    public float spawnRadius = 3;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<crowdSize;i++)
        {
            Wander crowdDude = Instantiate(dude);
            crowdDude.transform.position = new Vector2(this.transform.position.x + (Random.Range(-spawnRadius,spawnRadius)),this.transform.position.y + (Random.Range(-spawnRadius, spawnRadius)));

        }
        Instantiate(chef);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
