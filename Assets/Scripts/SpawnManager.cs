using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public int enemiesKilled = 0;

    private GameObject preloadedBoss;

    private void Start()
    {
        preloadedBoss = Instantiate(bossPrefab);
        preloadedBoss.SetActive(false);

        GameAnalyticsManager.instance.RecordGameStart();
        enemiesKilled = 0;

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

                preloadedBoss.transform.position = spawnPoints[bossIndex].position;
                preloadedBoss.SetActive(true);

                activeEnemies.Add(preloadedBoss);
            }
            else
            {
                for (int i = 0; i < wave.totalSpawnEnemies; i++)
                {
                    int enemyIndex = Random.Range(0, wave.numberOfRandomSpawnPoint);

                    GameObject enemyObj = Instantiate(
                        enemyPrefab,
                        spawnPoints[enemyIndex].position,
                        Quaternion.identity
                    );

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

            if (currentWave < waves.Length - 1)
            {

                waveClearedPic.gameObject.SetActive(true);
                yield return new WaitForSeconds(3f);

                waveClearedPic.gameObject.SetActive(false);

                upgradeUI.ShowUpgrades();
            }

            yield return new WaitUntil(() => !upgradeUI.upgradePanel.activeSelf);

            Debug.Log("Next Wave Starting...");
            currentWave++;
        }

        Debug.Log("Game Completed!");
        upgradeUI.upgradePanel.SetActive(false);
        GameAnalyticsManager.instance.RecordGameEnd(currentWave, true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(2);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            enemiesKilled++;
        }
    }
}