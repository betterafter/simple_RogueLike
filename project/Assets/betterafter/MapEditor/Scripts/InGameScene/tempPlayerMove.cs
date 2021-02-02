using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempPlayerMove : MonoBehaviour
{
    public Image handle;
    public Image outLine;
    private Canvas canvas;

    public GameObject player;
    public GameObject[] ladderChecker;
    public GameObject upper, lower;

    public bool[] isLadderCollide;
    public bool isBoxCollide = false;
    public bool isDoorCollide = false;
    public bool isSpikeCollide = false;

    float speed = 0.08f;



    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outLine = canvas.gameObject.transform.GetChild(0).GetComponent<Image>();
        handle = outLine.gameObject.transform.GetChild(0).GetComponent<Image>();
        player = gameObject;

        upper = Resources.Load("betterafter/Prefabs/up") as GameObject;
        lower = Resources.Load("betterafter/Prefabs/down") as GameObject;

        isLadderCollide = new bool[2];
        isLadderCollide[0] = false;
        isLadderCollide[1] = false;

        ladderChecker = new GameObject[2];
        ladderChecker[0] = Instantiate(upper, new Vector3(0, 0, 0), Quaternion.identity);
        ladderChecker[1] = Instantiate(lower, new Vector3(0, -1.6f, 0), Quaternion.identity);

        ladderChecker[0].transform.SetParent(gameObject.transform, false);
        ladderChecker[1].transform.SetParent(gameObject.transform, false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(handle.rectTransform.anchoredPosition.x > outLine.rectTransform.sizeDelta.x / 6)
        {
            player.transform.position = new Vector3(player.transform.position.x + speed, player.transform.position.y);
        }
        if (handle.rectTransform.anchoredPosition.x < -(outLine.rectTransform.sizeDelta.x / 6))
        {
            player.transform.position = new Vector3(player.transform.position.x - speed, player.transform.position.y);
        }
        if ((handle.rectTransform.anchoredPosition.x >= -15 && handle.rectTransform.anchoredPosition.x <= 15) &&
            handle.rectTransform.anchoredPosition.y >= outLine.rectTransform.sizeDelta.x / 6 &&
            isLadderCollide[0])
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + speed);
        }
        if ((handle.rectTransform.anchoredPosition.x >= -15 && handle.rectTransform.anchoredPosition.x <= 15) &&
            handle.rectTransform.anchoredPosition.y <= -(outLine.rectTransform.sizeDelta.x / 6) &&
            isLadderCollide[1])
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - speed);
        }
        if(!isLadderCollide[0] && !isLadderCollide[1])
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }


}
