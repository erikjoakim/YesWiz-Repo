using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AgentDetector : Character {

    NavMeshAgent agent;
    GameObject target;
    Vector3 homePosition;
    Interactable interactable;
    DamageReceiver damageReceiver;
    [Header("Agent Detector")]
    [SerializeField] float stopChaseDistance= 10f;
    [SerializeField] float chaseSpeed = 0.9f;
    [SerializeField] float walkSpeed = 0.7f;

    // Use this for initialization
    override public void Start () {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        //damageDealer = GetComponent<DamageDealer>();
        //damageReceiver = GetComponent<DamageReceiver>();
        homePosition = transform.position;
        interactable = GetComponent<Interactable>();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveToTarget();
        
        if(target && (target.transform.position -transform.position).magnitude < mainHandItem.range)
            Attack(target);
    }
    // TODO Implement different Emeny Behaviors ScriptableObjects, such as Ranged and Melee
    // The below only works for Melee...
    private void MoveToTarget()
    {
        if (mainHandItem.weaponCategory == Weapon.WeaponCategory.Ranged)
        {
            if (target != null)
            {
                if ((target.transform.position - transform.position).magnitude < mainHandItem.range)
                {
                    Attack(target);
                }
            }
        }
        else
        {
            if (target != null)
            {
                if ((target.transform.position - transform.position).magnitude > stopChaseDistance)
                {
                    target = null;
                    agent.speed = walkSpeed;
                    agent.SetDestination(homePosition);
                }
                else
                {
                    if ((target.transform.position - transform.position).magnitude < interactable.stopDistance)
                    {
                        agent.speed = 0;
                        agent.SetDestination(transform.position);
                    }
                    else
                    {
                        agent.speed = chaseSpeed;
                        agent.SetDestination(target.transform.position);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mainHandItem.weaponCategory == Weapon.WeaponCategory.Ranged)
        {
            if (other.gameObject.tag == "Player")
            {
                target = other.gameObject;
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                agent.speed = chaseSpeed;
                target = other.gameObject;
                agent.SetDestination(target.transform.position);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (mainHandItem.weaponCategory == Weapon.WeaponCategory.Ranged)
        {
            if (other.gameObject.tag == "Player")
            {
                target = null;
            }
        }
    }
}
