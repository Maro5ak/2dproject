using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGen : MonoBehaviour{
    //public:
    public static WorldGen Instance{get; set;}
    public Tilemap tilemap;
    //private:
    //sprites
    private Transform stickSprite;
    private Transform logSprite;
    private Transform treeSprite;
    private Transform trunkSprite;

    private Vector3Int size;
    private enum GenerationRarity{
        STICK = 350,
        TREE = 1500
    }

    private void Start() {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
        //resource loading
        stickSprite = Resources.Load<Transform>("Sprites/Stick");
        logSprite = Resources.Load<Transform>("Sprites/Log");
        treeSprite = Resources.Load<Transform>("Sprites/Tree");
        trunkSprite = Resources.Load<Transform>("Sprites/Tree_trunk");

        //event subs
        EventHandler.OnItemDropped += SpawnDroppedItem;
        EventHandler.OnWorldItemDropped += SpawnWorldDropItem;
        //others
        Debug.Log(tilemap.size);
        GenerateWorld();
    }

    private void GenerateWorld(){
        for(int x = -(tilemap.size.x / 2); x < tilemap.size.x / 2; x++){
            for(int y = -(tilemap.size.y / 2); y < tilemap.size.y / 2; y++){
                if(Random.Range(0, (int)GenerationRarity.STICK) == 1){
                    Instantiate(stickSprite, new Vector2(x, y), default);
                }
                if(Random.Range(0, (int)GenerationRarity.TREE) == 1){
                    Instantiate(treeSprite, new Vector2(x, y), default);
                }
            }
        }
    }


    public void SpawnDroppedItem(Item item, Vector2 position){
        //Player drops
        if(item.GetItemName() == "stick"){
            Instantiate(stickSprite, position, default);
        }
        else if(item.GetItemName() == "log"){
            Instantiate(logSprite, position, default);
        }
        
        
    }
    
    private void SpawnWorldDropItem(Item item, Vector2 position){
        //World drops
        if(item.GetItemName() == "log"){ 
            Instantiate(trunkSprite, new Vector2(position.x, position.y -0.9f), default);
            Instantiate(logSprite, position + (Random.insideUnitCircle * Random.Range(-2, 2)), default);
        }
    }
}
