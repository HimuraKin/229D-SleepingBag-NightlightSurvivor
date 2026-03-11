using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Threading.Tasks;

public class GameAnalyticsManager : MonoBehaviour
{
    public static GameAnalyticsManager instance;
    private float sessionStartTime;

    async void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            await ServicesInitialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async Task ServicesInitialize()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }

    public void RecordPlayerDeath(int wave, int enemiesKilled)
    {
        CustomEvent playerDeath = new CustomEvent("Player_Death")
        {
            {"Wave", wave + 1},
            {"EnemiesKilled", enemiesKilled}
        };

        AnalyticsService.Instance.RecordEvent(playerDeath);
    }

    public void RecordUpgrade(string upgradeName, int wave)
    {
        CustomEvent upgradeEvent = new CustomEvent("Upgrade_Selected")
        {
            {"UpgradeName", upgradeName},
            {"Wave", wave + 1}
        };

        AnalyticsService.Instance.RecordEvent(upgradeEvent);
    }

    // 3 Enemy Kill
    public void RecordEnemyKilled(string enemyType, int wave)
    {
        CustomEvent killEvent = new CustomEvent("Enemy_Killed")
        {
            {"EnemyType", enemyType},
            {"Wave", wave + 1}
        };

        AnalyticsService.Instance.RecordEvent(killEvent);
    }

    public void RecordGameStart()
    {
        sessionStartTime = Time.time;

        CustomEvent startEvent = new CustomEvent("Game_Start");

        AnalyticsService.Instance.RecordEvent(startEvent);
    }

    public void RecordGameEnd(int waveReached, bool isWin)
    {
        float sessionDuration = Time.time - sessionStartTime;

        CustomEvent gameEnd = new CustomEvent("Game_End")
    {
        {"SessionDuration", sessionDuration},
        {"WaveReached", waveReached + 1},
        {"IsWin", isWin}
    };

        AnalyticsService.Instance.RecordEvent(gameEnd);
    }
}