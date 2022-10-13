using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump = true;
    int groundMask = 1<<8; // this is a “bitshift”
    
    bool isIdle;
    public static bool isLeft;
    int isIdleKey = Animator.StringToHash("isidle");
    int isJumpKey = Animator.StringToHash("isJump");

    public int playerSpeed = 25;//change player movement speed.
    public int playerJumpHeight = 25;//change jump height

    // reference - Better Jumping in Unity With Four Lines of Code - https://www.youtube.com/watch?v=7KiK0Aqtmzc
    public float fallMultiplier = 2.5f;


    //speed boost variables
    public int speedBoost;
    public float boosttimer;
    public bool boosting;

    

    void Start()
    {
        speedBoost = 20;
        boosttimer = 0;
        boosting = false;
    }


    // Update is called once per frame
    void Update()
    {
    
        if(boosting){
            boosttimer += Time.deltaTime;
            if(boosttimer >= 3){//boost time length
                playerSpeed -= speedBoost;
                boosttimer = 0;
                boosting =false;
            }
        }
        Animator a = GetComponent<Animator>();
        a.SetBool(isIdleKey, isIdle);
        a.SetBool(isJumpKey, !canJump);

        //FLIP Character
        //SpriteRenderer r = GetComponent<SpriteRenderer>();
        //r.flipX = isLeft;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "speedboost"){
            boosting = true;
            playerSpeed += speedBoost;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        isIdle = true;
        

        //Movement mechanics reference - COMP4002 - Lab 02 - Platformer
        // the new velocity to apply to the character
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();

        //new character flip
        Vector3 characterScale = transform.localScale;

        // reference - Better Jumping in Unity With Four Lines of Code - https://www.youtube.com/watch?v=7KiK0Aqtmzc
        if (r.velocity.y < 0){
            r.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } 


        // move to the left
        if (Input.GetKey(KeyCode.A))
        {
            physicsVelocity.x -= playerSpeed;
            isIdle = false;
            characterScale.x = -1;
            isLeft = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            physicsVelocity.x += playerSpeed;
            isIdle = false;
            characterScale.x = 1;
            isLeft = false;
        }
        transform.localScale = characterScale;

        // implement moving to the right for the D key
        // this allows the player to jump, but only if canJump is true
        if (Input.GetKey(KeyCode.W))
        {
            if (canJump)
            {
                // we're setting the absolute velocity here
                // but we still want to carry on moving left
                // or right. So include the current horizontal
                // velocity
                r.velocity = new Vector2(physicsVelocity.x, playerJumpHeight);
                
                canJump = false;
            }
        }


        // Test the ground immediately below the Player
        // and if it tagged as a Ground layer, then we allow the
        // Player to jump again. The capsule collider is 4.8 units
        // high, so 2.5 units “down” from its centre will be just
        // touching the floor when we are on the ground.
        if (Physics2D.Raycast(new Vector2
        (transform.position.x,
        transform.position.y),
        -Vector2.up, 2.5f, groundMask))
        {
            canJump = true;
        }
        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(physicsVelocity.x,
        r.velocity.y);
        }
    }
