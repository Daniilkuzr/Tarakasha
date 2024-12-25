using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnier : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public float spawnUnterval;
        public int spawnCount;
    }
    [System.Serializable]
    public class EnemyGroup 
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCOunt;
        public GameObject enemyPrefab;
    
    
    }


    public List<Wave> waves;
    public int currentWaveCount;

    Transform player;

    [Header("Spawner Attrbutes")]
    float spawnTimer;


    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        CalculateWaveQuta();

    }


    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer>=waves[currentWaveCount].spawnUnterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    void CalculateWaveQuta()
    {
        int currentWaveQuota = 0;
        foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies()
    {
        if(waves[currentWaveCount].spawnCount<waves[currentWaveCount].waveQuota)
        {
            foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if(enemyGroup.spawnCOunt<enemyGroup.enemyCount)
                {
                    float Randx = 0;
                    float Randy = 0;
                    
                    while(Mathf.Sqrt(Mathf.Pow(Mathf.Abs(Randx),2)+Mathf.Pow(Mathf.Abs(Randy),2))<10 || Mathf.Sqrt(Mathf.Pow(Mathf.Abs(Randx), 2) + Mathf.Pow(Mathf.Abs(Randy), 2)) > 15)
                    {
                        Randx = Random.Range(-30f, 30f);
                        Randy = Random.Range(-30f, 30f);
                    }
                    Vector3 spawnPosition = new Vector3(player.transform.position.x +Randx /*Random.Range(-30f, 30f)*/, player.transform.position.y +Randy /*Random.Range(-30f, 30f)*/, player.transform.position.z);
                    Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);

                    enemyGroup.spawnCOunt++;
                    waves[currentWaveCount].spawnCount++;
                }
            }
        }
    }
}
