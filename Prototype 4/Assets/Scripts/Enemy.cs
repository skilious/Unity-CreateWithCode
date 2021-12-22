using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;
    private Transform playerTransform;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 lookDir = (playerTransform.position - transform.position).normalized;
        _rb.AddForce(lookDir * speed);
        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
