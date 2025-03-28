using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    private Boss boss;

    void Start()
    {
        healthSlider.gameObject.SetActive(false);
        StartCoroutine(FindBossAndInitialize());
    }

    IEnumerator FindBossAndInitialize()
    {
        while (boss == null)
        {
            boss = FindObjectOfType<Boss>();
            yield return null;
        }

        healthSlider.gameObject.SetActive(true);
        healthSlider.maxValue = boss.maxHealth;
        healthSlider.value = boss.health;
    }

    void Update()
    {
        if (boss != null)
        {
            healthSlider.value = boss.health;
        }
    }
}
