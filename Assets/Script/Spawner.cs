using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;

    LifeManagement playerEntity;
    Transform playerT;

    Wave currentWave;
    int currentWaveNum;

    int enemiesRemainToSpawn;
    int enemiesRemainAlive;
    float nextSpawnTime;

    MapGenerator map;

    void Start()
    {
        playerEntity = FindObjectOfType<Player>();
        playerT = playerEntity.transform;

        map = FindObjectOfType<MapGenerator>();
        NextWave();
    }

    void Update()
    {
        if (enemiesRemainToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

                //Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
                //spawnedEnemy.OnDeath += OnEnemyDeath;

            StartCoroutine(SpawnEnemy());
        }
    }

    void OnEnemyDeath()
    {
        enemiesRemainAlive--;

        if (enemiesRemainAlive == 0)
            NextWave();
    }


    IEnumerator SpawnEnemy()
    {
        float spawnDelay = 1;
        float tileFlashSpeed = 4;

        Transform randomTile = map.GetRandomOpenTile();
        Material tileMat = randomTile.GetComponent<Renderer>().material;
        Color initialColor = tileMat.color;
        Color flashColor = Color.red;
        float spawnTimer = 0;

        while (spawnTimer < spawnDelay)
        {
            tileMat.color = Color.Lerp(initialColor, flashColor, Mathf.PingPong(spawnTimer * tileFlashSpeed, 1));
            spawnTimer += Time.deltaTime;
            yield return null;
        }

        Enemy spawnedEnemy = Instantiate(enemy, randomTile.position + Vector3.up, Quaternion.identity) as Enemy;
        print("spawn");
       // spawnedEnemy.OnDeath += OnEnemyDeath;
    }

    void NextWave()
    {
        currentWaveNum++;
        print("Wave : " + currentWaveNum);
        if (currentWaveNum - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNum - 1];

            enemiesRemainToSpawn = currentWave.enemyCount;
            enemiesRemainAlive = enemiesRemainToSpawn;
        }
    }

    [System.Serializable]
   public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
