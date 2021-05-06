using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPress : MonoBehaviour
{
    [SerializeField] DisplayTextQuest displayText;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] Renderer meshRender;
 
    // Update is called once per frame
    void Update()
    {
        if (displayText.playerNear == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //particle stuffs
                explosionParticle.Play();
                displayText.enabled = false;
                meshRender.enabled = false;

            }
        }
    }
}
