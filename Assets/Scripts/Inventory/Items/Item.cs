using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    private string itemName;
    private int itemID;
    private bool craftable;

    public Item(){
        itemID = -1;
        itemName = "default";
        craftable = false;
    }

    public virtual string GetItemName(){
        return itemName;
    }

    public virtual int GetItemID(){
        return itemID;
    }
}
