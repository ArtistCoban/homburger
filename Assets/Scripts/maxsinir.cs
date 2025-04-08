using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maxsinir : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -1.56f)
        {
            transform.position = new Vector3(transform.position.x, -1.56f, transform.position.z);
        }
        if (transform.position.x < -8.70f)
        {
            transform.position = new Vector3(-8.70f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 8.70f)
        {
            transform.position = new Vector3(8.70f, transform.position.y, transform.position.z);
        }
    }
}
