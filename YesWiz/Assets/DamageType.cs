using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageType {

    public float physicalHard;
    public float physicalSoft;
    public float fire;
    public float water;
    public float ice;
    public float earth;
    public float poison;

    public DamageType()
    {
        physicalHard = 0;
        physicalSoft=0;
        fire=0;
        water=0;
        ice=0;
        earth=0;
        poison=0;
}
    public DamageType(float physicalHard)
    {
        this.physicalHard = physicalHard;
        physicalSoft = 0;
        fire = 0;
        water = 0;
        ice = 0;
        earth = 0;
        poison = 0;
    }
}
