using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DieScript : MonoBehaviour
{
    public Health Healthscript;
    public GameObject player;
    public GameObject RespawnPoint;
    private int Vie = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vie == 0)
        {
            Debug.Log("Mort");

            StartCoroutine(DieCooldown());
        }
    }

    IEnumerator DieCooldown()
    {
        yield return new WaitForSeconds(3);
        //SetActive text for die
        //return to menu
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Die");
            player.transform.position = RespawnPoint.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Toucher");
            player.transform.position = RespawnPoint.transform.position;
            Vie--;
        }
    }
}
