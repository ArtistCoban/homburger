using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mustericikis : MonoBehaviour
{
    public Transform cikisNoktasi;
    public float beklemeEþiði = 3f;

    private float beklemeSayaci = 0f;
    private bool cikiyor = false;
    private GameObject musteri;
    private Animator musteriAnimator;
    private float hareketHizi = 0.5f;

    private bool kasadaMi = false;

    void Start()
    {
        musteri = GameObject.FindWithTag("Musteri");
        if (musteri != null)
        {
            musteriAnimator = musteri.GetComponent<Animator>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inv = other.GetComponent<PlayerInventory>();
            if (inv != null && inv.burgerAlindi)
            {
                kasadaMi = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            kasadaMi = false;
            beklemeSayaci = 0f; 
        }
    }

    void Update()
    {
        if (kasadaMi && !cikiyor)
        {
            beklemeSayaci += Time.deltaTime;
            Debug.Log("Kasa bekleme süresi: " + Mathf.FloorToInt(beklemeSayaci));

            if (beklemeSayaci >= beklemeEþiði)
            {
                cikiyor = true;
            }
        }

        if (cikiyor && musteri != null)
        {
            Vector2 hedef = cikisNoktasi.position;
            Vector2 pozisyon = Vector2.MoveTowards(musteri.transform.position, hedef, hareketHizi * Time.deltaTime);
            Vector2 hareket = hedef - (Vector2)musteri.transform.position;

            musteri.transform.position = pozisyon;

            if (musteriAnimator != null)
            {
                musteriAnimator.SetFloat("Speed", hareketHizi);
                musteriAnimator.SetFloat("Vertical", hareket.y);
            }

            if (Vector2.Distance(musteri.transform.position, hedef) < 0.05f)
            {
                if (musteriAnimator != null)
                {
                    musteriAnimator.SetFloat("Speed", 0f);
                    musteriAnimator.SetFloat("Vertical", 0f);
                }
                Destroy(musteri);
            }
        }
    }
}
