using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour{
    public void ChopTree(){
        for(int i = 0; i < 3; i++){
            EventHandler.WorldItemDropped(new ItemLog(), transform.position);
        }
        Destroy(this.gameObject);
    }
}
