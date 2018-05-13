using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    Weapon weapon;
    Character character;
    private void Start()
    {
        // TODO Init damage for DamageDealer
        // TODO fill in damage based on weapon, passives and stats
        character = GetComponent<Character>();
        weapon = character.mainHandItem;
    }

    public void Attack(DamageReceiver damageReceiver)
    {
        if (weapon.weaponCategory == Weapon.WeaponCategory.Ranged)
        {
            //SPAWN
            print(this.name + " : is RANGE ATTACKING : " + damageReceiver.name);
            SpawnProjectile(damageReceiver);

        }
        else
        {
            print(this.name + " : is MELEE ATTACKING : " + damageReceiver.name);
            dealDamage(damageReceiver);
        }
    }

    void SpawnProjectile(DamageReceiver damageReceiver)
    {
        GameObject projectile =Instantiate(weapon.weaponPrefab, character.spawnPoint.position,Quaternion.identity);
        
        Projectile proj = projectile.GetComponent<Projectile>();
        Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), projectile.GetComponent<CapsuleCollider>(), true);
        proj.damage = drawDamage();
        projectile.transform.LookAt(damageReceiver.gameObject.transform);
        proj.liveForSeconds = weapon.range / weapon.projectileSpeed;
        Vector3 direction = (damageReceiver.gameObject.transform.position + new Vector3(0,0.5f,0)- character.spawnPoint.position).normalized;
        
        Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
        rigidbody.velocity = direction * weapon.projectileSpeed;
    }

    public void Attack(GameObject gameObject)
    {
        DamageReceiver damageReceiver = gameObject.GetComponent<DamageReceiver>();
        if (damageReceiver)
        {
            Attack(damageReceiver);
        }
    }

    public void ApplyDebuff(DamageType damage, float intervall, float duration)
    {
        //DamageType debuffDamage = damage;
        //TODO Start Coroutine for dealing damage
    }

    void dealDamage(DamageReceiver damageReceiver)
    {
        // TODO Apply damage modifiers, such as Buffs currently running
        // TODO Think about how to set up damage dealer
        DamageType tmp = drawDamage();
        damageReceiver.ApplyDamage(tmp);
    }

    DamageType drawDamage()
    {
        DamageType minDamage = weapon.minDamage;
        DamageType maxDamage = weapon.maxDamage; ;
        DamageType returnDamage = new DamageType(0);
        returnDamage.physicalHard = UnityEngine.Random.Range(minDamage.physicalHard, maxDamage.physicalHard);
        //print("PH: " + returnDamage.physicalHard);
        returnDamage.physicalSoft = UnityEngine.Random.Range(minDamage.physicalSoft, maxDamage.physicalSoft);
        returnDamage.fire = UnityEngine.Random.Range(minDamage.fire, maxDamage.fire);
        returnDamage.water = UnityEngine.Random.Range(minDamage.water, maxDamage.water);
        returnDamage.ice = UnityEngine.Random.Range(minDamage.ice, maxDamage.ice);
        returnDamage.earth = UnityEngine.Random.Range(minDamage.earth, maxDamage.earth);
        returnDamage.poison = UnityEngine.Random.Range(minDamage.poison, maxDamage.poison);
        return returnDamage;
    }
}
