using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour 
{
    public int scorevalue;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(scorevalue);
        }
    }
}