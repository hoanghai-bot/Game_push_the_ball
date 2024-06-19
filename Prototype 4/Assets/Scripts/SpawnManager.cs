using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawn;
    private float spawnRange = 9;

    public int enemyCount;

    public int waveNumber = 1;

    public GameObject powerup;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerup,GenerateSpawnPosition(),powerup.transform.rotation);
    }

    private void SpawnEnemyWave(int x)
    {
        for (int i = 0; i < x; i++)
        {
            Instantiate(spawn, GenerateSpawnPosition(), spawn.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
        }
    }
}
