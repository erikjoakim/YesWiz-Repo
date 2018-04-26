using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

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
    public void onMouseEnterMe()
    {
        rend.material.SetColor("_Color", Color.cyan);
    }
    public void onMouseExitMe()
    {
        rend.material.color = originalColor;
    }
}
