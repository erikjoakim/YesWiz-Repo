using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HandleInput: MonoBehaviour {

    public delegate void handleInput(GameObject obj, bool isInteractable);
    public event handleInput handleInputEV;

    GameObject gameObj;
    public Interactable selectedInteractable;
    
    Color originalColor;
    
    // Use this for initialization
    void Start () {
        gameObj = new GameObject("NoObject");
    }
	
	// Update is called once per frame
	void Update () {
        Interactable currentInteractable;
        RaycastHit hit;
        MeshRenderer meshRenderer;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
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
                    meshRenderer = selectedInteractable.gameObject.GetComponent<MeshRenderer>();
                    originalColor = meshRenderer.material.color;
                    meshRenderer.material.SetColor("_Color", Color.cyan);
                    handleInputEV(hit.collider.gameObject, true);
                }
            }
            else
            {
                if (selectedInteractable != null)
                {
                    meshRenderer = selectedInteractable.gameObject.GetComponent<MeshRenderer>();
                    meshRenderer.material.color = originalColor;
                    selectedInteractable = null;
                }
                gameObj.transform.position = hit.point;
                handleInputEV(gameObj, false);
            }
        }
    }
}
