using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; //object?

[Serializable] 
public class CharacterStats
{
    public float BaseValue;

    public virtual float Value { 
        get {
            if(isDirty || BaseValue != lastBaseValue) {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            } 
            return _value; 
        } 
    }

    protected bool isDirty = true;
    protected float _value;
    protected float lastBaseValue = float.MinValue;

    protected readonly List<StatsModifier> statModifiers; 
    public readonly ReadOnlyCollection<StatsModifier> StatModifiers;

    public CharacterStats()
    {
        statModifiers = new List<StatsModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public CharacterStats(float baseValue) : this()
    {
        BaseValue = baseValue;
    }

    public virtual void AddModifier(StatsModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    public virtual bool RemoveModifier(StatsModifier mod)
    {
        if(statModifiers.Remove(mod)) {
            isDirty = true;
            return true;
        }
        return false;
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if(statModifiers[i].Source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }

        return didRemove;
    }

    protected virtual int CompareModifierOrder(StatsModifier a, StatsModifier b)  
    {
        if(a.Order < b.Order)
            return -1;
        if(a.Order < b.Order)
            return 1;
        return 0;   
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for(int i = 0; i < statModifiers.Count; i++)
        {
            StatsModifier mod = statModifiers[i];   

            if(mod.Type == StatModType.Flat) {
                finalValue += mod.Value;
            }
            else if(mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;

                if(i+1 >= statModifiers.Count || statModifiers[i+1].Type != StatModType.PercentAdd) {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if(mod.Type == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }
        }

        return (float)Math.Round(finalValue, 4);
    }
}
