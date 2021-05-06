using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class WitcherSense : MonoBehaviour
{
    
    [Header("References/Connections")]
    //First I need access to the Cinemachine Component
    [SerializeField] CinemachineFreeLook cameraSettings;

    [Header("Attributes")]
    [SerializeField] public float witcherFOV = 31f;


    bool witcherMode;
    float originalFOV;

    private void Start()
    {
        witcherMode = false;
        originalFOV = cameraSettings.m_Lens.FieldOfView;
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
        }
        else
        {
            if (cameraSettings.m_Lens.FieldOfView < originalFOV)
            {
                cameraSettings.m_Lens.FieldOfView += 0.1f;
            }
        }
    }

    
}
