using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    private Vector3 startVector;
    private float repeatWidth;
    private void Start()
    {
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //Get half point of the size.
        startVector = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startVector.x - repeatWidth)
        {
            transform.position = startVector;
        }
    }
}
