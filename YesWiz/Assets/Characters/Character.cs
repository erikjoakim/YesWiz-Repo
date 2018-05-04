using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [Header("Character")]
    public float energy = 100f;
    public float maxEnergy = 100f;

    public int level = 1;

    public int strength = 10;
    public int intelligence = 10;
    public int agility = 10;

    public Transform mainHandSocket;
    public Transform offHandSocket;
    public Transform spawnPoint;

    public Weapon mainHandItem;
    //public EquipmentList equipment;

    DamageDealer damageDealer;
    Animator animator;
    float timeOfLatestAttack;

    virtual public void Start()
    {
        //TODO Init all stats based on equipment, passive and such
        if (mainHandItem != null)
        {
            if (mainHandItem.weaponCategory == Weapon.WeaponCategory.Melee)
            {
                Instantiate(mainHandItem.weaponPrefab, mainHandSocket);
            }
            
        }
        else
        {
            mainHandItem = ((Weapon)Weapon.CreateInstance(typeof(Weapon))).InitHandWeapon(this);
        }
        print(mainHandItem);
        damageDealer = GetComponent<DamageDealer>();
        animator = GetComponent<Animator>();
        timeOfLatestAttack = Time.time;
    }

    public void Attack(DamageReceiver target)
    {
        if (Time.time - timeOfLatestAttack > 1 / mainHandItem.attackSpeed)
        {
            if (mainHandItem.range > (target.gameObject.transform.position - transform.position).magnitude)
            {
                //LIKE TO INCREASE ANIMATION SPEED FOR FAST ATTACKS
                
                animator.SetTrigger("Attack");
                damageDealer.Attack(target);
                timeOfLatestAttack = Time.time;
            }
        }
    }
    public void Attack(GameObject target)
    {
        DamageReceiver damageReceiver = target.GetComponent<DamageReceiver>();
        if (damageReceiver)
        {
            Attack(damageReceiver);
        }
    }
}
