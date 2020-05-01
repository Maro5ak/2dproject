using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour{
    public Item item;
    public Image itemIcon;

    private Button selectButton;

    private void Start() {
        selectButton = GetComponent<Button>();
        selectButton.onClick.AddListener(delegate {PerformAction();});
    }
    
    public void SetItem(Item item){
        this.item = item;
        itemIcon.sprite = Resources.Load<Sprite>("UI/Icons/" + item.GetItemName() + "_icon");
    }
    
    private void PerformAction(){
        InventoryUI.Instance.ToggleItemSelect(this.item, GetComponent<Button>());
    }


}
