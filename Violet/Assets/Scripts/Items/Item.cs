using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New item"; // to override "name" property
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        // use an item
        // something happens

        Debug.Log("Using " + name);
    }
}
