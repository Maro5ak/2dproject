using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour{

    public void PickUp(){
        PlayerInventory.Instance.AddItem("stick");
        Destroy(this.gameObject);
    }
    
}
