using UnityEngine;
// Test 
public class Characheter_Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float sprintMultiplier = 1.5f; // how much faster sprinting is
    public GameObject playerbody;
    private Vector3 Velocity;
    private Vector3 orignalScale;
    void Start(){
    
        orignalScale = playerbody.transform.localScale;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) // when key is pressed
        {
            playerbody.transform.localScale = new Vector3(
                orignalScale.x, 
                orignalScale.y * 0.5f, // crouch lower
                orignalScale.z
            );
        }


        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerbody.transform.localScale = orignalScale;

        }
        if (controller.isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f; // keeps player grounded
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