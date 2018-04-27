using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : Character {

    NavMeshAgent agent;
    
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        Camera.main.GetComponent<HandleInput>().handleInputEV += receiveInput;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void receiveInput(GameObject obj, bool isInteractable)
    {
        if (Input.GetMouseButton(0))
        {
            //print("Obj Pos: " + obj.transform.position);
            if (isInteractable)
            {
                Interactable interactable = obj.GetComponent<Interactable>();
                var distance = obj.transform.position.magnitude;
                var direction = obj.transform.position / distance;
                
                var destination = direction * (distance - interactable.stopDistance);
                print("Dest Pos: " + destination);
                agent.SetDestination(destination);
            }
            else
            {
                print("Dest Pos: " + obj.transform.position);

                NavMeshHit hit;
                if(NavMesh.SamplePosition(obj.transform.position, out hit, 4f, NavMesh.AllAreas))
                {
                    print("NavMesh Dest Pos: " + hit.position);

                    agent.SetDestination(hit.position);
                }
                
            }
            
        }
    }
}
