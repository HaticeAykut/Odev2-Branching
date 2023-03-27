using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class characterController2 : MonoBehaviour
{
    public float jumpForce = 2.0f; 
    public float speed = 1.0f;
    float moveDirection;

    public bool jump;
    private bool grounded = true;
    public bool moving;
    public Rigidbody2D _rigidbody2D;
    public SpriteRenderer _spriteRenderer;
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);
        
       
        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }
        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
        }
    }
     private void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("zemin"))
        {
            grounded = true;
        }
    }
}

