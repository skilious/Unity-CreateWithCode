using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Rigidbody _rb;
    public float movementSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        _rb.AddForce(Vector3.back * movementSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
