using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button removeButton;
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        Debug.Log("add"+item.name);
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Debug.Log("me fui");
        Inventory.instance.Remove(item);
    }
    public void UseUtem()
    {
        Debug.Log("usame");
        if(item!=null)
        {
            Debug.Log("itemnonulo");
            item.Use();
        }
    }
}


//using UnityEngine;
//using UnityEngine.UI;

///* Sits on all InventorySlots. */

//public class InventorySlot : MonoBehaviour {

//	public Image icon;			// Reference to the Icon image
//	public Button removeButton;	// Reference to the remove button

//	Item item;  // Current item in the slot

//	// Add item to the slot
//	public void AddItem (Item newItem)
//	{
//		item = newItem;

//		icon.sprite = item.icon;
//		icon.enabled = true;
//		removeButton.interactable = true;
//	}

//	// Clear the slot
//	public void ClearSlot ()
//	{
//		item = null;

//		icon.sprite = null;
//		icon.enabled = false;
//		removeButton.interactable = false;
//	}

//	// Called when the remove button is pressed
//	public void OnRemoveButton ()
//	{
//		Inventory.instance.Remove(item);
//	}

//	// Called when the item is pressed
//	public void UseItem ()
//	{
//		if (item != null)
//		{
//			item.Use();
//		}
//	}

//}
