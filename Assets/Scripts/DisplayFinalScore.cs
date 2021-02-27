using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    public Text finalScoreTxt;
    public Text highscoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("finalScore");
        finalScoreTxt.text = finalScore.ToString();
        if(finalScore>PlayerPrefs.GetInt("highScore")){
            PlayerPrefs.SetInt("highScore", finalScore);
        }
        highscoreTxt.text = PlayerPrefs.GetInt("highScore").ToString();

    }

}
