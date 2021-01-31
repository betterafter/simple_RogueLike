using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PointerUp()
    {
        GameObject child1 = gameObject.transform.GetChild(1).gameObject;
        GameObject child2 = gameObject.transform.GetChild(2).gameObject;

        child1.SetActive(true);
        child2.SetActive(true);
    }

    public void PointerExit()
    {
        GameObject child1 = gameObject.transform.GetChild(1).gameObject;
        GameObject child2 = gameObject.transform.GetChild(2).gameObject;

        child1.SetActive(false);
        child2.SetActive(false);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("InGame");
    }
}
