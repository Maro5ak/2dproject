using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour{
    public delegate void ItemHandler(Item item, Vector2 position);
    public static event ItemHandler OnItemDropped;
    public static event ItemHandler OnWorldItemDropped;

    public delegate void InventoryHandler(Item item);
    public static event InventoryHandler OnItemAdded;
    public delegate void UpdateInventory(List<Item> inventory);
    public static event InventoryHandler OnItemRemoved;

    public static void ItemDropped(Item item, Vector2 position){
        if(OnItemDropped != null){
            OnItemDropped(item, position);
        }
    }
    public static void ItemAdded(Item item){
        if(OnItemAdded != null){
            OnItemAdded(item);
        }
    }
    public static void ItemRemoved(Item item){
        if(OnItemRemoved != null){
            OnItemRemoved(item);
        }
    }

    public static void WorldItemDropped(Item item, Vector2 position){
        if(OnWorldItemDropped != null){
            OnWorldItemDropped(item, position);
        }
    }
  
}
