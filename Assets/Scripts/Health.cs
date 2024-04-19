using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth; //set heal to maxheal (3)
    }

    void Update()
    {
        
    }

    public void TakeDamaged(int amount) //censé prendre des dégats mais marche pas because chepa
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() //chrono mort 3 secondes avant changement to menu
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SCN_menu");
    }
}
