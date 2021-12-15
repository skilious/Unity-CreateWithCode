using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    public float zRangeTop = 30f;
    public float zRangeBottom = 30f;
    void Update()
    {
        if (transform.position.z >= zRangeTop)
        {
            Destroy(gameObject); //Destroy gameObject.
        }
        else if (transform.position.z <= -zRangeBottom)
        {
            print("Game Over and you suck!");
            Destroy(gameObject);
        }
    }
}
