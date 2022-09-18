using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("ForestFase");
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadTutorial(){
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame(){
        Application.Quit();
    }

}
