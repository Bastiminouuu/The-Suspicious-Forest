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

    public var top_left : Transform;
    public var bottom_right : Transform;
    public var Ground : LayerMask;

    private float horizontal;
    private bool isFacingRight = true;
    private float rouladeVitesse = 4f;

    //------------------JUMP-----------------
    [SerializeField] float JumpHight = 6f;
    [SerializeField] float gravityScale = 10;
    [SerializeField] float fallingGravityScale = 40;
    //------------------JUMP-----------------


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


    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, Ground);
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
            IsGrounded = true;
            rigidbody.gravityScale = 1f;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("ground"))
        {
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
            if (IsGrounded == true && IsJumpPress == true)
            {
                //if (Input.GetKey(KeyCode.LeftArrow))
                //{
                //    transform.Translate(Vector3.left * 8f * Time.deltaTime); ; //translate rebond
                //}
                //else
                //{
                //    transform.Translate(Vector3.right * 8f * Time.deltaTime); ; //translate rebond
                //}
                StartCoroutine(jumpScript());
            }
        }

        IEnumerator jumpScript()
        {
            //Wait for 0.2 seconds
            yield return new WaitForSeconds(0f);

            rigidbody.AddForce(Vector2.up * JumpHight, ForceMode2D.Impulse);
            //rigidbody.velocity = Vector2.up * 6f; // jump

            if (rigidbody.velocity.y >= 0)
            {
                rigidbody.gravityScale = gravityScale;
            }
            else if (rigidbody.velocity.y < 0)
            {
                rigidbody.gravityScale = fallingGravityScale;
            }

            IsJumpPress = false;
        }

        //------------------------JUMP----------------------
    }

    public void HorizontalMoove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Roulade(InputAction.CallbackContext context) 
    {
        if (context.performed && IsGrounded == true)
        {
            rigidbody.velocity = Vector2.right * rouladeVitesse; // roulade
        }
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