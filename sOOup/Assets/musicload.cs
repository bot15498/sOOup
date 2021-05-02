using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicload : MonoBehaviour
{
    public static musicload Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
