using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float fallDelay = 1f;
    [SerializeField] Rigidbody2D rigidbodyPlat;
    [SerializeField] float StartPosition;
    [SerializeField] float RiseSpeed = 1f;
    [SerializeField] bool PlayerOnPlat = false;

    void Start()
    {
        StartPosition = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerOnPlat = true;
            //StartCoroutine(MonteePlat());
        }
        else
        {
            PlayerOnPlat = false;
        }
    }

    void Update()
    {
        if (PlayerOnPlat)
        {
            // Si le joueur est sur la plateforme, elle descend
            StartCoroutine(Fall());
        }
        else if (transform.position.y <= StartPosition)
        {
            //Sinon elle monte
            StartCoroutine(MonteePlat());
        }
    }

    IEnumerator Fall() // Descente
    {
        yield return new WaitForSeconds(fallDelay);
        rigidbodyPlat.bodyType = RigidbodyType2D.Dynamic;
    }


    IEnumerator MonteePlat() // Monter de plateforme
    {
        while (transform.position.y < StartPosition)
        {
            if (PlayerOnPlat)
            {
                PlayerOnPlat = true;
                break;
            }

            rigidbodyPlat.velocity = new Vector2(0, RiseSpeed);
            yield return null;
        }
    }
}







//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FallingPlatform : MonoBehaviour
//{
//    [Header("Set the falling and rising speed of the platform.")]
//    private float startPos;
//    private Rigidbody2D rb;
//    [SerializeField] float fallSpeed = 2.5f;
//    [SerializeField] float riseSpeed = 1.5f;

//    [Header("[Debug purposes] Booleans")]
//    [SerializeField] bool isRising = false;
//    [SerializeField] bool playerOnPlatform = false;

//    private void Start()
//    {
//        startPos = transform.position.y;
//        Debug.Log(startPos);
//        rb = GetComponent<Rigidbody2D>();
//        rb.gravityScale = 0;
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            playerOnPlatform = true;
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            playerOnPlatform = false;
//        }
//    }

//    private void Update()
//    {
//        if (playerOnPlatform)
//        {
//            // Si le joueur est sur la plateforme, elle descend
//            rb.velocity = new Vector2(0, -fallSpeed);
//        }
//        else if (!isRising && transform.position.y <= startPos)
//        {
//            // La plateforme remonte
//            isRising = true;
//            StartCoroutine(RisePlatform());
//        }
//    }

//    private IEnumerator RisePlatform()
//    {
//        while (transform.position.y < startPos)
//        {
//            if (playerOnPlatform)
//            {
//                isRising = false; // Annuler la remont�e
//                yield break; // Sortir de la coroutine
//            }

//            rb.velocity = new Vector2(0, riseSpeed);
//            yield return null;
//        }

//        rb.velocity = Vector2.zero;
//        isRising = false;
//    }
//}