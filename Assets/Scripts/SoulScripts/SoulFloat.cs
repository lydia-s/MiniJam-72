using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFloat : MonoBehaviour
{
    Vector3 direction;
    float distance;
    float time = 50f;//seconds
    float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight=SpawnSouls.height;
        Vector3 target = new Vector3(transform.position.x,screenHeight, 0);
        direction =target - transform.position;
        distance = screenHeight;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (Time.deltaTime*(distance/time)));
        if(this.transform.position.y>=screenHeight){
            Destroy(gameObject);

        }
        
    }
}
