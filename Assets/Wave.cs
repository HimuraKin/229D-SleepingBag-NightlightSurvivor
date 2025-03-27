using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int totalSpawnEnemies;
    public int numberOfRandomSpawnPoint;
    public int delayStart;
    public int spawnInterval;

    public float healthBoost = 1.2f;
    public float speedBoost = 1.05f;
    public float damageBoost = 1.1f;
}
