using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject LevelCompleteMenu;
    public void LevelCompleted()
    {
        Debug.Log("LevelCompleted");
        Time.timeScale = 0;
        LevelCompleteMenu.SetActive(true);
    }
}
