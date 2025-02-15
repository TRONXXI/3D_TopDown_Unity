using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script create grid of tile according to given size
public class GridCreator : MonoBehaviour
{
    public GameObject tilePrefab;//tileprefab to spawn tiles
    public GameObject playerPrefab;//player to spawn
    public GameObject enemyPrefab;//enemy to spawn

    public int gridSizeX = 10;
    public int gridSizeY = 10;

    
    private List<GridTile> allTiles = new List<GridTile>();// stores all the tiles that are generated

    void Start()
    {
        GenerateGrid();
        
    }

    void GenerateGrid() //function to create grid
    {
        for (int x = 0; x < gridSizeX; x++) //first for loop is used for width
        {
            for (int y = 0; y < gridSizeY; y++) // second loop is used for height
            {
                Vector3 spawnPosition = new Vector3(x, 0, y);// position to spawn
                GameObject tileObject = Instantiate(tilePrefab, spawnPosition, Quaternion.identity); //instantiate the tile prefab in loop

                Tile tileinfo = tileObject.AddComponent<Tile>(); 
                tileinfo.TileInfo(x, y); //tile grid info is stored here
                
            }
        }

        Vector3 spawnPositionPlayer = new Vector3(0, 0, 0);
        Instantiate(playerPrefab, spawnPositionPlayer, Quaternion.identity);//spawn player

        Vector3 spawnPositionEnemy = new Vector3(9, 0, 9);
        Instantiate(enemyPrefab, spawnPositionEnemy, Quaternion.Euler(0, 180, 0));//spawn enemy

    }


  
}
