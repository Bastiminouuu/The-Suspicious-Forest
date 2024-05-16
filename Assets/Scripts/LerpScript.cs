using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScript : MonoBehaviour
{
    [SerializeField] Transform Start;
    [SerializeField] Transform End;
    [SerializeField] bool Deplacement = false;
    private float t = 0f;

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "LerpOn") 
        {
            Debug.Log("Deplacement TRUE");
            Deplacement = true;
        }

        if (Col.gameObject.tag == "LerpOff")
        {
            Debug.Log("Deplacement False");
            Deplacement = false;
            transform.position = this.transform.position;
        }
    }

    void Update()
    {
        if (Deplacement) 
        {
            transform.position = Vector2.Lerp(Start.position,End.position,t += 0.8f * Time.deltaTime);
        }
    }
}
