using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerCam1Spawn : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera cam1;     //set camera pos1
    [SerializeField] CinemachineVirtualCamera cam2;     //set camera pos2

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam1.Priority = 100;
        cam2.Priority = 1;
    }
}
