using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MakingEmptyTile : MonoBehaviour
{
    [SerializeField]
    private Vector3Int[] examplePosition = new Vector3Int[3];
    private TileBase[] exampleTileBase = new TileBase[3];
    public Tilemap exampleTilemap;


    // Start is called before the first frame update
    public void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            examplePosition[i] = new Vector3Int(-17, -13 - i, 0);
            exampleTileBase[i] = null;
        }
        Tilemap exampleTilemap = GetComponent<Tilemap>();
        exampleTilemap.SetTiles(examplePosition, exampleTileBase);
        ReadTxt("Assets/pungpungpung/Textfiles/Coordinates of Maps.txt");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    string ReadTxt(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        string value = "";

        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(filePath);
            int lineIndex = 0;
            while (true)
            { 
                value = reader.ReadLine();
                lineIndex++;
                if (value == null) { break; }
                Debug.Log(value);
            }
            reader.Close();
        }
        else
            value = "File doesn't exist";
        return value;
    }
}
