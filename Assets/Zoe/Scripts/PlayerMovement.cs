using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 input; //Takes our input
    Vector3 moveDirection; //Which way are we going?

    public Transform orientation;
    public float moveSpeed = 7;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //Ensures we dont spin around!
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        SpeedControl();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        input = ctx.ReadValue<Vector2>();
    }

    public void MovePlayer()
    {
        moveDirection = orientation.forward * input.y + orientation.right * input.x; //Get the direction we are going to move in

        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force); //Actually move us!

        if (input == Vector2.zero) //If we're not moving, stop.
        {
            rb.linearVelocity = Vector3.zero; //Resets to 0, 0, 0.
        }
    }

    void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); //Our current velocity

        if (flatVelocity.magnitude > moveSpeed) //If our velocity is greater than our speed
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed; //Create a new velocity
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z); //Set new velocity
        }
    }
}