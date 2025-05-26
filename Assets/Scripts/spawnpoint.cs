using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpoint : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameObject spawnPoint = GameObject.Find("SpawnPoint");
            if (spawnPoint != null)
            {
                Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
}
