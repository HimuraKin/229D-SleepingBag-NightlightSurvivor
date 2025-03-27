using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI dmgText, speedText, asText, currentWaveText;

    private bool isPaused = false;
    public PauseMenu pauseMenu;

    public LightBall lightBall;
    public PlayerMovement playerMovement;
    public ShootSystem shootSystem;
    public SpawnManager spawnManager;

    private void Update()
    {
        UpdateDMGUI();
        UpdateSpeedUI();
        UpdateAttackSpeedUI();
        UpdateWaveUI();
        ShowPause();
    }

    public void ShowPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseMenu.Pause();
            }
            else if (!isPaused)
            {
                pauseMenu.Resume();
            }
        }
    }

    public void UpdateDMGUI()
    {
        dmgText.text = $"{lightBall.damage}";
    }

    public void UpdateSpeedUI()
    {
        speedText.text = $"{playerMovement.moveSpeed}";
    }
    public void UpdateAttackSpeedUI()
    {
        asText.text = $"{shootSystem.fireRate}";
    }
    public void UpdateWaveUI()
    {
        currentWaveText.text = $"Wave : {spawnManager.currentWave + 1}";
    }
}
