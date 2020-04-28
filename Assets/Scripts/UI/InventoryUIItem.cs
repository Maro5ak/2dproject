using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour{
    public Item item;
    public Image itemIcon;
    
    public void SetItem(Item item){
        this.item = item;
        itemIcon.sprite = Resources.Load<Sprite>("Sprites/SpriteRoot/" + item.GetItemName());
    }
}
