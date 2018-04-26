using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float stopDistance;
    Renderer rend;
    Color originalColor;

    private void Start()
    {
        
        rend = GetComponent<Renderer>(); 
        if (rend == null)
        {
            rend = GetComponentInChildren<Renderer>();
        }
        originalColor = rend.material.color;
    }
    public void onGotFocus()
    {
        rend.material.SetColor("_Color", Color.cyan);
    }
    public void onLostFocus()
    {
        rend.material.color = originalColor;
    }
    public void onFocus()
    {
        
    }
}
