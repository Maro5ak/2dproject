using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStick : Item{

    private string itemName;
    private int itemID;
    
    public ItemStick(){
        this.itemID = 0;
        this.itemName = "stick";
    }

    public override string GetItemName(){
        return itemName;
    }

}
