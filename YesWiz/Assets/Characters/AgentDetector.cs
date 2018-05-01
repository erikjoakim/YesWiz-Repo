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
    DamageDealer damageDealer;
    DamageReceiver damageReceiver;
    
    [SerializeField] float stopChaseDistance= 10f;
    [SerializeField] float chaseSpeed = 0.9f;
    [SerializeField] float walkSpeed = 0.7f;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        damageDealer = GetComponent<DamageDealer>();
        damageReceiver = GetComponent<DamageReceiver>();
        homePosition = transform.position;
        interactable = GetComponent<Interactable>();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveToTarget();
        
        if(damageDealer && target && (target.transform.position -transform.position).magnitude < damageDealer.range)
            Attack();
        
    }

    private void Attack()
    {
        
        damageDealer.Attack(target);
    }

    private void MoveToTarget()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            agent.speed = chaseSpeed;
            target = other.gameObject;
            agent.SetDestination(target.transform.position);
        }
    }
    
}
