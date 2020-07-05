using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    private float moveSpeed;
    public float walkSpeed = 15f;
    public float sprintSpeed = 35f;
    public float jumpSpeed = 5f;
    public const int maxJump = 2;
    private int currentJump = 0;
    private float rayCastDistance = 0.3f;
    public LayerMask layerMask;
    public UnityEvent onEscButton;
    //public float dashForce = 20f;
    //public float duration = 5f;
    // public float stamina;

    //public float stimSpeed = 12f;
    //private bool stimOn = false;
    //private float timerCountDown = 5;
    //private bool isCountingDown = false;
    //public float coolDown = 5;
    //public float coolDownTimer;
    //public float doubleV = 0.5f;
    //private bool Sliding = false;

    private new Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
   
    private void Update()
    {

        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector3 moveDir = vert * transform.forward + hor * transform.right;

        rigidbody.MovePosition(transform.position + moveDir.normalized * Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown("space"))
        {
            Jumping();
        }

        JumpReset();
        Movement();

        if (Input.GetKey("escape"))
        {
            onEscButton?.Invoke();
        }
 
    }

    private bool IsGrounded() //checkt of de speler op de grond is
    {
        //Debug.Log("raken");
        return Physics.Raycast(transform.position + new Vector3(0,0.1f,0), -Vector3.up, rayCastDistance, layerMask);
        
    }

    private void Jumping()
    {
        if (maxJump > currentJump)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpSpeed, rigidbody.velocity.z);
            currentJump++;
        }
    }

    private void JumpReset()
    {
        if (IsGrounded())
        {
            currentJump = 0;
        }
    }

    private void Movement()
    {
       
        //Timer();

        if (!Input.GetKey("e"))
        {
            //Debug.Log("lopend");
             Walking();
           
        } else {

            //Debug.Log("sprinten");
            Sprinting();
       }


    }
    private void Walking()
    {
        //if (IsGrounded())
        
            moveSpeed = walkSpeed;
        
    }

    private void Sprinting()
    {
        //if (IsGrounded())
        
            moveSpeed = sprintSpeed;
        
    }

    //private float Timer()
    //{
    //  float t = 0;
    //stamina = t;

    //while (t < 1)
    //{
    //  t += Time.deltaTime;
    //}

    //return stamina;
    //}

    //public void PlayerDeath()
    //{
    //  PlayerPosReset();
    //hier kan een deathmessage
    //}

    //private void PlayerPosReset()
    //{

    //}

    //private void Dash()
    //{
    //transform.position += transform.forward * dashForce * Time.deltaTime;
    //rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);

    //}

    //private void Stim()
    //{
    //  if (!stimOn){
    //    float i = 10;
    //  while (i > 1)
    //      {
    //        i -= Time.deltaTime;
    //      Debug.Log("Stim is aan");
    //    moveSpeed = moveSpeed * 1 / doubleV;
    //   stimOn = true;
    //}
    //}

    //StartCoroutine(StimCorout(duration));
    //}

    //IEnumerator StimCorout(float duration)
    //{
    //  Debug.Log("HOiiiii");
    //moveSpeed = moveSpeed * 1 / doubleV;
    //    yield return new WaitForSeconds(duration);

    //}

    //Dit is Stim - Werkt nog niet

    //if (Input.GetKeyDown("e"))
    //{
    //    moveSpeed = moveSpeed *= 2;
    //  jumpSpeed = jumpSpeed *= 2;
    //}
    //else { jumpSpeed = jumpSpeed * 1; }

    //Dit is Dash
    //if (Input.GetKeyDown("q"))
    //{
    //   // rigidbody.velocity = new Vector3(dashForce, rigidbody.velocity.y, rigidbody.velocity.z);
    //}

    //Dit is Sliden
    //if (Input.GetKey("c"))
    //{
    //    Debug.Log("ImSliding");
    //}
    // if(coolDownTimer > 0)
    //  {
    //     coolDownTimer -= Time.deltaTime;
    //}

    // if(coolDownTimer< 0)
    //{
    //  coolDownTimer = 0;
    //}

    //if(Input.GetKey("i") && coolDownTimer == 0)
    //{
    //  Debug.Log("lekker bezig");
    //coolDownTimer = coolDown;
    //}
    // private void Stim()
    //{
    //  while (Timer() == true)
    //{
    //  moveSpeed += 2;
    //jumpSpeed += 2;

    //   }
    //}

    //private bool Timer()
    //{
    //  if (timerCountDown > 0)
    //{
    //  timerCountDown -= Time.deltaTime;
    //isCountingDown = true;
    //}

    //if (timerCountDown < 0)
    //{

    //}

    //return isCountingDown;
    //}
}