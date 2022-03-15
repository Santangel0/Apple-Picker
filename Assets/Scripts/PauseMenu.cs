using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pauseGame;

    public GameObject pauseGameMenu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (pauseGame)
            {
                Resume();
            }
            else
            {
                OpenPause();
            }
        }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseGame = false;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void OpenPause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pauseGame = true;
    }
}
