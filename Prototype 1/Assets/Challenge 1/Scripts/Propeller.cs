using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public float spinSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed);
    }
}
