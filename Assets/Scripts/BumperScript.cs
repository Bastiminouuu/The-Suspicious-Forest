using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    AudioManager audioManager;
    private float Bounce = 25f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.JumpChampiSound);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Bounce, ForceMode2D.Impulse);
        }
    }
}
