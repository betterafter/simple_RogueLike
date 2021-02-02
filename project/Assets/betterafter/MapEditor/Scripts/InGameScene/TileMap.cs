using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

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

    private GameObject player;

    public Image handle;
    public Image outLine;
    private Canvas canvas;


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

    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outLine = canvas.gameObject.transform.GetChild(0).GetComponent<Image>();
        handle = outLine.gameObject.transform.GetChild(0).GetComponent<Image>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        CollideController();
    }

    private bool LadderUseDetection()
    {
        tempPlayerMove tempPlayerMove = player.GetComponent<tempPlayerMove>();

        if ((handle.rectTransform.anchoredPosition.x >= -15 && handle.rectTransform.anchoredPosition.x <= 15) &&
            handle.rectTransform.anchoredPosition.y <= -(outLine.rectTransform.sizeDelta.x / 6) &&
            tempPlayerMove.isLadderCollide[1]) return true;
        else if ((handle.rectTransform.anchoredPosition.x >= -15 && handle.rectTransform.anchoredPosition.x <= 15) &&
            handle.rectTransform.anchoredPosition.y >= outLine.rectTransform.sizeDelta.x / 6 &&
            tempPlayerMove.isLadderCollide[0]) return true;
        else return false;
    }

    private void CollideController()
    {
        GameObject platform = gameObject.transform.GetChild(0).gameObject.transform.Find("PlatformTilemap").gameObject;
        TilemapCollider2D col = platform.GetComponent<TilemapCollider2D>();

        if (LadderUseDetection()) col.enabled = false;
        else col.enabled = true;
    }
}
