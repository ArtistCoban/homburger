using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etpickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inv = other.GetComponent<PlayerInventory>();
            if (inv != null)
            {
                inv.etAlindi = true;
            }
            Debug.Log("Et toplandý!");
            Destroy(gameObject); 
        }
    }
}
