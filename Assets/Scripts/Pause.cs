using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Pause : MonoBehaviour
{
    bool paused = false;
    bool gameEnded = false;
    public GameObject pauseMenu;

    public void OnPause()
    {
        paused = !paused;
        pauseMenu.SetActive(paused);
    }

    public void PauseGame()
    {
        gameEnded = true;
    }
    private void Update()
    {
        if (gameEnded)
        {
            paused = true;
        }
        if (paused)
        {
            Time.timeScale = 0;
           
        }
        else
        {
            Time.timeScale = 1;
            
        }
    }

    private void OnGUI()
    {
        if (paused)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Paused");
        }
    }


}
