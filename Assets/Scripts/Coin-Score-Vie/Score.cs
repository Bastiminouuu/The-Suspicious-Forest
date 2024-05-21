using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour 
{
    public int scorevalue;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.CoinSound);
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(scorevalue);
        }
    }
}