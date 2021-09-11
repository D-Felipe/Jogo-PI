using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreController 
{
    private const string moneyName = "moneyName";
    public static void saveMoney(int money){
        if(PlayerPrefs.HasKey(moneyName)){
            
        }
        PlayerPrefs.SetInt(moneyName,money);
    }
}
