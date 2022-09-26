using System;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    private float maxHealth;
    public float currentHealth;

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

    private void Update() {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            if(gameObject.tag == "Player")
            {
                Time.timeScale = 0;
                GameObject.Find("SummaryWindowCanvas").GetComponent<Canvas>().enabled = true;
                var slayedMonstersSummary = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().killedMonsters;
                GameObject.Find("SlayedMonstersNumber").GetComponent<TextMeshProUGUI>().text = slayedMonstersSummary.ToString();
                var earnedCoins = slayedMonstersSummary * UnityEngine.Random.Range(1,5);
                GameResources.AddCoinAmount(earnedCoins);
                var earnedWood = slayedMonstersSummary * UnityEngine.Random.Range(1,5);
                GameResources.AddWoodAmount(earnedWood);
                var earnedStone = slayedMonstersSummary * UnityEngine.Random.Range(1,5);
                GameResources.AddStoneAmount(earnedStone);
                var earnedIron = slayedMonstersSummary * UnityEngine.Random.Range(1,5);
                GameResources.AddIronAmount(earnedIron);

                GameObject.Find("CoinNumber").GetComponent<TextMeshProUGUI>().text = earnedCoins.ToString();
                GameObject.Find("WoodNumber").GetComponent<TextMeshProUGUI>().text = earnedWood.ToString();
                GameObject.Find("StoneNumber").GetComponent<TextMeshProUGUI>().text = earnedStone.ToString();
                GameObject.Find("IronNumber").GetComponent<TextMeshProUGUI>().text = earnedIron.ToString();
            }
        }
    }
}
