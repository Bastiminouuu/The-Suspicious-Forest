using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour 
{
    public int scorevalue;
    //public AudioSource SoundCoin;

    private void Start()
    {
        //SoundCoin = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Plays Sound Coin");
            //SoundCoin.Play();
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(scorevalue);
        }
    }
}