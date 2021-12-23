using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public float movementSpeed;
    public float knockbackForce;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime; //Horizontal - Left/Right w/ movementSpeed modifier with deltaTime.
        _rb.AddForce(Vector3.right * inputX, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody _enemyRb = other.gameObject.GetComponent<Rigidbody>();
            _enemyRb.AddForce(other.gameObject.transform.position - transform.position * knockbackForce); //Knockback
        }
    }
}
