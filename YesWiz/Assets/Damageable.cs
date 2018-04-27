using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour {

 

    public enum DamageType
    {
        PhysicalHard, PhysicalSoft, Fire 
    }
    public class DamageInfo
    {
        public DamageType damageType;
        public float damageValue;
    }
    public class DebuffInfo : DamageInfo
    {
        float damageApplicationIntervall;
        float damageApplicationDuration;
    }

    private void Start()
    {
        
    }

    public float ApplyDamage(DamageInfo[] damages)
    {
        float finalDamage=0;
        //TODO Apply defences relevant for all damage types PRIOR HIT
        for (int i = 0; i < damages.Length; i++)
        {
            finalDamage += CalculateDamage(damages[i].damageType, damages[i].damageValue);
        }
        //TODO Apply defences relevant for all damage types AFTER HIT
        return finalDamage;
    }

    private float CalculateDamage(DamageType damageType, float damageValue)
    {
        // TODO Apply defences relevant for particular damage type
        return damageValue;
    }
}
