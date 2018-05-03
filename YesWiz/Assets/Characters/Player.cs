using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : Character {

    NavMeshAgent agent;
    //DamageDealer damageDealer;
    DamageReceiver damageReceiver;
    //Animator animator;

    // Use this for initialization
    override public void Start () {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        Camera.main.GetComponent<HandleInput>().handleInputEV += receiveInput;
        //damageDealer = GetComponent<DamageDealer>();
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void receiveInput(GameObject obj, bool isInteractable)
    {
        HandleMouseDown(obj, isInteractable);
        if(Input.GetButton("Fire1"))
        {
            GameObject objectInFocus = Camera.main.GetComponent<HandleInput>().objectInFocus;
            if (!objectInFocus) return;
            DamageReceiver damageReceiver = objectInFocus.GetComponent<DamageReceiver>();
            if (!damageReceiver) return;
            Attack(damageReceiver);
            
        }
    }

    private void HandleMouseDown(GameObject obj, bool isInteractable)
    {
        if (Input.GetMouseButton(0))
        {
            // TODO How do I know which Object to Attack??
            // 
            //print("Obj Pos: " + obj.transform.position);
            if (isInteractable)
            {
                Interactable interactable = obj.GetComponent<Interactable>();
                //print("Object:" + obj);
                var distance = obj.transform.position.magnitude;
                var direction = obj.transform.position / distance;

                var destination = direction * (distance - interactable.stopDistance);
                //print("Dest Pos: " + destination);
                agent.SetDestination(destination);
            }
            else
            {
                //print("Dest Pos: " + obj.transform.position);

                NavMeshHit hit;
                if (NavMesh.SamplePosition(obj.transform.position, out hit, 4f, NavMesh.AllAreas))
                {
                    agent.SetDestination(hit.position);
                }

            }

        }
    }
}
