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
    AudioManager audioManager;

    void Awake() 
    {
        CheckpointCollider = GetComponent<BoxCollider2D>();
        die = GameObject.FindGameObjectWithTag("Die").GetComponent<DieScript>();
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("animation Light Checkpoint");
            lumiere.intensity = 3f;
            audioManager.PlaySFX(audioManager.CheckpointSound);
            die.RespawnPoint = this.gameObject;
            CheckpointCollider.enabled = false;
        }
    }

}
