using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;

    private void Awake() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        foregroundImage.fillAmount = pct;

    }
}
