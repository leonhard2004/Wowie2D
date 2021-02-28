using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeText : MonoBehaviour
{
    public float timeRemaining = 10;
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("time is up");
        }
    }
}
