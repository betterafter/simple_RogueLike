using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private GameObject SettingPanel;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetEscEvent();
        }
    }

    private void GetEscEvent()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            if(SettingPanel == null) SettingPanel = GameObject.Find("Canvas").gameObject.transform.GetChild(1).gameObject;

            if (SettingPanel.activeSelf)
            {
                SettingPanel.SetActive(false);
            }
            else SettingPanel.SetActive(true);
        }
    }
}
