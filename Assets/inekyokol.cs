using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inekyokol : MonoBehaviour
{
    public GameObject etPrefab;
    private inekhareket inek;

    void Start()
    {
        inek = GetComponent<inekhareket>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (inek != null && inek.InekDuruyorMu())
            {
                Instantiate(etPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
