using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CheckpointScript : MonoBehaviour
{
    private DieScript die;
    private BoxCollider2D CheckpointCollider;
    public Light2D lumiere;

    void Awake() 
    {
        CheckpointCollider = GetComponent<BoxCollider2D>();
        die = GameObject.FindGameObjectWithTag("Die").GetComponent<DieScript>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("animation Light Checkpoint");
            lumiere.intensity = 3f;
            die.RespawnPoint = this.gameObject;
            CheckpointCollider.enabled = false;
        }
    }

}
