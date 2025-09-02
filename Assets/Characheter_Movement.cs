using UnityEngine;

public class Characheter_Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    
    Vector3 Velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            Velocity.y = 0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement *(speed * Time.deltaTime));
        Velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);
    }
}