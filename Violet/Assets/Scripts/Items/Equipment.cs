using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh; // mesh of the item
    public EquipmentMeshRegion[] coveredMeshRegions; // blend shapes. Array because more than one mesh regions may be covered with clothes/armor
    
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();

        // Equip item
        EquipmentManager.instance.Equip(this);
        // Remove it from inventory
        RemoveFromInventory();
    }
}

public enum EquipmentSlot {  Head, Chest, Legs, Weapon, Shield, Feet }

public enum EquipmentMeshRegion { BodySuitIsEquipped } // corresponding to blend shapes
