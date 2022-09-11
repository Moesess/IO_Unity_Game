using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class GameResources 
{
    public static event EventHandler OnCoinAmountChanged;
    public static event EventHandler OnWoodAmountChanged;
    public static event EventHandler OnStoneAmountChanged;
    public static event EventHandler OnIronAmountChanged;

    private static int coinAmount = 0;
    private static int woodAmount = 0;
    private static int stoneAmount = 0;
    private static int ironAmount = 0;
    
    public static void AddCoinAmount(int amount) {
        coinAmount += amount;
        if(OnCoinAmountChanged != null) OnCoinAmountChanged(null, EventArgs.Empty);
    }

    public static void AddWoodAmount(int amount) {
        woodAmount += amount;
        if(OnWoodAmountChanged != null) OnWoodAmountChanged(null, EventArgs.Empty);
    }

    public static void AddStoneAmount(int amount) {
        stoneAmount += amount;
        if(OnStoneAmountChanged != null) OnStoneAmountChanged(null, EventArgs.Empty);
    }

    public static void AddIronAmount(int amount) {
        ironAmount += amount;
        if(OnIronAmountChanged != null) OnIronAmountChanged(null, EventArgs.Empty);
    }

    public static int GetCoinAmount() {
        return coinAmount;
    }

    public static int GetWoodAmount() {
        return woodAmount;
    }

    public static int GetStoneAmount() {
        return stoneAmount;
    }

    public static int GetIronAmount() {
        return ironAmount;
    }
}
