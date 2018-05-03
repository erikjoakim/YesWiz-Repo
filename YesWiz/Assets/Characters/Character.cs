using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [Header("Character")]
    public float energy = 100f;
    public float maxEnergy = 100f;

    public int level = 1;

    public int strength = 10;
    public int intelligence = 10;
    public int agility = 10;

    public Transform mainHandSocket;
    public Transform offHandSocket;

    public Weapon mainHandItem;
    //public EquipmentList equipment;

    virtual public void Start()
    {
        //TODO Init all stats based on equipment, passive and such
        if (mainHandItem != null)
        {
            Instantiate(mainHandItem.weaponPrefab, mainHandSocket);
        }
        else
        {
            mainHandItem = ((Weapon) Weapon.CreateInstance(typeof(Weapon))).InitHandWeapon(this);
        }
        print(mainHandItem);
    }
}
