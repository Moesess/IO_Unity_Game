using System;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    private float maxHealth;
    public float currentHealth;
    public System.Random rand = new System.Random();
    public int xCoins;
    public int xWood;
    public int xIron;
    public int xStone;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable() {
        maxHealth = gameObject.GetComponent<Character>().HealthPoints.BaseValue;
        currentHealth = maxHealth;
    }

    public void ModifyHealth(float amount)
    {
        currentHealth += amount;

        float currentHealthPct = currentHealth/maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    private void Start() 
    {
        xCoins = UnityEngine.Random.Range(1,5);
        xWood = UnityEngine.Random.Range(1,5);
        xIron = UnityEngine.Random.Range(1,5);
        xStone = UnityEngine.Random.Range(1,5);
    }
    private void Update() 
    {
        if(currentHealth <= 0)
        {

            Destroy(gameObject);
            if(gameObject.tag == "Player")
            {
                Debug.Log(xCoins);
                Debug.Log(xWood);
                Debug.Log(xIron);
                Debug.Log(xStone);
                Time.timeScale = 0;
                GameObject.Find("SummaryWindowCanvas").GetComponent<Canvas>().enabled = true;
                int slayedMonstersSummary = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().killedMonsters;
                GameObject.Find("SlayedMonstersNumber").GetComponent<TextMeshProUGUI>().text = slayedMonstersSummary.ToString();
                int earnedCoins = slayedMonstersSummary * xCoins;
                GameResources.AddCoinAmount(earnedCoins);
                Debug.Log("earnedCoins: " + earnedCoins);
                int earnedWood = slayedMonstersSummary * xWood;
                GameResources.AddWoodAmount(earnedWood);
                Debug.Log("earnedWood: " + earnedWood);
                int earnedStone = slayedMonstersSummary * xStone;
                GameResources.AddStoneAmount(earnedStone);
                Debug.Log("earnedStone: " + earnedStone);
                int earnedIron = slayedMonstersSummary * xIron;
                GameResources.AddIronAmount(earnedIron);
                Debug.Log("earnedIron: " + earnedIron);

                GameObject.Find("CoinNumber").GetComponent<TextMeshProUGUI>().text = earnedCoins.ToString();
                GameObject.Find("WoodNumber").GetComponent<TextMeshProUGUI>().text = earnedWood.ToString();
                GameObject.Find("StoneNumber").GetComponent<TextMeshProUGUI>().text = earnedStone.ToString();
                GameObject.Find("IronNumber").GetComponent<TextMeshProUGUI>().text = earnedIron.ToString();
            }
        }
    }
}
