﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour{
    public Tilemap tilemap;
    public LayerMask interactLayerMask;
    private float speed = 7f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Collider2D col;
    
    // Start is called before the first frame update
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update(){
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));     
        col = Physics2D.OverlapCircle(transform.position, 1f, interactLayerMask);
        if(Input.GetKeyDown(KeyCode.E)){
            if(col.tag != null){
                if(col.tag == "Sign"){
                    col.GetComponent<Sign>().Interact();
                }
                else if(col.tag == "Stick"){
                    col.GetComponent<Stick>().PickUp();
                }
                else if(col.tag == "Log"){
                    col.GetComponent<Log>().PickUp();
                }
                else if(col.tag == "Tree"){
                    col.GetComponent<TreeClass>().ChopTree();
                }
            }
        }
        else if(Input.GetKeyDown(KeyCode.Q)){
            EventHandler.ItemDropped(PlayerInventory.Instance.GetItem("stick"), transform.position);
            PlayerInventory.Instance.RemoveItem("stick");
        }

        
    }
    private void FixedUpdate(){
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

}
