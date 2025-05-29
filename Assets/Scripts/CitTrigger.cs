using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitTrigger : MonoBehaviour
{
    public GameObject closedDoor;   
    public GameObject openedDoor;   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInventory inventory = collision.GetComponent<PlayerInventory>();

            if (inventory != null && inventory.hasKey)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    closedDoor.SetActive(false);
                    openedDoor.SetActive(true);
                    inventory.kapiyiActi = true;
                }
            }
        }
    }
}
