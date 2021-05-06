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
    [SerializeField] PostProcessVolume postProcess;

    DepthOfField depthOfField;
    ChromaticAberration chromAbb;
    LensDistortion lensDistortion;

    float originalFOV;

    private void Start()
    {
        witcherMode = false;
        originalFOV = cameraSettings.m_Lens.FieldOfView;

        postProcess.profile.TryGetSettings(out depthOfField);
        postProcess.profile.TryGetSettings(out chromAbb);
        postProcess.profile.TryGetSettings(out lensDistortion);
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
                cameraSettings.m_Lens.FieldOfView -= 0.1f;
            }

            depthOfField.active = true;

            if (lensDistortion.intensity.value > -30f)
            {
                lensDistortion.intensity.value -= 2f;
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
                cameraSettings.m_Lens.FieldOfView += 0.1f;
            }

            depthOfField.active = false;

            if (lensDistortion.intensity.value < 0f)
            {
                lensDistortion.intensity.value += 2f;
            }

            if (chromAbb.intensity.value > 0f)
            {
                chromAbb.intensity.value -= 0.1f;
            }
        }
    }

    
}
