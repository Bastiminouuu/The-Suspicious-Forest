using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerZoneBas : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam1;     //set camera pos1
    [SerializeField] CinemachineVirtualCamera cam2;     //set camera pos2
    private bool retour = true;                         //set actif ou non

    private void OnTriggerEnter2D()
    {
        if (retour == true)             //switch cam 2 is trigger
        {
            cam1.Priority = 1;
            cam2.Priority = 100;
        }

        else                            //switch cam 1 if not trigger
        {
            cam1.Priority = 100;
            cam2.Priority = 1;
        }
    }

    private void OnTriggerExit2D()      //sortie du trigger
    {
        if (retour == true)
        {
            retour = false;
        }
        else
        {
            retour = true;
        }
    }
}
