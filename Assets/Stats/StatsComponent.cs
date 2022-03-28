using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class StatsComponent : MonoBehaviour
{
    private StatSystem health = new StatSystem("Health",100,100);
    public float wait = 1f;
    public StatBar healthBar;
    void Start() 
    {
        healthBar.Setup(health);
        Debug.Log(health.GetStatName()+": "+health.GetCurrentAmount());

        CMDebug.ButtonUI(new Vector2(100,100), "damage", () => {
            health.SubstractAmount(10);
            Debug.Log(health.GetStatName()+": "+health.GetAmountPercentage());
        });
        CMDebug.ButtonUI(new Vector2(-100,100), "heal", () => {
            health.AddAmount(10);
            Debug.Log(health.GetStatName()+": "+health.GetAmountPercentage());
        });
    }
    // float time = 0;
    // void Update() { 
    //     time += Time.deltaTime;  
    //     if(time > wait)
    //     {
    //         if(Input.GetKey(KeyCode.Q)) 
    //         {
    //             health.substractAmount(10);
    //             Debug.Log(health.getStatName()+": "+health.getCurrentAmount());
    //         };
    //         if(Input.GetKey(KeyCode.E))
    //         {
    //             health.addAmount(10);
    //             Debug.Log(health.getStatName()+": "+health.getCurrentAmount());
    //         };
    //     }
    // }

}
