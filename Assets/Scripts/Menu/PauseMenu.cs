using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public SwitchEventSystem SwitchEvent;

    private void Start()
    {
        SwitchEvent.RestoreOriginalFocus();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) //rajouter la touche start manette startButton
        {

            SwitchEvent.RestoreOriginalFocus();

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