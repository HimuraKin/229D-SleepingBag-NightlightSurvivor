using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public Transform[] spawnPoints;
    public Wave[] waves;
    public int currentWave = 0;
    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (currentWave < waves.Length)
        {
            Debug.Log($"Wave: {currentWave + 1}");
            Wave wave = waves[currentWave];
            yield return new WaitForSeconds(wave.delayStart);

            if (currentWave == waves.Length - 1)
            {
                Debug.Log("Boss Fight!");
                int bossIndex = Random.Range(0, spawnPoints.Length);
                GameObject boss = Instantiate(bossPrefab, spawnPoints[bossIndex].position, Quaternion.identity);
                activeEnemies.Add(boss);
            }
            else
            {
                for (int i = 0; i < wave.totalSpawnEnemies; i++)
                {
                    int enemyIndex = Random.Range(0, wave.numberOfRandomSpawnPoint);
                    GameObject enemy = Instantiate(enemyPrefab, spawnPoints[enemyIndex].position, enemyPrefab.transform.rotation);
                    activeEnemies.Add(enemy);
                    yield return new WaitForSeconds(wave.spawnInterval);
                }
            }

            yield return new WaitUntil(() => activeEnemies.Count == 0);

            Debug.Log("Next Wave");
            currentWave++;
        }
        Debug.Log("Finished !!");
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
        }
    }
}
