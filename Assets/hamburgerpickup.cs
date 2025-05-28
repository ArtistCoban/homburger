using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamburgerpickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inv = other.GetComponent<PlayerInventory>();
            if (inv != null)
            {
                inv.burgerAlindi = true;
            }
            Debug.Log("Burger toplandý!");
            Destroy(gameObject);
        }
    }
}
