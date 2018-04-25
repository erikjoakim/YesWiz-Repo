using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour {


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
            agent.SetDestination(obj.transform.position);
        }
    }
}
