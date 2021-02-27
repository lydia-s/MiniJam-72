using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTutorial : MonoBehaviour
{
    public GameObject up;
    public GameObject left;
    public GameObject down;
    public GameObject right;
    public GameObject attack;
    
    // Start is called before the first frame update
    void Start()
    {

        up.GetComponent<Animator>().Play("front_walk");
        left.GetComponent<Animator>().Play("side_walk");
        down.GetComponent<Animator>().Play("down_walk");
        right.GetComponent<Animator>().Play("side_walk");
        attack.GetComponent<Animator>().Play("front_attack");
        

        
    }
}
