using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item; //Scriptable 
    public override void Interact()
    {
        base.Interact(); //code of parent interatcable

        PickUp(); //pick up
    }
    void PickUp()
    {
        Debug.Log("Picking up"+item.name);
        bool wasPickedUp = Inventory.Instance.Add(item);
        Destroy(gameObject);

    }
}
