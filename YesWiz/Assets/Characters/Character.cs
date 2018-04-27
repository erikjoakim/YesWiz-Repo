using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    
    public float energy = 100f;
    public float maxEnergy = 100f;

    public int level = 1;

    public int strength = 10;
    public int intelligence = 10;
    public int agility = 10;

    public float physicalDamageMitigationHard = 0.1f;
    public float physicalDamageMitigationSoft = 0.1f;

    public float fireResistance = 0.1f;
    public float iceResistance = 0.1f;
    public float earthResistance = 0.1f;
    public float electricalResistance = 0.1f;
    public float waterResistance = 0.1f;

    public float maxFireResistance = 0.75f;
    public float maxIceResistance = 0.75f;
    public float maxEarthResistance = 0.75f;
    public float maxElectricalResistance = 0.75f;
    public float maxWaterResistance = 0.75f;

    public float armour = 0.1f;
    public float evasion = 0.1f;

    public EquipmentList equipment;

    private void Start()
    {
        //TODO Init all stats based on equipment, passive and such
    }
}
