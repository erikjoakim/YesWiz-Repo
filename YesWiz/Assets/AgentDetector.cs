using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentDetector : MonoBehaviour {

    NavMeshAgent agent;
    GameObject target;
    Vector3 homePosition;
    [SerializeField] float stopChaseDistance= 10f;
    [SerializeField] float chaseSpeed = 0.9f;
    [SerializeField] float walkSpeed = 0.7f;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        homePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
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
                agent.SetDestination(target.transform.position);
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
