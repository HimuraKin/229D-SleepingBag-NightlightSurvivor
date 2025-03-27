using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    private Boss boss;
    private bool bossFound = false;

    void Start()
    {
        healthSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!bossFound)
        {
            boss = FindObjectOfType<Boss>();
            if (boss != null)
            {
                healthSlider.gameObject.SetActive(true);
                bossFound = true;
                healthSlider.maxValue = boss.maxHealth;
                healthSlider.value = boss.health;
            }
        }
        else if (bossFound)
        {
            healthSlider.gameObject.SetActive(false);
        }

        if (bossFound && boss != null)
        {
            healthSlider.value = boss.health;
        }

    }
}
