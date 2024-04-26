using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TMP_Text PV;
    [SerializeField] GameObject MortAffichage;

    void Start()
    {
        gameObject.SetActive(false);
        currentHealth = maxHealth; //set heal to maxheal (3)
        PV.text = "Vie : " + currentHealth.ToString();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(true);
        }
    }

    public void TakeDamaged(int amount)
    {
        currentHealth -= amount;
        Debug.Log("HPs : " + currentHealth);
        PV.text = "Vie : " + currentHealth.ToString();
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
