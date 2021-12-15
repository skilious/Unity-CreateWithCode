using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float repeatRate = 3f;
    private void Start()
    {
        Invoke("SpawnObstacle", repeatRate);
    }

    void SpawnObstacle()
    {
        if (!PlayerController.instance.gameover)
        {
            repeatRate = Random.Range(3f, 5f);
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            Invoke("SpawnObstacle", repeatRate); //Call again as if its repeating invoke function but, its using Invoke with random integer.
        }
    }
}
