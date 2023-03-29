using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName;
    public int itemWorth;
    protected int ownedQunatity;

    public int GetOwnedQuantity()
    {
        return ownedQunatity;
    }

    public void PurchaseItem()
    {
        Debug.Log($"Item {itemName} is puchased with {itemWorth} price");
        ownedQunatity++;
    }

    public virtual void Use()
    {}
}
