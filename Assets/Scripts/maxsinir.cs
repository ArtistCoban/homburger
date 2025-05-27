using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class maxsinir : MonoBehaviour
{
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "mainscene")
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
        if (currentScene == "secondscene")
        {
            if (transform.position.y > 4.95f)
            {
                transform.position = new Vector3(transform.position.x, 4.95f, transform.position.z);
            }
            if (transform.position.x < -10.88f)
            {
                transform.position = new Vector3(-10.88f, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 10.88f)
            {
                transform.position = new Vector3(10.88f, transform.position.y, transform.position.z);
            }
        }
    }
}
