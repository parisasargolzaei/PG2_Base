using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{
    public ConsumableItem(string name, int worth, int currentlyOwnedQuantity = 0)
    {
        itemName = name;
        itemWorth = worth;
        ownedQunatity = currentlyOwnedQuantity;
    }

    public override void Use()
    {
        ownedQunatity--;
        PlayerManager.playermanager.player.GetComponent<CharacterStats>().RestoreHealth(itemWorth);
        Debug.Log($"Item {itemName} is used. Now remaining {GetOwnedQuantity()}");
    }
}
