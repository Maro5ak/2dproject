using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour{
    public delegate void ItemHandler(Item item, Vector2 position);
    public static event ItemHandler OnItemDropped;

    public delegate void InventoryHandler(Item item);
    public static event InventoryHandler OnItemAdded;

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
  
}
