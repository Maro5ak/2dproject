using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLog : Item{
    private string itemName;
    private int itemID;
    
    public ItemLog(){
        this.itemID = 1;
        this.itemName = "log";
    }

    public override string GetItemName(){
        return itemName;
    }
}
