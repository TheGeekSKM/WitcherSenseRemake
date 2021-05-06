using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class WitcherSense : MonoBehaviour
{
    
    [Header("References/Connections")]
    //First I need access to the Cinemachine Component
    [SerializeField] CinemachineFreeLook cameraSettings;

    [Header("Attributes")]
    [SerializeField] public float witcherFOV = 31f;
    [SerializeField] public bool witcherMode;
    [SerializeField] PostProcessVolume postVolume;
    
    float originalFOV;
    DepthOfField dOV;
    LensDistortion lDis;
    ChromaticAberration chromAbb;

    private void Start()
    {
        witcherMode = false;
        originalFOV = cameraSettings.m_Lens.FieldOfView;
        
        postVolume.profile.TryGetSettings(out dOV);
        postVolume.profile.TryGetSettings(out lDis);
        postVolume.profile.TryGetSettings(out chromAbb);
    }


    void Update()
    {
        //This will check if I hold down the RMB
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            witcherMode = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            witcherMode = false;
        }

        if (witcherMode)
        {
            if (cameraSettings.m_Lens.FieldOfView > witcherFOV)
            {
                cameraSettings.m_Lens.FieldOfView -= 0.5f;
            }

            dOV.active = true;

            if (lDis.intensity.value > -50f)
            {
                lDis.intensity.value -= 2f;
            }

            if (chromAbb.intensity.value < 1f)
            {
                chromAbb.intensity.value += 0.1f;
            }
        }
        else
        {
            if (cameraSettings.m_Lens.FieldOfView < originalFOV)
            {
                cameraSettings.m_Lens.FieldOfView += 0.5f;
            }

            dOV.active = false;

            if (lDis.intensity.value < 0f)
            {
                lDis.intensity.value += 2f;
            }

            if (chromAbb.intensity.value > 0f)
            {
                chromAbb.intensity.value -= 0.1f;
            }
        }
    }

    
}
