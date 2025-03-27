using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetStats : MonoBehaviour
{
    public PlayerMovement player;
    public HealthSystem healthSystem;
    public ShootSystem shootSystem;
    public LightBall lightBall;

    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        player.ResetStats();
        healthSystem.ResetStats();
        shootSystem.ResetStats();
        lightBall.ResetStats();
    }
}
