using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStick : Item{

    private string itemName;
    private int itemID;
    
    public ItemStick(int itemID, string itemName){
        this.itemID = itemID;
        this.itemName = itemName;
    }

    public override string GetItemName(){
        return itemName;
    }

}
