using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [Serializable]
    public struct DamageType
    {
        public float physicalHard;
        public float physicalSoft;
        public float fire;
        public float water;
        public float ice;
        public float earth;
        public float poison;
    }

    [SerializeField] DamageType baseDamage;
    
    //TODO This should come from Weapon
    [SerializeField] float timeBetweenAttacks=2f;
    float timeOfLatestAttack;
    public float range;

    private void Start()
    {
        // TODO Init damage for DamageDealer
        // TODO fill in damage based on weapon, passives and stats
        timeOfLatestAttack = Time.time;
    }

    public void Attack(DamageReceiver damageReceiver)
    {
        if (Time.time-timeOfLatestAttack > timeBetweenAttacks)
        {
            print(this.name + " : ATTACK!!");
            dealDamage(damageReceiver);
            timeOfLatestAttack = Time.time;
        }
        
    }

    public void Attack(GameObject gameObject)
    {
        DamageReceiver damageReceiver = gameObject.GetComponent<DamageReceiver>();
        if (damageReceiver)
        {
            Attack(damageReceiver);
        }
    }

    public void ApplyDebuff(DamageType damage, float intervall, float duration)
    {
        DamageType debuffDamage = damage;
        //TODO Start Coroutine for dealing damage
    }

    void dealDamage(DamageReceiver damageReceiver)
    {
        // TODO Apply damage modifiers, such as Buffs currently running
        // TODO Think about how to set up damage dealer
        damageReceiver.ApplyDamage(baseDamage);
    }

    private float CalculateDamage(DamageType damageType, float damageValue)
    {
        // TODO Apply defences relevant for particular damage type
        return damageValue;
    }
}
