using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvement : MonoBehaviour

//definition of speed adjustment fields + creation of player booleans
{
    [SerializeField] float mouvement_speed = 5f;
    [SerializeField] private new Rigidbody2D rigidbody;
    //[SerializeField] Animator Player_Animator; // get animation player
    //[SerializeField] SpriteRenderer SpriteRenderer;
    //bool Player_walk;


    //------------------ISGROUNDED------------
    [SerializeField] Transform GroundCheck1;
    [SerializeField] LayerMask Ground;
    [SerializeField] bool IsGrounded;
    //------------------ISGROUNDED------------

    private float horizontal;
    private bool isFacingRight = true;
    private float rouladeVitesse = 80f;

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

    //------------------ISGROUNDED------------
    private bool isgrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck1.position, 0.2f, Ground);
    }
    //------------------ISGROUNDED------------


    private void Flip() 
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //------------------------JUMP----------------------
        if (context.performed && isgrounded()) // performs the jump and check isgrounded
        {
            StartCoroutine(jumpScript());
        }
    }
    IEnumerator jumpScript()
    {
        //Wait for 0.2 seconds
        yield return new WaitForSeconds(0f);

        rigidbody.AddForce(Vector2.up * JumpHight, ForceMode2D.Impulse);

        if (rigidbody.velocity.y >= 0)
        {
            rigidbody.gravityScale = gravityScale;
        }
        else if (rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = fallingGravityScale;
        }
    }
    //------------------------JUMP----------------------

    public void HorizontalMoove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Roulade(InputAction.CallbackContext context) 
    {
        if (context.performed && isgrounded())
        {
            Debug.Log("roulade");
            //rigidbody.velocity = Vector2.right * 100f;
            //transform.Translate(Vector2.right * 20f * Time.deltaTime);
            rigidbody.AddForce(Vector2.right * /*1500f*/ mouvement_speed);
        }
    }
}