using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    public Health healthscript;
    public GameObject player;
    public GameObject RespawnPoint;
    public bool EnVie = true;
    [SerializeField] CinemachineVirtualCamera cam1;     //set camera pos1
    [SerializeField] CinemachineVirtualCamera camEnemy;     //set camera pos2

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //mort chute
        {
            Debug.Log("Die chute");
            healthscript.TakeDamaged(1);
            audioManager.PlaySFX(audioManager.FallSound);
            //----------------------------------
            cam1.Priority = 100;
            camEnemy.Priority = 1;
            //----------------------------------
            player.transform.position = RespawnPoint.transform.position;
        }
    }
}
