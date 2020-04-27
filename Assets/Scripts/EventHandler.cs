using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour{
    public delegate void ItemHandler(Item item);
    public static event ItemHandler OnItemDropped;

    public static void ItemDropped(Item item){
        if(OnItemDropped != null){
            OnItemDropped(item);
        }
    }
  
}
