using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Pause : MonoBehaviour
{
    bool paused = false;
    public GameObject pauseMenu;

    public void OnPause()
    {
        paused = !paused;
    }
    private void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
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
