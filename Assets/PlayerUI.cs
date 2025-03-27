using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI dmgText;
    public LightBall lightBall;

    public TextMeshProUGUI speedText;
    public PlayerMovement playerMovement;

    public TextMeshProUGUI asText;
    public ShootSystem shootSystem;

    private void Update()
    {
        UpdateDMGUI();
        UpdateSpeedUI();
        UpdateAttackSpeedUI();
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
}
