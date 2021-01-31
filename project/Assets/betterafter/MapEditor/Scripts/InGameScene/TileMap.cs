using System;
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
    [SerializeField]
    private int bx;
    [SerializeField]
    private int by;

    private const int arraySize = 5;
    private int[,] PathLength;

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

    public int bossX
    {
        get { return bx; }
    }

    public int bossY
    {
        get { return by; }
    }

    public GameObject[] connectedGameObject = new GameObject[4];


    public void Init()
    {
        length = 0;
        PathLength = new int[arraySize, arraySize];
        for (int i = 0; i < arraySize; i++) { for (int j = 0; j < arraySize; j++) { PathLength[i, j] = 100000; } }
        PathLength[tileX, tileY] = 0;

        shortestPathCalculation(this.gameObject, 0);
        for(int i = 0; i < arraySize; i++)
        {
            for(int j = 0; j < arraySize; j++)
            {
                if(length < PathLength[i, j])
                {
                    length = PathLength[i, j];
                    bx = i; by = j;
                }
            }
        }
    }



    public void shortestPathCalculation(GameObject currentObject, int len)
    {
        TileMap currentTileMap = currentObject.GetComponent<TileMap>();
        for (int i = 0; i < 4; i++)
        {
            if(currentTileMap.connectedGameObject[i] != null)
            {
                GameObject temp = currentTileMap.connectedGameObject[i];
                int xx = temp.GetComponent<TileMap>().tileX;
                int yy = temp.GetComponent<TileMap>().tileY;
                if (PathLength[xx, yy] > len + 1)
                {
                    PathLength[xx, yy] = len + 1;
                    shortestPathCalculation(temp, len + 1);
                }
            }
        }
    }
}
