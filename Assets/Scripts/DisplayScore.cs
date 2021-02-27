using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Update()
    {
        this.GetComponent<Text>().text = AttackCollider.score.ToString();
        
    }
}
