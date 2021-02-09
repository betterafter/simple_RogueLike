using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            if (this.gameObject.CompareTag("ladderChecker_up"))
                gameObject.transform.root.GetComponent<tempPlayerMove>().isLadderCollide[0] = true;
            else if (this.gameObject.CompareTag("ladderChecker_down"))
                gameObject.transform.root.GetComponent<tempPlayerMove>().isLadderCollide[1] = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            if (this.gameObject.CompareTag("ladderChecker_up"))
                gameObject.transform.root.GetComponent<tempPlayerMove>().isLadderCollide[0] = false;
            if (this.gameObject.CompareTag("ladderChecker_down"))
                gameObject.transform.root.GetComponent<tempPlayerMove>().isLadderCollide[1] = false;
        }
    }
}
