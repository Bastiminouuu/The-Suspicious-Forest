using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DieScript : MonoBehaviour
{
    public Health healthscript;
    public GameObject player;
    public GameObject RespawnPoint;
    public bool EnVie = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //mort chute
        {
            Debug.Log("Die chute");
            healthscript.TakeDamaged(1);
            player.transform.position = RespawnPoint.transform.position;
        }
    }
}
