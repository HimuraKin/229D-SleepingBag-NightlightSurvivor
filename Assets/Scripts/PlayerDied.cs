using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    public GameObject deadPanel;

    private void Start()
    {
        deadPanel.SetActive(false);
    }

    public void OnPlayerDied()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        deadPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        deadPanel.SetActive(false);

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMain()
    {
        deadPanel.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}