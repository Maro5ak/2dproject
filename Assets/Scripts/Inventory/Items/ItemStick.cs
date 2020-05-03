using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStick : Item{

    private string itemName;
    private int itemID;
    private bool craftable;
    
    public ItemStick(){
        this.itemID = 0;
        this.itemName = "stick";
        craftable = false;
    }

    public override string GetItemName(){
        return itemName;
    }

    public override int GetItemID(){
        return itemID;
    }

}
