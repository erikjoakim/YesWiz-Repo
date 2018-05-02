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

    public Transform mainHandSocket;
    public Transform offHandSocket;

    public EquipmentList equipment;

    private void Start()
    {
        //TODO Init all stats based on equipment, passive and such
    }
}
