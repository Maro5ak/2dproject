using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour{
    public RectTransform viewContent;
    public RectTransform inventoryUI;
    private InventoryUIItem itemContainer;

    private bool inventoryToggle;
    
    void Start(){

        itemContainer = Resources.Load<InventoryUIItem>("Item_Container");

        EventHandler.OnItemAdded += UpdateInventory;

        inventoryToggle = false;
        inventoryUI.gameObject.SetActive(inventoryToggle);
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleInventory();
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

}
