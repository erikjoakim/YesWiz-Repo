using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField] float health;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float energy = 100f;
    [SerializeField] float maxEnergy = 100f;

    [SerializeField] int level = 1;

    [SerializeField] int strength = 10;
    [SerializeField] int intelligence = 10;
    [SerializeField] int agility = 10;

    [SerializeField] float physicalDamageMitigationHard = 0.1f;
    [SerializeField] float physicalDamageMitigationSoft = 0.1f;

    private void Start()
    {
        health = maxHealth;
    }
}
