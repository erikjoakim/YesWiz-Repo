using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment/Weapon")]
public class Weapon : EquipableItem {
    
    public enum WeaponType
    {
        Dagger, Sword, Axe, Bow
    };
    [Header("Weapon")]
    public WeaponType weaponType;
    public DamageDealer.DamageType minDamage;
    public DamageDealer.DamageType maxDamage;
    public AnimationClip characterAttackAnimation;
    public float range;
}
