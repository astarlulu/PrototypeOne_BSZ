using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCamera : MonoBehaviour
{
    public float xSensitivity; //Controls how much the camera affects the camera movement.
    public float ySensitivity;

    public Transform orientation; //The always forward vector of the camera.

    private float xRotation; //These are going to actually control our camera's rotation in world space.
    private float yRotation;

    Vector2 lookVector; //x, y


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false; //Turns off cursor
        Cursor.lockState = CursorLockMode.Locked; //Ensurs cursor stays in the middle of our screen
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        lookVector = ctx.ReadValue<Vector2>();
    }


    // Update is called once per frame
    void Update()
    {
        float mouseX = lookVector.x * xSensitivity;
        float mouseY = lookVector.y * xSensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //Actually rotate our camera
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); //Always facing forward
    }
}
