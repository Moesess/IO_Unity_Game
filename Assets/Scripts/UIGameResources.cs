using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameResources : MonoBehaviour
{
    private void Awake() {
        GameResources.OnCoinAmountChanged += delegate (object sender, EventArgs e) {
            UpdateResourceTextObject();
        };
        GameResources.OnWoodAmountChanged += delegate (object sender, EventArgs e) {
            UpdateResourceTextObject();
        };
        GameResources.OnStoneAmountChanged += delegate (object sender, EventArgs e) {
            UpdateResourceTextObject();
        };
        GameResources.OnIronAmountChanged += delegate (object sender, EventArgs e) {
            UpdateResourceTextObject();
        };

        UpdateResourceTextObject();
    }

    private void UpdateResourceTextObject() {
        transform.GetChild(0).Find("UICoinsAmmountText").GetComponent<TMP_Text>().text = GameResources.GetCoinAmount().ToString();
        transform.GetChild(1).Find("UIWoodAmmountText").GetComponent<TMP_Text>().text = GameResources.GetWoodAmount().ToString();
        transform.GetChild(2).Find("UIStoneAmmountText").GetComponent<TMP_Text>().text = GameResources.GetStoneAmount().ToString();
        transform.GetChild(3).Find("UIIronAmmountText").GetComponent<TMP_Text>().text = GameResources.GetIronAmount().ToString();
    }
}
