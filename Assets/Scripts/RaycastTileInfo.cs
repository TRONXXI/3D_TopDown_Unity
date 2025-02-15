using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is used for raycasting from mouse pointer to any tile to get information of the tile
public class RaycastTileInfo : MonoBehaviour
{
    public Text tilePositionText;// text to know position of tile in grid
    public new Camera camera;
    // Update is called once per frame
    void Update()
    {
        //here ray moves from camera and store the information where it hits
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Tile tile = hit.collider.GetComponent<Tile>();//access the tile script from object it hit

            if (tile != null)
            {
                tilePositionText.text = $"Tile: ({tile.Gridx}, {tile.Gridy})";//this is UI coorditnates to display the position of tile in grid
            }
        }

    }
}
