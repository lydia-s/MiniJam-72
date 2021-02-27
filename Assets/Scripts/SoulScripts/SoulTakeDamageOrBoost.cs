using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoulTakeDamageOrBoost
{
    public static void TakeBoostOrDamage(int changeScore){
        AttackCollider.score+=changeScore;
    }
    public static void TakeBoostOrDamage(int changeScore, int multiplier){
        AttackCollider.score+=changeScore*multiplier;
    }
}
