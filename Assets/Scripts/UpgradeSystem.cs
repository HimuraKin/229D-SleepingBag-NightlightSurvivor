using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public PlayerMovement player;
    public LightBall LightBall;
    public HealthSystem healthSystem;

    public void IncreaseSpeed()
    {
        player.moveSpeed += 1f;
    }

    public void IncreaseAttackDamage()
    {
        LightBall.damage += 10;
    }

    public void IncreaseHealth()
    {
        healthSystem.maxHealth += 10;
        healthSystem.Heal(10);
    }
}
