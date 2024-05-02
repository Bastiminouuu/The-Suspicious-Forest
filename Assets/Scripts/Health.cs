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
    [SerializeField] GameObject MortAffichage;

    void Start()
    {
        gameObject.SetActive(false);
        currentHealth = maxHealth; //set heal to maxheal (3)
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Mort");
            //gameObject.SetActive(true);
            SceneManager.LoadScene("SCN_menu");
        }

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
    }

    public void TakeDamaged(int amount)
    {
        currentHealth -= amount;
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
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
        Application.Quit();
    }
}
