using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;//скорость движения
    [SerializeField] private int lives = 5;//количество жизней;
    [SerializeField] private float jumpForce = 15f; //сила прыжка;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public bool isGrounded = false;
    public float rayDistance = 0.6f;
    private Animator anim;

    private States State
    {
        get{ return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
        
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (isGrounded)
        {
            State = States.idle;
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
        }
    }
    
    private void Run()
    {
        if (isGrounded) State = States.run;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        State = States.jump;
    }
}

public enum States
{
    idle,
    run,
    jump
}
