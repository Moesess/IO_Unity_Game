 using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;

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
        gameObject.GetComponent<Enemy>().health = currentHealth;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            ModifyHealth(-10);
    }
}
