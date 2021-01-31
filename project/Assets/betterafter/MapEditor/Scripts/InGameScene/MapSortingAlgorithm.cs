using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSortingAlgorithm : MonoBehaviour
{
    // 4 * 4 맵
    const int arraySize = 5;
    Object[] TileMaps;

    public GameObject testMapImage;
    public GameObject testPathImage;
    public GameObject textMesh;

    public GameObject[,] stageMap;

    private void Awake()
    {
        TileMaps = Resources.LoadAll("betterafter/Tilemap/prefabs");
    }

    // Start is called before the first frame update
    void Start()
    {
        stageMap = new GameObject[arraySize, arraySize];
        RandomArrangement();
        connection();
        ChunkConnection();
        MapEditor();

        mapInit();
    }

    // 맵을 좌표상에 랜덤으로 배치하는 계산................................................
    void RandomArrangement()
    {
        Object[] temp;
        int x = 0, y = 0;
        temp = TileMaps;
        while (temp.Length > 0)
        {
            int ran = Random.Range(0, temp.Length);
            if(x > arraySize - 1)
            {
                x = 0; y++;
            }
            stageMap[x, y] = temp[ran] as GameObject;
            TileMap tempTileMap = stageMap[x, y].GetComponent<TileMap>();
            tempTileMap.tileX = x; tempTileMap.tileY = y;
            for (int i = 0; i < 4; i++) tempTileMap.connectedGameObject[i] = null;
            temp = removeFromList(temp, ran);
            x++;
        }

    }

    Object[] removeFromList(Object[] maps, int idx)
    {
        Object[] res = new Object[maps.Length - 1];

        int mapsIdx = 0;
        for(int i = 0; i < maps.Length; i++)
        {
            if (i != idx)
            {
                res[mapsIdx] = maps[i];
                mapsIdx++;
            }
        }
        return res;
    }
    //..........................................................................


    // 모든 방이 서로 통하도록 하는 계산................................................

    bool[,] isConnected;
    int[,] direction = new int[4, 2] { { 0 , 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

    void connection()
    {
        isConnected = new bool[arraySize, arraySize];
        for(int i = 0; i < arraySize; i++) { for (int j = 0; j < arraySize; j++) isConnected[i, j] = false; }

        for (int i = 0; i < arraySize; i++)
        {
            for (int j = 0; j < arraySize; j++)
          {
                if (!isConnected[i, j])
                {
                    mapConnectionDFS(new KeyValuePair<int, int>(i, j));
                }
            }
        }
    }


    // DFS로 만드니까 연결이 되지 않는 간선이 생긴다.
    // 연결이 한번도 되지 않은 점을 찾아 한번도 방문하지 않은 점을 위주로 길을 만들고, 사방이 "한번이라도 연결이 되었던 점"으로만 둘러쌓일 경우에
    // 주변의 네개의 점 중 아무거나 랜덤으로 연결시키고 종료한다. 
    void mapConnectionDFS(KeyValuePair<int, int> kvp)
    {
        isConnected[kvp.Key, kvp.Value] = true;
        int ran, x, y;

        GameObject thisTileMapObject;
        GameObject connectedTileMapObject;
        TileMap thisTileMap;
        TileMap connectedTileMap;

        // 주변이 맵을 벗어나는지 확인한다.
        // direction은 0 <-> 1 , 2 <-> 3  과 대치된다. 
        bool[] isDirection = new bool[4] { false, false, false, false };
        for (int i = 0; i < 4; i++)
        {
            x = kvp.Key + direction[i, 0]; y = kvp.Value + direction[i, 1];
            if (x >= 0 && x < arraySize && y >= 0 && y < arraySize)
            {
                isDirection[i] = true;
            }
        }

        // 사방이 "한번이라도 연결이 되었던 점"이라면 그 중에 아무거나 선택해서 연결해주고 종료시켜준다.
        bool isAroundAllConnected = true;
        for(int i = 0; i < 4; i++)
        {
            x = kvp.Key + direction[i, 0]; y = kvp.Value + direction[i, 1];
            if (isDirection[i] && !isConnected[x, y]) isAroundAllConnected = false;
        }
        if (isAroundAllConnected)
        {
            ran = Random.Range(0, 4);
            while (!isDirection[ran]) ran = Random.Range(0, 4);

            thisTileMapObject = stageMap[kvp.Key, kvp.Value];
            connectedTileMapObject = stageMap[kvp.Key + direction[ran, 0], kvp.Value + direction[ran, 1]];

            // 각각 연결을 선언해준다.
            thisTileMap = thisTileMapObject.GetComponent<TileMap>();
            connectedTileMap = connectedTileMapObject.GetComponent<TileMap>();

            thisTileMap.connectedGameObject[ran] = connectedTileMapObject;
            if (ran == 0)
            {
                connectedTileMap.connectedGameObject[1] = thisTileMapObject;
            }
            else if (ran == 1)
            {
                connectedTileMap.connectedGameObject[0] = thisTileMapObject;
            }
            else if (ran == 2)
            {
                connectedTileMap.connectedGameObject[3] = thisTileMapObject;
            }
            else if (ran == 3)
            {
                connectedTileMap.connectedGameObject[2] = thisTileMapObject;
            }
            return;
        }

        // 주변에 연결이 된적이 없는 점이 하나라도 있다면 그 점을 연결해준다.
        ran = Random.Range(0, 4);
        x = kvp.Key + direction[ran, 0]; y = kvp.Value + direction[ran, 1];
        while (!isDirection[ran] || isConnected[x, y])
        {
            ran = Random.Range(0, 4);
            x = kvp.Key + direction[ran, 0]; y = kvp.Value + direction[ran, 1];
        }
        thisTileMapObject = stageMap[kvp.Key, kvp.Value];
        connectedTileMapObject = stageMap[x, y];
        isConnected[x, y] = true;

        // 각각 연결을 선언해준다.
        thisTileMap = thisTileMapObject.GetComponent<TileMap>();
        connectedTileMap = connectedTileMapObject.GetComponent<TileMap>();

        thisTileMap.connectedGameObject[ran] = connectedTileMapObject;
        if (ran == 0) connectedTileMap.connectedGameObject[1] = thisTileMapObject;
        else if (ran == 1) connectedTileMap.connectedGameObject[0] = thisTileMapObject;
        else if (ran == 2) connectedTileMap.connectedGameObject[3] = thisTileMapObject;
        else if (ran == 3) connectedTileMap.connectedGameObject[2] = thisTileMapObject;
        mapConnectionDFS(new KeyValuePair<int, int>(x, y));
    }


    bool[,] ChunkCheck = new bool[arraySize, arraySize];
    List<Chunk> ChunkList = new List<Chunk>();
    void ChunkConnection()
    {
        for (int i = 0; i < arraySize; i++) { for (int j = 0; j < arraySize; j++) ChunkCheck[i, j] = false; }

        for(int i = 0; i < arraySize; i++)
        {
            for(int j = 0; j < arraySize; j++)
            {
                if (!ChunkCheck[i, j])
                {
                    Chunk chunk = new Chunk();
                    FindPath(new KeyValuePair<int, int>(i, j), chunk);
                    ChunkList.Add(chunk);
                }
            }
        }

        Debug.Log(ChunkList.Count);

        bool[,] ChunkListCheck = new bool[ChunkList.Count, ChunkList.Count];
        for (int i = 0; i < ChunkList.Count; i++) { for (int j = 0; j < ChunkList.Count; j++) ChunkListCheck[i, j] = false; }
        // ChunkList를 돌면서 모든 Chunk들에 대해 연결이 가능한 Chunk들을 연결해준다.
        int ii = 0;
        foreach(Chunk c1 in ChunkList)
        {
            int jj = 0;
            foreach(Chunk c2 in ChunkList)
            {
                if (ChunkListCheck[ii, jj] || ChunkListCheck[jj, ii])
                {
                    jj++; continue;
                }
                if (ii == jj) continue;
                List<KeyValuePair<int, int>> elem1 = c1.element;
                List<KeyValuePair<int, int>> elem2 = c2.element;

                bool isChunkConnected = false;
                foreach(KeyValuePair<int, int> kvp1 in elem1)
                {
                    if (isChunkConnected) break;
                    foreach (KeyValuePair<int, int> kvp2 in elem2)
                    {
                        if (isChunkConnected) break;
                        int x1 = kvp1.Key; int y1 = kvp1.Value;
                        int x2 = kvp2.Key; int y2 = kvp2.Value;

                        if(Mathf.Abs(x1 - x2) + Mathf.Abs(y1 - y2) == 1)
                        {
                            Debug.Log("(" + x1 + " , " + y1 + ")   (" + x2 + " , " + y2 + ")");
                            GameObject curr = stageMap[x1, y1];
                            GameObject next = stageMap[x2, y2];

                            // 0 : 위. 1 : 아래, 2 : 왼쪽, 3 : 오른쪽
                            if (x1 < x2)
                            {
                                curr.GetComponent<TileMap>().connectedGameObject[2] = next;
                                next.GetComponent<TileMap>().connectedGameObject[3] = curr;
                            }
                            else if (x1 > x2)
                            {
                                curr.GetComponent<TileMap>().connectedGameObject[3] = next;
                                next.GetComponent<TileMap>().connectedGameObject[2] = curr;
                            }
                            else if (y1 < y2)
                            {
                                curr.GetComponent<TileMap>().connectedGameObject[0] = next;
                                next.GetComponent<TileMap>().connectedGameObject[1] = curr;
                            }
                            else if (y1 > y2)
                            {
                                curr.GetComponent<TileMap>().connectedGameObject[1] = next;
                                next.GetComponent<TileMap>().connectedGameObject[0] = curr;
                            }
                            isChunkConnected = true;
                            ChunkListCheck[ii, jj] = true;
                            ChunkListCheck[jj, ii] = true;
                        }
                    }
                }
            }
            ii++;
        }
    }

    void FindPath(KeyValuePair<int, int> kvp, Chunk chunk)
    {
        int x = kvp.Key; int y = kvp.Value;

        ChunkCheck[x, y] = true;
        chunk.element.Add(new KeyValuePair<int, int>(x, y));

        for(int i = 0; i < 4; i++)
        {
            int nx = x + direction[i, 0]; int ny = y + direction[i, 1];
            if(nx >= 0 && nx < arraySize && ny >= 0 && ny < arraySize && !ChunkCheck[nx, ny])
            {
                TileMap cTM = stageMap[x, y].GetComponent<TileMap>();
                if (cTM.connectedGameObject[i] != null && stageMap[nx,ny] != null && cTM.connectedGameObject[i] == stageMap[nx, ny])
                {
                    FindPath(new KeyValuePair<int, int>(nx, ny), chunk);
                }
            }
        }
    } 

    private class Chunk
    {
        public List<KeyValuePair<int, int>> element = new List<KeyValuePair<int, int>>();
    }


    void MapEditor()
    {
        for(int i = 0; i < arraySize; i++)
        {
            for(int j = 0; j < arraySize; j++)
            {
                GameObject temp = Instantiate(testMapImage, new Vector3(i * 2, j * 2), Quaternion.identity, GameObject.Find("Canvas").transform);
                GameObject text = Instantiate(textMesh, new Vector3(i * 2, j * 2), Quaternion.identity, GameObject.Find("Canvas").transform);
                text.GetComponent<TextMesh>().text = stageMap[i, j].name;

                GameObject curr = stageMap[i, j];
                TileMap tm = curr.GetComponent<TileMap>();
                tm.Init();
                for (int k = 0; k < 4; k++)
                {
                    if(tm.connectedGameObject[k] != null)
                    {
                        
                        GameObject connectedObject = tm.connectedGameObject[k];
                        TileMap connectedObjectTilemap = connectedObject.GetComponent<TileMap>();

                        int nx = connectedObjectTilemap.tileX; int ny = connectedObjectTilemap.tileY;
                        float cx = (i + nx) / 2f; float cy = (j + ny) / 2f;
                        Instantiate(testPathImage, new Vector3(cx * 2, cy * 2), Quaternion.identity);
                    }
                }
            }
        }


    }

    void mapInit()
    {
        int x = Random.Range(0, arraySize);
        int y = Random.Range(0, arraySize);

        Instantiate(stageMap[x, y], new Vector3(0, 0), Quaternion.identity);
    }
}
