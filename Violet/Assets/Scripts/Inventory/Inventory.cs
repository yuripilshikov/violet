using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    // We will use singleton pattern here.
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    // And we sill also use delegates.
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20; // amount of slots

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room!");
                return false;
            }
            items.Add(item);

            // Triggering an event
            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            
        }
        return true;
        
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        // Triggering an event
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
