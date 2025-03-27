using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public Transform[] spawnPoints;
    public Wave[] waves;
    public int currentWave = 0;
    private List<GameObject> activeEnemies = new List<GameObject>();

    public UpgradeUI upgradeUI;

    public Image waveClearedPic;

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
                    GameObject enemyObj = Instantiate(enemyPrefab, spawnPoints[enemyIndex].position, enemyPrefab.transform.rotation);

                    Enemy enemy = enemyObj.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.health = Mathf.RoundToInt(enemy.health * wave.healthBoost);
                        enemy.speed *= wave.speedBoost;
                        enemy.damage = Mathf.RoundToInt(enemy.damage * wave.damageBoost);
                    }

                    activeEnemies.Add(enemyObj);
                    yield return new WaitForSeconds(wave.spawnInterval);
                }
            }

            yield return new WaitUntil(() => activeEnemies.Count == 0);

            waveClearedPic.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);

            waveClearedPic.gameObject.SetActive(false);
            upgradeUI.ShowUpgrades();

            yield return new WaitUntil(() => !upgradeUI.upgradePanel.activeSelf);

            Debug.Log("Next Wave Starting...");
            currentWave++;
        }
        Debug.Log("All Waves Completed!!");
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
        }
    }
}
