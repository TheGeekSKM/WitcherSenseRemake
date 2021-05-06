using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTextQuest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshPro text;
    [SerializeField] LayerMask whatIsPlayer;


    public bool playerNear;
    void Start()
    {
        text.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerNear = Physics.CheckSphere(transform.position, 2f, whatIsPlayer);

        if (playerNear)
        {
            text.enabled = true;

        }
        else if (!playerNear)
        {
            text.enabled = false;
        }
    }
}
