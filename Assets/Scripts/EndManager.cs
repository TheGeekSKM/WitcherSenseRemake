﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
