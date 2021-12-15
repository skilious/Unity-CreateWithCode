using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 20f;
    private float horizontalInput;
    private float verticalInput;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //Input name from Unity's Input system - Left and Right steering
        verticalInput = Input.GetAxis("Vertical"); //Input name from Unity's Input system - Forward and Backward acceleration/reverse
        //Move the vehicle forward
        //transform.Translate(0, 0, 1);
        transform.Translate(transform.forward * Time.deltaTime * speed * verticalInput); //Clean version.

        //Turn left/right
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); Problem - This just moves the car side to side. No sort of rotation whatsoever.
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); //This now rotates by using Vector3.up (Y Axis rotation) and Steering input with Time.deltaTime.
    }
}
