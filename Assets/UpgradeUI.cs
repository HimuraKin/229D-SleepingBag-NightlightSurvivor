using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public GameObject upgradePanel;
    public Button[] upgradeButtons;
    public TextMeshProUGUI[] upgradeTexts;

    private List<UpgradeOption> allUpgrades = new();
    private List<UpgradeOption> currentOptions = new();

    public PlayerMovement player;
    public LightBall lightBall;
    public HealthSystem healthSystem;
    public ShootSystem shootSystem;

    private void Start()
    {
        InitializeUpgrades();
        upgradePanel.SetActive(false);
    }

    void InitializeUpgrades()
    {
        allUpgrades.Add(new UpgradeOption("IncreaseAttack", () => lightBall.damage += 10));
        allUpgrades.Add(new UpgradeOption("IncreaseHealth", () => { healthSystem.maxHealth += 20; healthSystem.Heal(20); }));
        allUpgrades.Add(new UpgradeOption("IncreaseSpeed", () => player.moveSpeed += 2f));
        allUpgrades.Add(new UpgradeOption("IncreaseAttackSpeed", () => shootSystem.fireRate -= 0.15f));
    }

    public void ShowUpgrades()
    {
        upgradePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        currentOptions.Clear();

        List<UpgradeOption> tempUpgrades = new List<UpgradeOption>(allUpgrades);
        for (int i = 0; i < 3; i++)
        {
            int randIndex = Random.Range(0, tempUpgrades.Count);
            UpgradeOption selectedUpgrade = tempUpgrades[randIndex];
            currentOptions.Add(selectedUpgrade);
            upgradeTexts[i].text = selectedUpgrade.name;

            int buttonIndex = i;
            upgradeButtons[i].onClick.RemoveAllListeners();
            upgradeButtons[i].onClick.AddListener(() =>
            {
                SelectUpgrade(buttonIndex);
            });

            tempUpgrades.RemoveAt(randIndex);
        }

        for (int i = 3; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

    public void SelectUpgrade(int index)
    {
        currentOptions[index].ApplyUpgrade();
        upgradePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
