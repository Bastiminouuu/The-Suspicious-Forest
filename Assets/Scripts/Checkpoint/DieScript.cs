using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DieScript : MonoBehaviour
{
    public Health Healthscript;
    public GameObject player;
    public GameObject RespawnPoint;
    public bool EnVie = true;

    private void OnTriggerEnter2D(Collider2D other) // mort chute
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Die");
            player.transform.position = RespawnPoint.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //mort enemy
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            EnVie = false;
            if (!EnVie)
            {
                Debug.Log("Toucher");
                player.transform.position = RespawnPoint.transform.position;
                Debug.Log("Mort et respawn");
                EnVie = true;
            }
        }
    }
}
