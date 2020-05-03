using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour{

    public static InventoryUI Instance {get;set;}

    public RectTransform viewContent;
    public RectTransform inventoryUI;
    public Text inventorySize;
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

        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");

        EventHandler.OnItemAdded += UpdateInventory;
        EventHandler.OnItemRemoved += RemoveItem;

        inventoryToggle = false;
        itemSelected = false;
        inventoryUI.gameObject.SetActive(inventoryToggle);
        inventorySize.text = "0/49";
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
                UpdateInventorySize();
            }
        }
    }

    private void UpdateInventory(Item item){
        int itemCount = PlayerInventory.Instance.GetItemCount(item.GetItemID());
        if(itemCount > 1){
            viewContent.Find("item_id:" + item.GetItemID()).GetComponent<InventoryUIItem>().number.text = itemCount.ToString(); 
        }
        else{
            InventoryUIItem emptyItem = Instantiate(itemContainer);
            emptyItem.SetItem(item);
            emptyItem.name = "item_id:" + item.GetItemID().ToString();
            emptyItem.transform.SetParent(viewContent);
        }
        UpdateInventorySize();
    }


    private void ToggleInventory(){
        inventoryToggle = !inventoryToggle;
        inventoryUI.gameObject.SetActive(inventoryToggle);
    }
    private void RemoveItem(Item item){
        foreach(Transform child in viewContent){
            if(child.name == "item_id:" + item.GetItemID()){
                int itemCount = PlayerInventory.Instance.GetItemCount(item.GetItemID()) - 1;
                if(itemCount < 1){
                    Destroy(child.gameObject);
                }
                else{
                    child.GetComponent<InventoryUIItem>().number.text = itemCount.ToString();
                }
            }
        }
        
    }

    private void UpdateInventorySize(){
        inventorySize.text = PlayerInventory.Instance.GetInventorySize() + "/49";
    }

    public void ToggleItemSelect(Item item, Button button){
        itemSelected = !itemSelected;
        selectedItem = item;
    }

}
