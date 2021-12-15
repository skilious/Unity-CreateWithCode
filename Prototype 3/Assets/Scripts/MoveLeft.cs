using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    public float rightBound = 10f;
    private PlayerController instance;
    private void Start()
    {
        instance = PlayerController.instance;
    }
    void Update()
    {
        if(!instance.gameover)
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if(transform.position.x < rightBound && gameObject.CompareTag("Obstacle"))
        {
            print("Destroyed");
            Destroy(gameObject);
        }
    }
}
