using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyOnPress : MonoBehaviour
{
    [SerializeField] DisplayTextQuest displayText;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] Renderer meshRender;
    [SerializeField] Collider meshCollider;
    [SerializeField] TextMeshPro text;
    [SerializeField] LayerMask whatIsPlayer;

    public bool isDestroyed;
    AudioSource audio; 

    private void Start()
    {
        isDestroyed = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.CheckSphere(transform.position, 2f, whatIsPlayer))
        {
            if (Input.GetKeyDown(KeyCode.E) && !isDestroyed )
            {
                //particle stuffs
                explosionParticle.Play();
                displayText.enabled = false;
                meshRender.enabled = false;
                text.enabled = false;
                meshCollider.enabled = false;
                audio.Play();
                isDestroyed = true;


            }
        }
    }
}
