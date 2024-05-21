using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVieBamboo : MonoBehaviour
{
    public Health healthscript;
    public GameObject player;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //mort chute
        {
            Debug.Log("Ajout Vie");
            healthscript.TakeDamaged(-1);
            audioManager.PlaySFX(audioManager.AddVieSound);
            if (healthscript.currentHealth > 3)
            {
                healthscript.currentHealth = 3;
            }
            Destroy(gameObject);
        }
    }
}
