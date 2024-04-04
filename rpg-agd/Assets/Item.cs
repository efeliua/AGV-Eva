using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] //donde lo creamos
public class Item : ScriptableObject
{
    new public string name = "new Item"; //theres already a property name, we overwrite
    public Sprite icon = null; //icon
    public bool isDefaultItem = false;

}
