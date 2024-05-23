using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) //rajouter la touche start manette startButton
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume");
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Debug.Log("Load Menu");
        Time.timeScale = 1f;
        BGmusic.instance.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("SCN_menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
        SceneManager.LoadScene("SCN_Start");
    }
}