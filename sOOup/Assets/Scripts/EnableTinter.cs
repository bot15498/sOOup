using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTinter : MonoBehaviour
{
    GameObject phone;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        phone.SetActive(true);
    }
}
