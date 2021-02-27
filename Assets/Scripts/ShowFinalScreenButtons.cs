using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFinalScreenButtons : MonoBehaviour
{
    public GameObject fadeScreen;
    public GameObject choiceButtons;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AfterTransition());
    }

    IEnumerator AfterTransition(){
        yield return new WaitForSeconds(3f);
        choiceButtons.SetActive(true);
        fadeScreen.SetActive(false);

    }
}
