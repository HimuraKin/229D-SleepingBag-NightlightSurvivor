using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public ShootSystem shootSystem;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        shootSystem.SetPause(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        shootSystem.SetPause(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Mainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
