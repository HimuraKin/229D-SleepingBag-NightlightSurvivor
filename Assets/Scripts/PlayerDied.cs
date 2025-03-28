using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    public GameObject deadPanel;
    public HealthSystem healthSystem;

    private void Update()
    {
        if (healthSystem.currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deadPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            deadPanel.SetActive(false);
        }
    }

    public void PlayAgain()
    {
        deadPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void BackToMain()
    {
        deadPanel.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
