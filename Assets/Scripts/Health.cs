using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    [SerializeField] Sprite heart3;
    [SerializeField] Sprite heart2;
    [SerializeField] Sprite heart1;
    [SerializeField] Image heart;
    AudioManager audioManager;

    //[SerializeField] GameObject MortAffichage;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth; //set heal to maxheal (3)
    }

    private void Update()
    {
        if (currentHealth == 3)
        {
            heart.sprite = heart3;
        }
        if (currentHealth == 2)
        {
            heart.sprite = heart2;
        }
        if (currentHealth == 1)
        {
            heart.sprite = heart1;
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("BoutonA"))
        {
            currentHealth++;
            if (currentHealth > 3)
            {
                currentHealth = 3;
            }
        }
    }

    public void TakeDamaged(int amount)
    {
        currentHealth -= amount;
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
        Time.timeScale = 1f;
        SceneManager.LoadScene("SCN_Start");
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
        Time.timeScale = 1f;
        Application.Quit();
    }
}
