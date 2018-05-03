using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class DamageReceiver : MonoBehaviour {

    [SerializeField] float health;
    [SerializeField] float maxHealth = 100f;
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

    Character character;
    Animator animator;
    private void Start()
    {
        health = maxHealth;
        character = GetComponent<Character>();
        animator = GetComponent<Animator>();    
    }

    void Update()
    {

    }

    public float getHealthAsPercentage()
    {
        return health / maxHealth;
    }
    public void ApplyDamage(DamageType damage)
    {
        print(this.name + " : DAMAGE TAKEN!! HELP!!");
        DamageType dmg;

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
        if (health < 0f)
        {
            print(character.name + " DIE!!");
            StartCoroutine(KillCharacter());
        }
        //print(this.name + " : Current Health: " + health);
        //TODO Apply defences (damage mitigation Armour) relevant for all damage types AFTER HIT

    }

    IEnumerator KillCharacter()
    {
        print(character.name + " DIE!! Again");
        animator.SetTrigger("Death");
        GetComponent<AgentDetector>().enabled = false;
        GetComponent<DamageDealer>().enabled = false;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().enabled = false;
        //GetComponent<NavMeshAgent>().enabled = false;
        yield return new WaitForSecondsRealtime(6);
        print(character.name + " DIE!! Again Destroy");
        if (gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    private DamageType ApplyPreDefences(DamageType damage)
    {
        //TODO implement evasion & Block
        return damage;
    }

    private float ApplyPostDefences(DamageType dmg)
    {
        //TODO Apply any generic post-defences
        float damage;
        damage = dmg.earth + dmg.fire + dmg.ice + dmg.physicalHard + dmg.physicalSoft + dmg.poison + dmg.water;
        return damage;
    }

    private DamageType CalculateDamage(DamageType damage)
    {
        DamageType dmg = new DamageType();
        dmg.earth = damage.earth * Mathf.Clamp((1 - earthResistance), -100, maxEarthResistance);
        dmg.fire = damage.fire * Mathf.Clamp((1 - fireResistance), -100, maxFireResistance);
        dmg.ice = damage.ice * Mathf.Clamp((1 - iceResistance), -100, maxIceResistance);
        dmg.water = damage.water * Mathf.Clamp((1 - waterResistance), -100, maxWaterResistance);

        // TODO Physical Damage Mitigation should be large initially but reduced if substantal damage is applied 
        // or health reduced over a limited time period. Should grow back over time if not damage received.
        dmg.physicalHard = damage.physicalHard * (1-physicalDamageMitigationHard);
        dmg.physicalSoft = damage.physicalSoft * (1-physicalDamageMitigationSoft);

        //TODO check if poison should have no damage reduction
        dmg.poison = damage.poison;

        return dmg;
    }
}
