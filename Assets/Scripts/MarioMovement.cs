using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MarioMovement : MonoBehaviour
{

    public Vector2 velocity;
    private bool walk, walk_left, walk_right, jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        UpdatePlayerPosition();
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
        
        if( dirx == 1)
        {
            walk = true;
            walk_right = true;
            walk_left = false;
        }
        else if (dirx == -1 )
        {
            walk = true;
            walk_left = true;
            walk_right = false;
        }
        else if(dirx == 0)
        {
            walk = false;
            walk_left = false;
            walk_right = false;
        }
        Debug.Log(walk + " " + walk_left + " " + walk_right +" "+ dirx);
    }

    public void OnJump(InputValue value)
    {
        float jumping = value.Get<float>();
        
        if (jumping == 1)
        {
            jump = true;
        }
        if (jumping != 1)
        {
            jump = false;
        }
        
    }
}
