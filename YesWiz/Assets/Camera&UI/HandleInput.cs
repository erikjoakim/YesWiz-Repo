using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandleInput : MonoBehaviour
{

    public delegate void handleInput(GameObject obj, bool isInteractable);
    public event handleInput handleInputEV;

    GameObject gameObj;
    Interactable selectedInteractable;
    //TODO Make getter which is private set
    public GameObject objectInFocus = null;
    bool objectSelected = false;

    // Use this for initialization
    void Start()
    {
        gameObj = new GameObject("NoObject");
    }

    // Update is called once per frame
    void Update()
    {
        //RayCastForSingleHit();
        RayCastForMultipleHits();
    }

    RaycastHit? getRaycastHit()
    {
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 100, ~0, QueryTriggerInteraction.Ignore);
        Interactable interactable = null;
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject == objectInFocus)
            {
                return hit;
            }
        }
        foreach (RaycastHit hit in hits)
        {
            interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable)
            {
                return hit;
            }
        }
        if (hits.Length > 0)
        {
            return hits[0];
        }
        return null;
    }

    void RayCastForMultipleHits()
    {
        Interactable interactable;
        //Return if object is selected and mouse button is down
        RaycastHit hit;
        RaycastHit? nullableHit = getRaycastHit();

        if (nullableHit == null)
        {
            return;
        }
        else hit = (RaycastHit)nullableHit;

        if (objectInFocus && objectSelected && Input.GetMouseButton(0))
        {
            SendMouseEvent(hit);
            return;
        }



        if (hit.collider.gameObject == objectInFocus)
        {
            if (Input.GetMouseButtonDown(0))
            {
                objectSelected = true;
            }
            SendMouseEvent(hit);
            return;
        }
        else
        {
            if (objectInFocus)
            {
                objectInFocus.GetComponent<Interactable>().onLostFocus();
                objectInFocus = null;
                objectSelected = false;
            }
        }
        interactable = hit.collider.gameObject.GetComponent<Interactable>();
        if (interactable)
        {
            interactable.onGotFocus();
            objectInFocus = hit.collider.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                objectSelected = true;
            }

        }
        SendMouseEvent(hit);
    }

    private void SendMouseEvent(RaycastHit hit)
    {
        //Send a message to any subscriber wanting to know mouse position
        if (objectInFocus != null)
        {
            handleInputEV(objectInFocus, true);
        }
        else
        {
            gameObj.transform.position = hit.point;
            handleInputEV(gameObj, false);
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
