using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpgrading : MonoBehaviour
{
    public System.String name;
    public static int hpUpgrade = 0;
    public static int strUpgrade = 0;

    public void AddStat(){
        if(name == "Health" && GameResources.GetCoinAmount() >= hpUpgrade + 1){
            GameObject.Find("Player").GetComponent<Character>().HealthPoints.Value += 1;
            hpUpgrade += 1;
            GameResources.AddCoinAmount(-hpUpgrade);
        }
        else if(name == "Strength" && GameResources.GetCoinAmount() >= strUpgrade + 1){
            strUpgrade += 1;
            GameObject.Find("Player").GetComponent<Character>().Strength.Value += 1;
            GameResources.AddCoinAmount(-strUpgrade);
        }
    }
}
