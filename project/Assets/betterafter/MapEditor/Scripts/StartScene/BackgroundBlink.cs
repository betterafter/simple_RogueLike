using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBlink : MonoBehaviour
{
    float blinkDuration;
    float rotateDuration;

    void Start()
    {
        blinkDuration = Random.Range(1, 5);
        rotateDuration = Random.Range(10, 20);
        Debug.Log("blink : " + blinkDuration);
        StartCoroutine("blink");
        StartCoroutine("rotate");
    }

    IEnumerator blink()
    {
        while (true)
        {
            Color color = this.gameObject.GetComponent<SpriteRenderer>().color;

            while (this.GetComponent<SpriteRenderer>().color.a >= 0.5) {
                color.a -= blinkDuration / 255;
                this.GetComponent<SpriteRenderer>().color = color;
                yield return new WaitForSeconds(blinkDuration / 100);
            }

            while (this.GetComponent<SpriteRenderer>().color.a < 1)
            {
                color.a += blinkDuration / 255;
                this.GetComponent<SpriteRenderer>().color = color;
                yield return new WaitForSeconds(blinkDuration / 100);
            }

            yield return new WaitForSeconds(blinkDuration / 100);
        }
    }

    IEnumerator rotate()
    {
        while (true)
        {
            while (transform.rotation.z < 359)
            {
                gameObject.transform.Rotate(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z - rotateDuration / 20));
                yield return new WaitForSeconds(rotateDuration / 200);
            }

            while (transform.rotation.z > -359)
            {
                gameObject.transform.Rotate(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z + rotateDuration / 20));
                yield return new WaitForSeconds(rotateDuration / 200);
            }

            yield return new WaitForSeconds(rotateDuration);
        }
    }
}
