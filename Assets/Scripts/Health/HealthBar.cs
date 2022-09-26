using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;

    private void Awake() {
        GetComponentInParent<Health>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        foregroundImage.fillAmount = pct;

    }
     private void LateUpdate() {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180 , 0);
    }
}
