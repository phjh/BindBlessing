using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    intelligence,
    mana,
    manaregen,
    criticalChance,
    criticalDamage,
    armor,
    maxHealth,
    speed,
}

[CreateAssetMenu(menuName = "SO/Player/Stat")]
public class PlayerStat : ScriptableObject
{
    [Header("Damage stats")]
    public Stat intelligence;
    public Stat mana;
    public Stat attackSpeed;
    public Stat criticalChance;
    public Stat criticalDamage;
    
    [Header("Living Stats")] 
    public Stat armor;
    public Stat maxHealth;

    [Header("Util Stats")] 
    public Stat speed;
    public Stat manaRegen;
}

[Serializable]
public class Stat  // ê·¸ëƒ¥ ?Œì•„?? intë§?
{
    
    public int BaseStat = 0;
    public List<int> modifiers;
    //public Dictionary<Equipments, int> modifierss;
    
    public int GetStatValue()
    {
        int sum = 0;
        foreach (int i in modifiers)
        {
            sum += i;
        }
        return sum;
    }

    public void AddStat(int i)
    {
        BaseStat += i;
    }

    public void RemoveStat(int i)
    {
        BaseStat -= i;
    }
}
