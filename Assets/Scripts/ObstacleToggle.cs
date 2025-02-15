using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used for placing the obstacle in the tile
public class ObstaclePlacer : MonoBehaviour
{
    public GameObject obstaclePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))//mouse button, right click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//ray hits the tile and checks for collision
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GridTile tile = hit.collider.GetComponent<GridTile>();// access the gridtile script from object it hits

                if (tile != null && !tile.isOccupied)//check if tile is not occupied
                {
                    Instantiate(obstaclePrefab, tile.transform.position, Quaternion.identity);//instantiate obstacle
                    tile.isOccupied = true;
                }
            }
        }
    }
}
