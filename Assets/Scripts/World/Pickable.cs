﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour{
    public virtual void PickUp(){
        Debug.Log("Picked up <default>");
    }
}
