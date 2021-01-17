using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public int tileX {
        get { return tileX; }
        set { tileX = value; }
           
    }
    public int tileY
    {
        get { return tileY; }
        set { tileY = value; }
    }
    public int shortestPathLength
    {
        get { return shortestPathLength; }
    }

    public ArrayList connectedTileMap = new ArrayList();

    
    

    public void shortestPathCalculation()
    {

    }
    //test
    public void nextMap()
    {

    }
}
