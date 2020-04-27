using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour{
    public void PickUp(){
        PlayerInventory.Instance.AddItem("log");
        Destroy(this.gameObject);
    }
}
