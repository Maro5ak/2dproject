using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour{

    public static InventoryUI Instance {get;set;}

    public RectTransform viewContent;
    public RectTransform inventoryUI;
    private InventoryUIItem itemContainer;
    private Item selectedItem;

    private bool inventoryToggle, itemSelected;
    
    void Start(){
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }

        itemContainer = Resources.Load<InventoryUIItem>("Item_Container");

        EventHandler.OnItemAdded += UpdateInventory;
        EventHandler.OnItemRemoved += RemoveItem;

        inventoryToggle = false;
        itemSelected = false;
        inventoryUI.gameObject.SetActive(inventoryToggle);
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleInventory();
        }
        else if(itemSelected){
            if(Input.GetKeyDown(KeyCode.Q)){
                PlayerInventory.Instance.RemoveItem(this.selectedItem.GetItemName());
                itemSelected = false;
            }
        }
    }

    private void UpdateInventory(Item item){
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(viewContent);
    }

    private void ToggleInventory(){
        inventoryToggle = !inventoryToggle;
        inventoryUI.gameObject.SetActive(inventoryToggle);
    }
    private void RemoveItem(List<Item> inventory){
        foreach(Transform child in viewContent){
            Destroy(child.gameObject);
        }
        foreach(Item item in inventory){
            UpdateInventory(item);
        }
    }

    public void ToggleItemSelect(Item item, Button button){
        itemSelected = !itemSelected;
        selectedItem = item;
    }

}
