using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public bool respawning = true;
 //   private void OnCollisionEnter2D(Collision2D collision)
 //   {
 //       if(collision.gameObject.tag == "damage")
   //     {
     //       respawning = true;
     //   }
     //   if (collision.gameObject.tag == "ground")
     //   {
     //       respawning = false;
     //   }
//    }

    // Update is called once per frame
    void Update()
    {
        if(respawning == true)
        {
            PlayerMovement playermovement = GetComponent<PlayerMovement>();
            playermovement.enabled = false;
        }
        else
        {
            PlayerMovement playermovement = GetComponent<PlayerMovement>();
            playermovement.enabled = true;
        }
    }
}
