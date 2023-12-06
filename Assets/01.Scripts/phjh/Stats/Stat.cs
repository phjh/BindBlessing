using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Equipments
{
    
}

[Serializable]
public class Stat  // 그냥 알아서  int만 
{
    
    public int BaseStat = 0;
    public List<int> modifiers;
    //public Dictionary<Equipments, int> modifierss;
    
    public int SumValue()
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
