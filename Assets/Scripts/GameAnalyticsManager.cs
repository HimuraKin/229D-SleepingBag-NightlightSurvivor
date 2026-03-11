using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Threading.Tasks;

public class GameAnalyticsManager : MonoBehaviour
{
    public static GameAnalyticsManager instance;

    private float sessionStartTime;
    private bool isInitialized = false;

    private async void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            await InitializeServices();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async Task InitializeServices()
    {
        try
        {
            await UnityServices.InitializeAsync();
            AnalyticsService.Instance.StartDataCollection();

            isInitialized = true;

            Debug.Log("Analytics Initialized");
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Analytics initialization failed: " + e.Message);
        }
    }

    public void RecordGameStart()
    {
        if (!isInitialized) return;

        sessionStartTime = Time.time;

        CustomEvent startEvent = new CustomEvent("Game_Start");
        AnalyticsService.Instance.RecordEvent(startEvent);
    }

    public void RecordGameEnd(int waveReached, bool isWin)
    {
        if (!isInitialized) return;

        float sessionDuration = Time.time - sessionStartTime;

        CustomEvent gameEnd = new CustomEvent("Game_End")
        {
            {"SessionDuration", sessionDuration},
            {"WaveReached", waveReached + 1},
            {"IsWin", isWin}
        };

        AnalyticsService.Instance.RecordEvent(gameEnd);
    }

    public void RecordPlayerDeath(int wave, int enemiesKilled)
    {
        if (!isInitialized) return;

        CustomEvent playerDeath = new CustomEvent("Player_Death")
        {
            {"Wave", wave + 1},
            {"EnemiesKilled", enemiesKilled}
        };

        AnalyticsService.Instance.RecordEvent(playerDeath);
    }

    public void RecordUpgrade(string upgradeName, int wave)
    {
        if (!isInitialized) return;

        CustomEvent upgradeEvent = new CustomEvent("Upgrade_Selected")
        {
            {"UpgradeName", upgradeName},
            {"Wave", wave + 1}
        };

        AnalyticsService.Instance.RecordEvent(upgradeEvent);
    }

    public void RecordEnemyKilled(string enemyType, int wave)
    {
        if (!isInitialized) return;

        CustomEvent killEvent = new CustomEvent("Enemy_Killed")
        {
            {"EnemyType", enemyType},
            {"Wave", wave + 1}
        };

        AnalyticsService.Instance.RecordEvent(killEvent);
    }
}