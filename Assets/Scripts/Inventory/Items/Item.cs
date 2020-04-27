using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    private string itemName;
    private int itemID;

    public Item(){
        itemID = -1;
        itemName = "default";
    }

    public virtual string GetItemName(){
        return itemName;
    }
}
