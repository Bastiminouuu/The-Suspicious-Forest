using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    [SerializeField] GameObject player;
    public AudioManager audioManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 6)
        {
            timer += Time.deltaTime;

            if (timer > 3.5)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot() 
    {
        audioManager.PlaySFX(audioManager.SpearSound);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
