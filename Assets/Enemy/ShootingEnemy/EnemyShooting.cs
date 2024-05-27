using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    [SerializeField] GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 6)
        {
            timer += Time.deltaTime;

            if (timer > 4.5)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot() 
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
