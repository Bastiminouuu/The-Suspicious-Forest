using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOpen : MonoBehaviour
{
    public GameObject DialogueUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueUI.SetActive(true);
    }
}
