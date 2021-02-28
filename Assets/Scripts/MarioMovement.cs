﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MarioMovement : MonoBehaviour
{

    public Vector2 velocity;
    private bool walk, walk_left, walk_right, jump;
    /*these floats are the force you use to jump, the max time you want your jump to be allowed to happen,
    * and a counter to track how long you have been jumping*/
    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;
    /*this bool is to tell us whether you are on the ground or not
     * the layermask lets you select a layer to be ground; you will need to create a layer named ground(or whatever you like) and assign your
     * ground objects to this layer.
     * The stoppedJumping bool lets us track when the player stops jumping.*/
    public bool grounded;
    public LayerMask whatIsGround;
    public bool stoppedJumping;

    /*the public transform is how you will detect whether we are touching the ground.
     * Add an empty game object as a child of your player and position it at your feet, where you touch the ground.
     * the float groundCheckRadius allows you to set a radius for the groundCheck, to adjust the way you interact with the ground*/

    public Transform groundCheck;
    public float groundCheckRadius;

    //You will need a rigidbody to apply forces for jumping, in this case I am using Rigidbody 2D because we are trying to emulate Mario :)
    private Rigidbody2D rb;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //determines whether our bool, grounded, is true or false by seeing if our groundcheck overlaps something on the ground layer
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //if we are grounded...
        if (grounded)
        {
            //the jumpcounter is whatever we set jumptime to in the editor.
            jumpTimeCounter = jumpTime;
        }

        UpdatePlayerPosition();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            //I placed this code in FixedUpdate because we are using phyics to move.

            //if you press down the mouse button...
            if (jump)
            {
                //and you are on the ground...
                if (grounded)
                {
                    //jump!
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    stoppedJumping = false;
                    
                }
            }

            //if you keep holding down the mouse button...
            if (jump && !stoppedJumping)
            {
                //and your counter hasn't reached zero...
                if (jumpTimeCounter > 0)
                {
                    //keep jumping!
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else if(jumpTimeCounter <= 0)
                {
                    jump = false;
                }
            }


            //if you stop holding down the mouse button...
            if (!jump)
            {
                //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
                jumpTimeCounter = 0;
                stoppedJumping = true;
            }
        }
    }

    void UpdatePlayerPosition()
    {
        Vector3 pos = transform.localPosition;
        Vector3 scale = transform.localScale;

        if (walk)
        {
            if (walk_left)
            {
                pos.x -= velocity.x * Time.deltaTime;

                scale.x = -1;
            }
            if (walk_right)
            {
                pos.x += velocity.x * Time.deltaTime;

                scale.x = 1;
            }

        }

        transform.localPosition = pos;
        transform.localScale = scale;
    }
    public void OnMovement(InputValue value)
    {
        float dirx = value.Get<float>();

        if (dirx == 1)
        {
            walk = true;
            walk_right = true;
            walk_left = false;
        }
        else if (dirx == -1)
        {
            walk = true;
            walk_left = true;
            walk_right = false;
        }
        else if (dirx == 0)
        {
            walk = false;
            walk_left = false;
            walk_right = false;
        }
        Debug.Log(walk + " " + walk_left + " " + walk_right + " " + dirx);
    }

    public void OnJump(InputValue value)
    {
        float jumping = value.Get<float>();

        if (jumping == 1 && grounded)
        {
            jump = true;
        }
        if (jumping != 1)
        {
            jump = false;
        }

    }

    public void StopMoving()
    {
        canMove = false;
        rb.velocity = new Vector3(0, 0, 0);
    }
    public void StartMoving()
    {
        canMove = true;
    }
}
