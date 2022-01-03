using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontalInput;
    [SerializeField] float turnRate;

    [SerializeField] float verticalInput;
    [SerializeField] float horsePower = 20.0f;
    [SerializeField] float speed;
    [SerializeField] float rpm;

    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] WheelCollider[] wheelColliders;
    
    private int wheelsOnGround;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = centerOfMass.transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Player movement left to right
        if(IsOnGround())
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            transform.Rotate(Vector3.up * Time.deltaTime * turnRate * horizontalInput);

            _rb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            speed = Mathf.Round(_rb.velocity.magnitude * 3.6f); //2.237f for mph.
            speedometerText.SetText("Speed: " + speed + " kph");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }

    }

    private bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in wheelColliders)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
