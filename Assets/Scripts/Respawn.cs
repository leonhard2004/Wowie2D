using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public GameObject respawnPoint;
    [SerializeField] public AudioSource playerHitSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("respawn");
            StartCoroutine(respawner());


        }
        
    }
    IEnumerator respawner()
    {
        playerHitSound.Play();
        player.GetComponent<MarioMovement>().StopMoving();
        
        yield return new WaitForSecondsRealtime(1);
        //TODO: respawnAnimation
        player.transform.position = respawnPoint.transform.position;
        player.GetComponent<MarioMovement>().StartMoving();
    }
}
