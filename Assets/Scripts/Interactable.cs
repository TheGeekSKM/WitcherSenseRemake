using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Renderer render;
    [SerializeField] WitcherSense wSense;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wSense.witcherMode == true)
        {
            render.material.SetFloat("_Transparency", 0.2f);
        }
        else if (wSense.witcherMode == false)
        {
            render.material.SetFloat("_Transparency", 0f);
        }
    }
}
