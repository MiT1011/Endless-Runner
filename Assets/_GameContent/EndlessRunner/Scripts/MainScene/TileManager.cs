using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0; // spawn starting position
    public float tileLength = 30; // length of one tile
    public int numberOfTiles = 5; // tile object in running game
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform player;

    private void Start() {
        //will generate finite tiles with first default tile
        for(int i = 0 ; i < numberOfTiles ; i++){
            if(i == 0){
                SpawnTile(0);
            }
            else{
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    private void Update() {
        if(player.position.z - 35 > zSpawn - (numberOfTiles * tileLength)){
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex){
        GameObject obj = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(obj);
        zSpawn += tileLength;

    }
    private void DeleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
