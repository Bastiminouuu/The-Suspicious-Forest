using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private float horizontal;
    private bool isFacingRight = true;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); //recover the player's rigidbody
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(horizontal * mouvement_speed, rigidbody.velocity.y);

        if (!isFacingRight && horizontal > 0f) 
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f) 
        {
            Flip();
        }
    }

    private void Flip() 
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
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


    public void Jump(InputAction.CallbackContext context)
    {
        //------------------------JUMP----------------------
        if (context.performed) // performs the jump by pressing up arrow
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
                StartCoroutine(jumpScript());
            }
        }

        IEnumerator jumpScript()
        {
            //Wait for 0.2 seconds
            Debug.Log("wait 0.2s");
            yield return new WaitForSeconds(0.2f);

            rigidbody.velocity = Vector2.up * 6f; // jump

            IsJumpPress = false;
            Debug.Log("Jump Inactif");
        }

        //------------------------JUMP----------------------
    }

    public void HorizontalMoove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

}










//------------------------LEFT----------------------
//if (context.performed) // move to the left with animation
//{
//    if (IsGrounded == true && Input.GetKeyDown(KeyCode.Keypad1)) // roulade
//    {
//        rigidbody.velocity = Vector2.left * 4f; // roulade
//    }
//}
//------------------------LEFT----------------------

//------------------------RIGHT-----------------------
//if (context.performed) // move to the right with animation
//{
//    if (IsGrounded == true && Input.GetKeyDown(KeyCode.Keypad1)) // roulade
//    {
//        rigidbody.velocity = Vector2.right * 4f; // roulade
//    }

//    horizontal = context.ReadValue<Vector2>().x;
//    //transform.Translate(Vector3.right * mouvement_speed * Time.deltaTime);
//}
//------------------------RIGHT-----------------------