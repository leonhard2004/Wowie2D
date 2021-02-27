using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputController controls;
    public float speed = 3f;
    public float maxspeed = 10;
    public float jumpforce = 200;
    public int jumplimit = 2;
    int timesJumped = 0;
    Rigidbody2D rb;
    
    float dirx;
   
    private void OnEnable()
    {        
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
         Move(dirx);    
    }
 
    public void Move(float x)
    {        
        float moveBy = x * speed;
        rb.AddForce(new Vector2(moveBy - rb.velocity.x, 0));        
    }
    public void Jump(float jump)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0,jumpforce*jump));
        Debug.Log("jump "+jump);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            timesJumped = 0;
        }
        
        
    }
   public void OnMovement(InputValue value)
    {
        Debug.Log("moving");
        dirx = value.Get<float>();
        Debug.Log("dirx: " + dirx);
    }

    public void OnJump(InputValue value)
    {        
        float jump = value.Get<float>();
        Debug.Log("button value " + jump);
        if (timesJumped < jumplimit && jump != 0 && rb.velocity.y == 0)
        {
            Jump(jump);
            timesJumped++;
            Debug.Log("jumps: " + timesJumped);
            Debug.Log("Jumped");           
        }
        else if (timesJumped <= (jumplimit-1) && jump != 0)
        {
            Jump(jump);
            timesJumped = jumplimit;
            Debug.Log("jumps: " + timesJumped);
            Debug.Log("doubleJumped");            
        }       

    }
    
}
