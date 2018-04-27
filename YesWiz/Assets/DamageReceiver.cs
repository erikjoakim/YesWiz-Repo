using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageReceiver : MonoBehaviour {

    [SerializeField] float health;
    [SerializeField] float maxHealth = 100f;

    Character character;
    private void Start()
    {
        character = GetComponent<Character>();    
    }

    public void ApplyDamage(DamageDealer.DamageType damage)
    {
        print("Damage Receiver: DAMAGE TAKEN!! HELP!!");
        DamageDealer.DamageType dmg;

        if (character == null)
        {
            //Apply physical damage directly
            //TODO Check if better implementation for destructable objects
            //TODO Check for objects susceptible for burning
            //TODO introduce an Object Type??

            health -= damage.physicalHard;
            return;
        }

        //TODO Apply defences (evasion) relevant for all damage types PRIOR HIT
        dmg = ApplyPreDefences(damage);
        dmg = CalculateDamage(dmg);
        health -= ApplyPostDefences(dmg);
        
        //TODO Apply defences (damage mitigation Armour) relevant for all damage types AFTER HIT
        
    }

    private DamageDealer.DamageType ApplyPreDefences(DamageDealer.DamageType damage)
    {
        //TODO implement evasion & Block
        return damage;
    }

    private float ApplyPostDefences(DamageDealer.DamageType dmg)
    {
        float damage;
        damage = dmg.earth + dmg.fire + dmg.ice + dmg.physicalHard + dmg.physicalSoft + dmg.poison + dmg.water;
        return damage;
    }

    private DamageDealer.DamageType CalculateDamage(DamageDealer.DamageType damage)
    {
        DamageDealer.DamageType dmg;
        dmg.earth = damage.earth * Mathf.Clamp((1 - character.earthResistance), -100, character.maxEarthResistance);
        dmg.fire = damage.fire * Mathf.Clamp((1 - character.fireResistance), -100, character.maxFireResistance);
        dmg.ice = damage.ice * Mathf.Clamp((1 - character.iceResistance), -100, character.maxIceResistance);
        dmg.water = damage.water * Mathf.Clamp((1 - character.waterResistance), -100, character.maxWaterResistance);

        // TODO Physical Damage Mitigation should be large initially but reduced if substantal damage is applied 
        // or health reduced over a limited time period. Should grow back over time if not damage received.
        dmg.physicalHard = damage.physicalHard * character.physicalDamageMitigationHard;
        dmg.physicalSoft = damage.physicalSoft * character.physicalDamageMitigationSoft;

        //TODO check if poison should have no damage reduction
        dmg.poison = damage.poison;

        return dmg;
    }
}
