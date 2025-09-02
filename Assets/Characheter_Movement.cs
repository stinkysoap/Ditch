using UnityEngine;

public class Characheter_Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float sprintMultiplier = 1.5f; // how much faster sprinting is

    private Vector3 Velocity;

    void Update()
    {
        if (controller.isGrounded)
        {
            Velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Check if Left Shift is held down
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        // Apply movement
        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * (currentSpeed * Time.deltaTime));

        // Apply gravity
        Velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);
    }
}