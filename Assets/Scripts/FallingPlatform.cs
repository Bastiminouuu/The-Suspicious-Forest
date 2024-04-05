using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float startPos;
    private Rigidbody2D rb;
    [SerializeField] float fallSpeed = 2.5f;
    [SerializeField] float riseSpeed = 1.5f;
    [SerializeField] bool isRising = false;
    [SerializeField] bool playerOnPlatform = false;

    private void Start()
    {
        startPos = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    private void Update()
    {
        if (playerOnPlatform)
        {
            rb.velocity = new Vector2(0, -fallSpeed);
        }
        else if (!isRising && transform.position.y <= startPos)
        {
            // La plateforme remonte
            isRising = true;
            StartCoroutine(RisePlatform());
        }
    }

    private IEnumerator RisePlatform()
    {
        while (transform.position.y < startPos)
        {
            if (playerOnPlatform)
            {
                isRising = false; // Annuler la remont�e
                yield break; // Sortir de la coroutine
            }

            rb.velocity = new Vector2(0, riseSpeed);
            yield return null;
        }

        rb.velocity = Vector2.zero;
        isRising = false;
    }
}