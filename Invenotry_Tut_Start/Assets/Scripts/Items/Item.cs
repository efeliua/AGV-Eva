//using UnityEngine;

///* The base item class. All items should derive from this. */

//[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
//public class Item : ScriptableObject {

//	new public string name = "New Item";	// Name of the item
//	public Sprite icon = null;				// Item icon
//	public bool isDefaultItem = false;      // Is the item default wear?

//	// Called when the item is pressed in the inventory
//	public virtual void Use ()
//	{
//		// Use the item
//		// Something might happen

//		Debug.Log("Using " + name);
//	}

//	public void RemoveFromInventory ()
//	{
//		Inventory.instance.Remove(this);
//	}

//}

using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] //donde lo creamos
public class Item : ScriptableObject
{
    new public string name = "new Item"; //theres already a property name, we overwrite
    public Sprite icon = null; //icon
    public bool isDefaultItem = false;

    //if you use the item
    public virtual void Use() //virtual para que cada item tenga su uso 
    {
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}

