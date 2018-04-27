using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/EquipmentList")]
public class EquipmentList: ScriptableObject {

    public Armour bodyArmour;
    public Armour helmet;
    public Weapon mainHandWeapon;
}
