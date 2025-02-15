using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attacked to tiles so each tile have its own position recorded
public class Tile : MonoBehaviour
{
    public int Gridx;
    public int Gridy;

    public void TileInfo(int i, int j)//this helps to represent grids position
    {
        Gridx = i;
        Gridy = j;
    }
}
