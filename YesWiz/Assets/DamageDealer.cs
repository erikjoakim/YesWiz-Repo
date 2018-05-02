using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [Serializable]
    public class DamageType
    {
        public float physicalHard;
        public float physicalSoft;
        public float fire;
        public float water;
        public float ice;
        public float earth;
        public float poison;
    }

    DamageType minDamage;
    DamageType maxDamage;
    
    //TODO This should come from Weapon
    [SerializeField] float timeBetweenAttacks=2f;
    float timeOfLatestAttack;
    public float range;
    

    private void Start()
    {
        // TODO Init damage for DamageDealer
        // TODO fill in damage based on weapon, passives and stats
        print("Im here");
        timeOfLatestAttack = Time.time;
        maxDamage = GameManager.player.weaponInUse.maxDamage;
        print("max: " + maxDamage.physicalHard);
        minDamage = GameManager.player.weaponInUse.minDamage;
    }

    public void Attack(DamageReceiver damageReceiver)
    {
        if (Time.time-timeOfLatestAttack > timeBetweenAttacks)
        {
            print(this.name + " s: ATTACK!!: " + damageReceiver.name);
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
        
        DamageType tmp = drawDamage();
        print("Draw Damage: " + tmp.physicalHard);
        damageReceiver.ApplyDamage(tmp);
        
        
    }

    DamageType drawDamage()
    {
        
        DamageType returnDamage = new DamageType();
        returnDamage.physicalHard = UnityEngine.Random.Range(minDamage.physicalHard, maxDamage.physicalHard);
        print("PH: " + returnDamage.physicalHard);
        returnDamage.physicalSoft = UnityEngine.Random.Range(minDamage.physicalSoft, maxDamage.physicalSoft);
        returnDamage.fire = UnityEngine.Random.Range(minDamage.fire, maxDamage.fire);
        returnDamage.water = UnityEngine.Random.Range(minDamage.water, maxDamage.water);
        returnDamage.ice = UnityEngine.Random.Range(minDamage.ice, maxDamage.ice);
        returnDamage.earth = UnityEngine.Random.Range(minDamage.earth, maxDamage.earth);
        returnDamage.poison = UnityEngine.Random.Range(minDamage.poison, maxDamage.poison);
        return returnDamage;
    }
}
