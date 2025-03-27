using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI dmgText, speedText, asText, currentWaveText;
    
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
