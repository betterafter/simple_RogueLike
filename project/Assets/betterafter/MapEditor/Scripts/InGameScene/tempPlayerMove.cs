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



    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outLine = canvas.gameObject.transform.GetChild(0).GetComponent<Image>();
        handle = outLine.gameObject.transform.GetChild(0).GetComponent<Image>();
        player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(handle.rectTransform.anchoredPosition.x > 15)
        {
            player.transform.position = new Vector3(player.transform.position.x + 0.05f, player.transform.position.y);
        }
        if (handle.rectTransform.anchoredPosition.x < -15)
        {
            player.transform.position = new Vector3(player.transform.position.x - 0.05f, player.transform.position.y);
        }
    }
}
