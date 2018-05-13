using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(NavMeshAgent))]
public class Player : Character {

    public LayerMask movementMask;
    PlayerMotor motor;
    public Interactable focus = null;
    public DamageReceiver damageReceiver;
    public Interactable interactable;
    Camera cam;

    // Use this for initialization
    override public void Start ()
    {
        base.Start();
        motor = GetComponent<PlayerMotor>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        //Check if UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Click Left To Move
        if(Input.GetMouseButton(0))
        {
            RemoveFocus();
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit);
            }
        }
        //Click Right To Interact
        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                interactable = hit.collider.GetComponent<Interactable>();
                if (interactable)
                {
                    SetFocus(interactable);
                    
                    DamageReceiver damageReceiver = hit.collider.GetComponent<DamageReceiver>();
                    if (damageReceiver)
                    {
                        Attack(damageReceiver);
                    }
                }
            }
        }
    }

    
    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowTarget();

    }

    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        
        newFocus.OnFocused(transform);
        
    }


}
