using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //singleton
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.LogWarning("More than one instance of Inventory found :(");
            return;
        }
        Instance = this;
    }
    //delegate
    public delegate void OnItemChanged();
    public OnItemChanged itemChangedCallback;
    //variables
    public int space = 20;

    //item list and methods
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space) {
                Debug.Log("Not enough space in inventory  :(");
                return false ;
            }
        }
        items.Add(item);

        if (itemChangedCallback != null)
            itemChangedCallback.Invoke();
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
