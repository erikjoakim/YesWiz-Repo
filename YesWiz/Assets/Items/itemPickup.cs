using System;
using UnityEngine;

public class itemPickup : Interactable {

    public Item item;
    public override void Interact()
    {
        base.Interact();
        Pickup();
    }

    private void Pickup()
    {
        Debug.Log("Picking up: " + item.name);
        bool wasPickedup = Inventory.instance.Add(item);
        if (wasPickedup)
        {
            Destroy(gameObject);
        }
    }
}
