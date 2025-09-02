using UnityEngine;

public class Mouselook : MonoBehaviour
{
    public float mouseSensitivity =100f;
    public Transform playerBody;
    private float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;
        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up*MouseX);
    }
}