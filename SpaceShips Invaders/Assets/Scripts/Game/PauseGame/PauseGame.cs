using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool gameIsPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseTheGame();
        }
    }
    void PauseTheGame()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            Camera.main.GetComponent<AudioSource>().Pause();
        }
        else 
        {
            Time.timeScale = 1;
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
}
