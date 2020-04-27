using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
    public static PlayerInventory Instance {get; set;}
    private List<Item> inventory = new List<Item>();

    // Start is called before the first frame update
    private void Start(){
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
    }

    // Update is called once per frame
    private void Update(){
        
    }

    public void AddItem(string itemName){
        switch(itemName){
            case "stick":
                inventory.Add(new ItemStick(0, itemName));
                break;
        }
        foreach(Item item in inventory){
            Debug.Log(item.GetItemName());
        }
    }
    public void RemoveItem(string itemName){
        inventory.Remove(GetItem(itemName));
        foreach(Item item in inventory){
            Debug.Log(item.GetItemName());
        }
    }
    public Item GetItem(string itemName){
        return inventory.Find(x => x.GetItemName() == itemName);
    }
}
