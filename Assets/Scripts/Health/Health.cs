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
                GameObject.Find("CoinNumber").GetComponent<TextMeshProUGUI>().text = (slayedMonstersSummary * UnityEngine.Random.Range(1,5)).ToString();
                GameObject.Find("WoodNumber").GetComponent<TextMeshProUGUI>().text = (slayedMonstersSummary * UnityEngine.Random.Range(1,5)).ToString();
                GameObject.Find("StoneNumber").GetComponent<TextMeshProUGUI>().text = (slayedMonstersSummary * UnityEngine.Random.Range(1,5)).ToString();
                GameObject.Find("IronNumber").GetComponent<TextMeshProUGUI>().text = (slayedMonstersSummary * UnityEngine.Random.Range(1,5)).ToString();
            }
        }
    }
}
