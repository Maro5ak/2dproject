using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLog : Item{
    private string itemName;
    private int itemID;
    private bool craftable;
    
    public ItemLog(){
        this.itemID = 1;
        this.itemName = "log";
        craftable = false;
    }

    public override string GetItemName(){
        return itemName;
    }

    public override int GetItemID(){
        return itemID;
    }
}
