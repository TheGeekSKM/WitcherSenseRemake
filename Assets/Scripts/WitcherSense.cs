using Cinemachine;
using UnityEngine;

public class WitcherSense : MonoBehaviour
{
    
    [Header("References/Connections")]
    //First I need access to the Cinemachine Component
    [SerializeField] CinemachineFreeLook cameraSettings;

    [Header("Attributes")]
    [SerializeField] public float witcherFOV = 31f;
    [SerializeField] public float transitionTime = 4.5f;

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
        while (Input.GetMouseButton(1))
        {
            witcherMode = true;
        }

        if (!(Input.GetMouseButton(1)))
        {
            witcherMode = false;
        }

        if (witcherMode)
        {
            //cameraSettings.m_Lens.FieldOfView = witcherFOV;
            cameraSettings.m_Lens.FieldOfView = Mathf.Lerp(cameraSettings.m_Lens.FieldOfView, witcherFOV, transitionTime * Time.deltaTime);
        }
        else
        {

            cameraSettings.m_Lens.FieldOfView = Mathf.Lerp(cameraSettings.m_Lens.FieldOfView, originalFOV, transitionTime * Time.deltaTime);
        }
    }

    
}
