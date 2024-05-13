using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVieBamboo : MonoBehaviour
{
    public Health healthscript;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //mort chute
        {
            Debug.Log("Ajout Vie");
            healthscript.TakeDamaged(-1);
            Destroy(gameObject);
        }
    }
}
