using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{

    static public DatabaseManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        itemList.Add(new Item(10001, "HP 포션", "체력을 50 채워주는 HP 물약", Item.ItemType.Use));
        itemList.Add(new Item(10002, "랜덤 상자", "랜덤으로 포션, 장비가 나오는 상자. 낮은 확률로 꽝", Item.ItemType.Use));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
