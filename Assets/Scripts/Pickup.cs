using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] public GameObject orb;
    [SerializeField] public OrbCounter orbCounter;

    private void Awake()
    {
        orbCounter.addOrb();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            orbCounter.orbCollected();
            orb.gameObject.SetActive(false);
        }

    }
}
