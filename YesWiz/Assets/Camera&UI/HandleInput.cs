using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class HandleInput: MonoBehaviour {

    public delegate void handleInput(GameObject obj, bool isInteractable);
    public event handleInput handleInputEV;

    GameObject gameObj;
    Interactable selectedInteractable;
    //TODO Make getter which is private set
    public GameObject objectInFocus = null;
    
    // Use this for initialization
    void Start () {
        gameObj = new GameObject("NoObject");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //RayCastForSingleHit();
        RayCastForMulipleHits();
    }

    void RayCastForMulipleHits()
    {
        bool found = false;

        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 100, ~0, QueryTriggerInteraction.Ignore);

        // Set or Remove Object in Focus
        if (objectInFocus != null)
        {
            foreach (RaycastHit hit in hits)
            {
                if (objectInFocus == hit.collider.gameObject)
                {
                    objectInFocus.GetComponent<Interactable>().onFocus();
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                objectInFocus.GetComponent<Interactable>().onLostFocus();
                objectInFocus = null;
                found = false;
            }
        }
        else
        {
            foreach (RaycastHit hit in hits)
            {
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
                if (interactable != null)
                {
                    objectInFocus = hit.collider.gameObject;
                    interactable.onGotFocus();
                    Debug.Log("StopDIst: " + interactable.stopDistance);
                    break;
                }
            }
        }
        if (objectInFocus != null)
        {
            handleInputEV(objectInFocus, true);
        }
        else
        {
            if (hits.Length > 0)
            {
                gameObj.transform.position = hits[0].point;
                handleInputEV(gameObj, false);
            }
        }
    }

    private void RayCastForSingleHit()
    {
        Interactable currentInteractable;
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, ~0, QueryTriggerInteraction.Ignore))
        {
            currentInteractable = hit.collider.gameObject.GetComponent<Interactable>();

            if (currentInteractable != null)
            {
                if (currentInteractable == selectedInteractable)
                {
                    handleInputEV(hit.collider.gameObject, true);
                }
                else
                {
                    selectedInteractable = currentInteractable;
                    selectedInteractable.onGotFocus();
                    handleInputEV(hit.collider.gameObject, true);
                }
            }
            else
            {
                if (selectedInteractable != null)
                {
                    selectedInteractable.onLostFocus();
                    selectedInteractable = null;
                }
                gameObj.transform.position = hit.point;
                handleInputEV(gameObj, false);
            }
        }
    }
}
