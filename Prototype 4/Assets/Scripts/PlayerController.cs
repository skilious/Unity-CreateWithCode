using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float powerupStrength;
    public GameObject powerupIndicator;

    private Rigidbody _rb;
    private GameObject focalPoint;
    private bool hasPowerup;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        powerupIndicator.transform.position = transform.position;
        float forwardInput = Input.GetAxis("Vertical") * speed;
        _rb.AddForce(focalPoint.transform.forward * forwardInput);
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        powerupIndicator.SetActive(true);
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);
            hasPowerup = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 knockback = (other.gameObject.transform.position - transform.position);
            enemyRb.AddForce(knockback * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + other.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
