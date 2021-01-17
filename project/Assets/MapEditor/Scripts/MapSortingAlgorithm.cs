using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSortingAlgorithm : MonoBehaviour
{
    int stageSize = 0;
    Object[] TileMaps;
    ArrayList ConnectedTileMap = new ArrayList();
    ArrayList notConnectedTileMap = new ArrayList();

    public GameObject[,] stageMap;

    private void Awake()
    {
        TileMaps = Resources.LoadAll("Tilemap/prefabs");
        stageSize = TileMaps.Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        stageMap = new GameObject[3, 3];



    }


    void RandomArrangement()
    {

    }

}
