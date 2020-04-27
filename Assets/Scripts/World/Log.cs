using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Pickable{
    public override void PickUp(){
        PlayerInventory.Instance.AddItem("log");
        Destroy(this.gameObject);
    }
}
