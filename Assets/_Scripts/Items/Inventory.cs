using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;

    public ItemController<ConsumableItem> consumableItemsController;
    public ItemController<NonConsumableItem> nonConsumableItemsController;

    private void Awake() {
        if(inventory == null)
        {
            inventory = this;
        }

        CreateInventory();
    }

    public void CreateInventory()
    {
        consumableItemsController = new ItemController<ConsumableItem>();
        nonConsumableItemsController = new ItemController<NonConsumableItem>();

        // Consumable Items
        consumableItemsController.AddItem(new ConsumableItem("Heart", 10, 1));

        // Non Consumable Items
        nonConsumableItemsController.AddItem(new NonConsumableItem("Coin", 1));
        nonConsumableItemsController.AddItem(new NonConsumableItem("BlueGem", 100));
    }
}
