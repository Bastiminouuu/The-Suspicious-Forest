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

    void Start()
    {
        currentHealth = maxHealth; //set heal to maxheal (3)
        PV.text = "Vie : " + currentHealth.ToString();
    }

    public void TakeDamaged(int amount) //censé prendre des dégats mais marche pas because chepa
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
        PV.text = "Vie : " + currentHealth.ToString();

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() //chrono mort 3 secondes avant changement to menu
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SCN_menu");
    }
}
