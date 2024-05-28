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
    Animator animator;
    [SerializeField] SpriteRenderer SpriteRenderer;
    public ParticleSystem TrailGround;

    //------------------ISGROUNDED------------
    [SerializeField] Transform GroundCheck1;
    [SerializeField] LayerMask Ground;
    //------------------ISGROUNDED------------

    private float horizontal;
    private bool isFacingRight = true;

    //------------------JUMP-----------------
    [SerializeField] float JumpHight = 6f;
    [SerializeField] float gravityScale = 10;
    [SerializeField] float fallingGravityScale = 40;
    //------------------JUMP-----------------

    //------------------ROULADE--------------
    [SerializeField] float rouladeVitesse = 10000f;
    //------------------ROULADE--------------

    public bool canMoove;
    public bool canJump;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); //recover the player's rigidbody
        canMoove = true;
        canJump = true;

        animator = GetComponent<Animator>();
        animator.SetBool("walk", false);
    }

    void Update()
    {

        //if (/*grounded false = arreter lecture anim marche*/)
        //{
        //    animator.SetBool("walk", false);
        //}

        Roulade();

        if (canMoove == false) 
        {
            rigidbody.velocity = Vector2.zero;
            animator.SetBool("walk", false);
        }
        else
        {
            rigidbody.velocity = new Vector2(horizontal * mouvement_speed, rigidbody.velocity.y);
        }

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
        CreateTrailGround();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //------------------------JUMP----------------------
        if (context.performed && isgrounded() && canJump == true) // performs the jump and check isgrounded
        {
            StartCoroutine(jumpScript());
        }
    }
    IEnumerator jumpScript()
    {
        //Wait for 0.2 seconds
        yield return new WaitForSeconds(0f);

        audioManager.PlaySFX(audioManager.JumpSound);
        rigidbody.AddForce(Vector2.up * JumpHight, ForceMode2D.Impulse);

        CreateTrailGround();

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
        if (canMoove == true)
        {
            animator.SetBool("walk", true);
            //play sound for walk
            horizontal = context.ReadValue<Vector2>().x;
        }
        if (context.canceled)
        {
            animator.SetBool("walk", false);
        }
    }

        public void Roulade()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && isgrounded())
        {
            Debug.Log("Roulade bam !");
            //rigidbody.velocity = Vector2.right * (rouladeVitesse/ 1.8f);              //MARCHE MAIS TP
            rigidbody.AddForce(Vector2.right * rouladeVitesse);                         //LE PLUS SATISFAISANT MAIS TP AUSSI
        }
    }

    void CreateTrailGround()
    {
        TrailGround.Play();
    }
}