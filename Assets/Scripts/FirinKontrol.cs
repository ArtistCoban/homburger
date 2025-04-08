using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirinKontrol : MonoBehaviour
{
    public GameObject firinKapali;
    public GameObject firinAcik;
    public Transform player;
    public float etkileşimMesafesi = 0.05f;
    private bool acikMi = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol tıklama
        {
            float uzaklik = Vector2.Distance(player.position, transform.position);
            if (uzaklik <= etkileşimMesafesi)
            {
                ToggleFirin();
            }
        }
    }

    void ToggleFirin()
    {
        acikMi = !acikMi;

        firinAcik.SetActive(!acikMi);
        firinKapali.SetActive(acikMi);
    }
}
