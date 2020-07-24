using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNum;

    int enemiesRemain;
    float nextSpawn;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        if (enemiesRemain > 0 && Time.time > nextSpawn)
        {
            enemiesRemain--;
            nextSpawn = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
        }
    }

    void NextWave()
    {
        currentWaveNum++;
        currentWave = waves[currentWaveNum - 1];

        enemiesRemain = currentWave.enemyCount;
    }

    [System.Serializable]
   public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
