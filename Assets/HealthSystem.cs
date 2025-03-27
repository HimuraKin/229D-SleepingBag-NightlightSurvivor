using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int baseMaxHealth = 100;
    public int maxHealth;
    private int currentHealth;
    public int healAmount = 20;
    public float healCD = 30;

    public bool isHealReady = true;

    public Image healIcon;

    public TextMeshProUGUI currentHealthTxt;

    public TextMeshProUGUI healText;

    void Start()
    {
        ResetStats();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void ResetStats()
    {
        maxHealth = baseMaxHealth;
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (isHealReady == true)
        {
            healText.text = "Q";
            Color newColor = healIcon.color;
            newColor.a = 1f;
            healIcon.color = newColor;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Heal(healAmount);
                isHealReady = false;
                healCD = 30;
            }
        }
        else if (isHealReady == false)
        {
            healCD -= Time.deltaTime;

            healText.text = $"{healCD.ToString("0")}";

            Color newColor = healIcon.color;
            newColor.a = 0.5f;
            healIcon.color = newColor;

            if (healCD <= 0)
            {
                isHealReady = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        currentHealthTxt.text = $"{currentHealth} / {maxHealth}";
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
