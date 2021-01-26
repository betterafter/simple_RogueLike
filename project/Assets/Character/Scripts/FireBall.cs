using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Vector3 direction=Vector3.zero;
    private float travelLength = 0.0f;

    private void FixedUpdate()
    {
        transform.position += direction * 7.0f * Time.deltaTime;
        travelLength += (direction * 7.0f * Time.deltaTime).magnitude;
        if (travelLength > 10.0f)
            Destroy(gameObject);
    }
    
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }
}
