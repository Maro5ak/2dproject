using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : Pickable{

    public override void PickUp(){
        PlayerInventory.Instance.AddItem("stick");
        Destroy(this.gameObject);
    }

    
}
