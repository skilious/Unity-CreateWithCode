using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.z <= -11f)
        {
            Destroy(gameObject);
        }
    }
}
