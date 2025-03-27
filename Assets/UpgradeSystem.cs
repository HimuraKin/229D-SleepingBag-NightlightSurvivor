using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public PlayerMovement player;
    public ShootSystem shootSystem;
    public HealthSystem healthSystem;

    public void IncreaseSpeed()
    {
        player.moveSpeed += 1f;
    }

    public void IncreaseFireRate()
    {
        shootSystem.fireRate -= 0.1f;
    }

    public void IncreaseHealth()
    {
        healthSystem.maxHealth += 10;
        healthSystem.Heal(10);
    }
}
