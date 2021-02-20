using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MakingEmptyTile : MonoBehaviour
{
    //자료구조 Dictionary 사용
    private Dictionary<string, Vector3Int[]> dictionary;
    private Tilemap platformTilemap;
    private TileMap2 curTileMap;

    // Awake is called before the first frame update
    private void Awake()
    {
        dictionary = new Dictionary<string, Vector3Int[]>();
        
        

        //Tilemap 안에 있는 platformTilemap
        platformTilemap = GetComponent<Tilemap>();
        
        //Tilemap
        curTileMap = this.gameObject.GetComponentInParent<TileMap2>();
        
        ReadTxt("Assets/pungpungpung/Textfiles/Coordinates of Maps.txt", dictionary);
       
        OpenExit(curTileMap);

    }

    // Update is called once per frame
    private void Update()
    {
        //isChangingScene();
    }
    //IO 작업이 update마다가 아니라 맵이 변경될 때마다 한번씩 해야함, 파일 읽고 dictionary에 저장
    public void ReadTxt(string filePath, Dictionary<string, Vector3Int[]> dictionary)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        string content;
        string key = "";
        Vector3Int[] exitPosition = new Vector3Int[3*4];
        int arrLength = exitPosition.Length;
        
        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(filePath);
            int lineIndex = 0;
            while ((content = reader.ReadLine()) != null)
            {

                if (lineIndex % (arrLength+1) == 0) {
                    key = content + "(Clone)";
                }
                else
                { 
                    string[] subs = content.Split();

                    exitPosition[(lineIndex%(arrLength + 1)) -1].Set(int.Parse(subs[0]), int.Parse(subs[1]), int.Parse(subs[2]));

                    if (lineIndex % (arrLength + 1) == arrLength)
                    {   //Clone()(리턴값 Object)을 통해 해당 배열의 메모리를 통째로 복사
                        Vector3Int[] temp = (Vector3Int[])exitPosition.Clone();
                        dictionary.Add(key, temp);
                    }
                }
                lineIndex++;
             }
            reader.Close();
        }
        else {
            content = "File doesn't exist";
            Debug.Log(content);
        }
    }
    //출구 뚫기 tileMap2.gameObject.name == value +"(Clone)"
    public void OpenExit(TileMap2 tileMap2)
    {
        string tileMap2name = tileMap2.gameObject.name;

        if (dictionary.ContainsKey(tileMap2name))
        {
            for (int i = 0; i < 4; i++)
            {
                if (tileMap2.connectedGameObject[i] != null)
                {
                    Debug.Log(tileMap2name);
                    Debug.Log(dictionary[tileMap2name][3 * i] + "," + dictionary[tileMap2name][3 * i + 1] + "," + dictionary[tileMap2name][3 * i + 2]);
                    platformTilemap.SetTile(dictionary[tileMap2name][3 * i], null);
                    platformTilemap.SetTile(dictionary[tileMap2name][3 * i + 1], null);
                    platformTilemap.SetTile(dictionary[tileMap2name][3 * i + 2], null);
                }
            }
        }
        else
        {
            Debug.Log("A map doesn't exist in a textfile");
        }
     }

    //update할때마다 Scene이 바뀌는지 확인함
    public bool isChangingScene()
    {   
        //Scene이 바뀔 경우
        return true;

        /*
         Scene이 바뀌지 않을 경우
         return false;
        */ 
    }
}
