using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSouls : MonoBehaviour
{
    public GameObject background;
    public GameObject goldSoul;
    public GameObject blueSoul;
    public GameObject badSoul;
    float spawnPosY;
    float spawnPosX;
    float width;
    public static float height;
    public float spawnRate = 1f;

    void Start(){
       width = background.GetComponent<SpriteRenderer>().size.x/2;
       height = background.GetComponent<SpriteRenderer>().size.y/2;
       Debug.Log(width);
       StartCoroutine(SpawnSoul());
       
    }
    public IEnumerator SpawnSoul(){
        while(true){
            yield return new WaitForSeconds(spawnRate);
            spawnPosX = Random.Range(-width, width);
            spawnPosY = -height;
            Vector2 spawnPos = new Vector2(spawnPosX, spawnPosY);
            GameObject soul = ReturnRandomSoul();
            GameObject go = Instantiate(soul, spawnPos, Quaternion.identity);
            go.name = soul.name;

            //Debug.Log(spawnPos);
        }
    }

    public GameObject ReturnRandomSoul(){
      int chance = Random.Range(0,9);

      if(chance==8){
          return goldSoul;
      }
      else if(chance>=6){
          return badSoul;
      }
      else{
          return blueSoul;
      }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
