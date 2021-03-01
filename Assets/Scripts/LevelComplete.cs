using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject LevelCompleteMenu;
    
    public Pause pause;
    public void LevelCompleted()
    {
        Debug.Log("LevelCompleted");
        pause.PauseGame();
        LevelCompleteMenu.SetActive(true);
    }
 
}
