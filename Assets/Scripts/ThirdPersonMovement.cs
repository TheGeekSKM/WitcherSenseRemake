using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Connections")]
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;

    [Header("Player Attributes")]
    [SerializeField] public float speed = 6f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float gravity = -9.81f;

    float turnSmoothVelocity;
    Vector3 currentVelocity;
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //Get the angle of movement
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //To make the turn smooth
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            //set the roation to face the targetAngle
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        currentVelocity.y += gravity * Time.deltaTime;
        controller.Move(currentVelocity * Time.deltaTime);
    }
}
