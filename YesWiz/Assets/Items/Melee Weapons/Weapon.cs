using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment/Weapon")]
public class Weapon : EquipableItem {
    
    public enum WeaponCategory
    {
        Melee, Ranged
    };
    public enum WeaponType
    {
        Hand, Dagger, Sword, Axe, Bow
    };
    [Header("Weapon")]
    public WeaponCategory weaponCategory;
    public WeaponType weaponType;
    public DamageType minDamage;
    public DamageType maxDamage;
    public AnimationClip characterAttackAnimation;
    public float range;
    public float projectileSpeed;
    public float attackSpeed; //Attacks per Second

    public Weapon InitHandWeapon(Character basedOnChar)
    {
        weaponType = WeaponType.Hand;
        range = Mathf.Clamp(basedOnChar.agility / 10, 0, 2);
        attackSpeed = Mathf.Clamp(basedOnChar.agility / 10, 0, 2);
        minDamage = new DamageType(basedOnChar.strength / 10);
        maxDamage = new DamageType(basedOnChar.strength);
        return this;
    }
    private void Awake()
    {
        minDamage = new DamageType();
        maxDamage = new DamageType();
    }
}
