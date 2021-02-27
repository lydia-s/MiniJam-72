using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackCollider : MonoBehaviour
{
    bool isTouching=false;
    public static int score;
    GameObject currentSoul;
    public GameObject multiplierObj;
    public float lastSoulCaughtTime;
    public bool firstSoul=true;
    public float multiplierTime = 2f;
    void Start(){
        score=0;

    }
     private void OnTriggerEnter2D(Collider2D soul)
    {
        if(soul.name=="bad_soul"){
            SoulTakeDamageOrBoost.TakeBoostOrDamage(-3);
            this.gameObject.GetComponent<Animator>().Play("damage");
            this.gameObject.GetComponent<AudioSource>().Play();
            return;
        } 
        isTouching=true;
        currentSoul=soul.gameObject;
        //Debug.Log("trigger entered");
        
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isTouching=false;
        currentSoul=null;
        
    }
    float timeMultiplier=0;
    int soulsReaped = 0;
    // Update is called once per frame
    void Update()
    {
        
      if(Keyboard.current.spaceKey.wasPressedThisFrame && currentSoul!=null && isTouching){
           AudioSource audioSource = currentSoul.GetComponent<AudioSource>();
           //audioSource.pitch = (Random.Range(0.8f, 1f));
           audioSource.Play();

           // Debug.Log("collected");
           StartCoroutine(SoulDestroy(currentSoul));
           
           
        }  
    }

    public void PlayMultiplierAnimation(){
        multiplierObj.SetActive(true);
        AudioSource audioSource = multiplierObj.GetComponent<AudioSource>();
        //audioSource.pitch = (Random.Range(0.9f, 1f));
        audioSource.Play();
        multiplierObj.GetComponent<Animator>().Play("pop_up");
        // multiplierObj.GetComponent<AudioSource>().Play();
        
    }
    
    public float TimeDifference(){
        Debug.Log(lastSoulCaughtTime-Timer.timeRemaining);
        return lastSoulCaughtTime-Timer.timeRemaining;
    }
    public int MultiplierLogic(){
        
        Debug.Log("Destroy!");
        if(TimeDifference()<multiplierTime && !firstSoul){//if you catch 2 souls in under x seconds
            
            PlayMultiplierAnimation();
            
            return 2;
        }
        return 1;
    }
    public IEnumerator SoulDestroy(GameObject soul){
        int multiplier=MultiplierLogic();//base multiplier
        firstSoul=false;
        lastSoulCaughtTime=Timer.timeRemaining;
        soul.GetComponent<Animator>().Play("soul_destroy");
        yield return new WaitForSeconds(0.5f);
        soulsReaped++;
        if(soul.name=="blue_soul"){
            SoulTakeDamageOrBoost.TakeBoostOrDamage(1,multiplier);

        }else{
            SoulTakeDamageOrBoost.TakeBoostOrDamage(3,multiplier);
        }
        Destroy(soul);
        currentSoul=null;
    }
}
