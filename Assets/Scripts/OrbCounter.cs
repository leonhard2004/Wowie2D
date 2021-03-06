﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCounter : MonoBehaviour
{
    private int gesamtOrbs = 0;
    private int gefundeneOrbs = 0;
    public GameObject player;
    public AudioSource pickupsound;
    public void addOrb()
    {
        gesamtOrbs++;
        
    }
    public void orbCollected()
    {
        Debug.Log("Orb aufgenommen");
        gefundeneOrbs++;
        pickupsound.Play();
        if (gefundeneOrbs == gesamtOrbs)
        {
            Debug.Log("allOrbscollected");
            player.GetComponent<LevelComplete>().LevelCompleted();
        }
    }
    private void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = gefundeneOrbs + "/" + gesamtOrbs;
    }
}
