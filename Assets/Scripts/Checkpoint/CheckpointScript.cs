using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private DieScript die;
    private BoxCollider2D CheckpointCollider;

    void Awake() 
    {
        CheckpointCollider = GetComponent<BoxCollider2D>();
        die = GameObject.FindGameObjectWithTag("Die").GetComponent<DieScript>();
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            die.RespawnPoint = this.gameObject;
            CheckpointCollider.enabled = false;
        }
    }

}
