using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField]
    private int x;
    [SerializeField]
    private int y;
    [SerializeField]
    private int length;

    public int tileX {
        get { return x; }
        set { x = value; }
           
    }
    
    public int tileY
    {
        get { return y; }
        set { y = value; }
    }
    
    public int shortestPathLength
    {
        get { return length; }
    }

    public GameObject[] connectedGameObject = new GameObject[4];

    
    

    public void shortestPathCalculation()
    {

    }
    //test
    public void nextMap()
    {

    }
}
