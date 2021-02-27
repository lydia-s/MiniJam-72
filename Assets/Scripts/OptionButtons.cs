using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionButtons : MonoBehaviour
{
    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void StartGame(){
        SceneManager.LoadScene("Game");
    }
    public void Quit(){
        Application.Quit();
    }
}
