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

    private Vector3Int size;
    private enum GenerationRarity{
        STICK = 350,
        ROCK = 450,
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
        //event subs
        EventHandler.OnItemDropped += SpawnDroppedItem;
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
        if(item.GetItemName() == "stick"){
            Instantiate(stickSprite, position, default);
        }
        else if(item.GetItemName() == "log"){ 
            Instantiate(logSprite, position + (Random.insideUnitCircle * Random.Range(-2, 2)), default);
        }
    }
}
