using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouvement : MonoBehaviour

//definition of speed adjustment fields + creation of player booleans
{
    [SerializeField] float mouvement_speed = 5f; // value accessible directly from the unity interface
    [SerializeField] private new Rigidbody2D rigidbody;
    /*[SerializeField] Animator Player_Animator; // get animation player
    bool Player_Roulade;
    bool Player_Jump;
    bool Player_Attack;
    [SerializeField] SpriteRenderer SpriteRenderer; */
    [SerializeField] bool IsGrounded;
    [SerializeField] bool IsJumpPress;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); //recover the player's rigidbody
    }

    void Update()
    {

        Movement();

    }




    //------------------------ISGROUNDED----------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("ground"))
        {
            Debug.Log("au sol");
            IsGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("ground"))
        {
            Debug.Log("en l'air");
            IsGrounded = false;
        }
    }
    //------------------------ISGROUNDED----------------------
 

    private void Movement()
    {

         //------------------------JUMP----------------------
         if (Input.GetKeyDown(KeyCode.UpArrow)) // performs the jump by pressing up arrow
         {
            IsJumpPress = true;
            Debug.Log("Jump actif");
            if (IsGrounded == true && IsJumpPress == true)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(Vector3.left * 8f * Time.deltaTime); ; //translate rebond
                }
                else
                {
                    transform.Translate(Vector3.right * 8f * Time.deltaTime); ; //translate rebond
                }
                StartCoroutine(jump());
            }
        }

        IEnumerator jump()
        {
            //Wait for 0.2 seconds
            Debug.Log("wait 0.2s");
            yield return new WaitForSeconds(0.2f);

            rigidbody.velocity = Vector2.up * 6f; // jump

            IsJumpPress = false;
            Debug.Log("Jump Inactif");
        }

        //------------------------JUMP----------------------


        //------------------------LEFT----------------------
        if (Input.GetKey(KeyCode.LeftArrow)) // move to the left with animation
         {
            if (IsGrounded == true && Input.GetKeyDown(KeyCode.Keypad1)) // roulade
            {
                rigidbody.velocity = Vector2.left * 4f; // roulade
            }

            transform.Translate(Vector3.left * mouvement_speed * Time.deltaTime);
        }
        //------------------------LEFT----------------------


        //------------------------RIGHT-----------------------
        else if (Input.GetKey(KeyCode.RightArrow)) // move to the right with animation
        {
            if (IsGrounded == true && Input.GetKeyDown(KeyCode.Keypad1)) // roulade
            {
                rigidbody.velocity = Vector2.right * 4f; // roulade
            }

            transform.Translate(Vector3.right * mouvement_speed * Time.deltaTime);
        }
        //------------------------RIGHT-----------------------

    }

}