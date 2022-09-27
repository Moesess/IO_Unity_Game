using UnityEngine;

public enum StatModType
{
    Flat, 
    PercentAdd,
    PercentMult,
}

public class StatsModifier
{
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source;

    public StatsModifier(float value, StatModType type, int order, object source)
    {
        Value = value;
        Type = type;
        Order = order;
    }

    public StatsModifier(float value, StatModType type) : this (value, type, (int)type, null) { }

    public StatsModifier(float value, StatModType type, int order) : this (value, type, order, null) { }

    public StatsModifier(float value, StatModType type, object source) : this (value, type, (int)type, source) { }
}
