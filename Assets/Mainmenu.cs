using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    public GameObject play;
    public GameObject quit;
    public GameObject fiveWave;
    public GameObject back;
    public GameObject playMode;
    public void ShowFiveWave()
    {
        fiveWave.SetActive(true);
        back.SetActive(true);
        playMode.SetActive(true);
        play.SetActive(false);
        quit.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        fiveWave.SetActive(false);
        back.SetActive(false);
        playMode.SetActive(false);
        play.SetActive(true);
        quit.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
