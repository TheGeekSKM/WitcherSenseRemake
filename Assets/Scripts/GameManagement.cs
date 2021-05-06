using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] List<DestroyOnPress> allTheObjects = new List<DestroyOnPress>();
    [SerializeField] TextMeshProUGUI scoreText;

    int numOfItemsDestroyed;
    
    // Start is called before the first frame update
    void Start()
    {
        numOfItemsDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (DestroyOnPress g in allTheObjects)
        {
            if (g.isDestroyed && g.tag == "NotDestroyed")
            {
                numOfItemsDestroyed++;
                Debug.Log("it worked!!");
                g.tag = "Destroyed";
                
            }
        }

        scoreText.text = numOfItemsDestroyed.ToString();
    }
}
