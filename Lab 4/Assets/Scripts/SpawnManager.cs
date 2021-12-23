using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int enemyCount;
    public int enemyWaves;
    private void Start()
    {
        SpawnEnemies();
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount == 0)
        {
            SpawnEnemies();
        }
    }

    private Vector3 RandomSpawner()
    {
        float offlimitAxis = 9f;
        float randomX = Random.Range(-offlimitAxis, offlimitAxis); //Between -9 and 9.
        Vector3 randomPosition = new Vector3(randomX, 0, 10f);
        return randomPosition;
    }

    private void SpawnEnemies()
    {
        for(int i = 0; i < enemyWaves; i++)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            GameObject instantiatedObj = Instantiate(enemyPrefabs[randEnemy], RandomSpawner(), Quaternion.identity);
            instantiatedObj.GetComponent<MoveDown>().movementSpeed = Random.Range(15f, 20f);
        }
        enemyWaves++;
    }
}
