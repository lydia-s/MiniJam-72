using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    float startTime = 90;
    public static float timeRemaining;
    float colourTransitionTime = 1f; 
    public Text timer;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining=startTime;
        timer.text = startTime.ToString();
        StartCoroutine(TransitionColour());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            timer.text=Mathf.Round(timeRemaining).ToString();
           
        }
        else{
            PlayerPrefs.SetInt("finalScore", AttackCollider.score);
            SceneManager.LoadScene("GameOver");
        }
    }
    public void ColourChange(){
        int multiplier =15;
        Color col = background.GetComponent<SpriteRenderer>().color;
        float a = col.a;
        float r = col.r+(col.r/(timeRemaining*multiplier));
        float b = col.b +(col.b/(timeRemaining*multiplier));
        float g = col.g +(col.g/(timeRemaining*multiplier));
        col = new Color(r,g, b,a);
        background.GetComponent<SpriteRenderer>().color = col;
        //Debug.Log(col);
    }
    IEnumerator TransitionColour(){
        while(true){
            yield return new WaitForSeconds(colourTransitionTime);
            ColourChange();
            
        }

    }
}
