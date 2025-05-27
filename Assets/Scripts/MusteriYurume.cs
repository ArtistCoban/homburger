using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusteriYurume : MonoBehaviour
{
    public Transform hedefTezgah;
    public Transform cikisNoktasi;
    public float hareketHizi = 1.5f;
    public float beklemeSuresi = 2f;

    private Animator animator;
    private bool tezgahaVardi = false;
    private bool cikiyor = false;
    private float beklemeSayaci = 0f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Transform hedef = tezgahaVardi ? cikisNoktasi : hedefTezgah;

        // Hedefe doğru ilerleme
        Vector2 pozisyon = Vector2.MoveTowards(transform.position, hedef.position, hareketHizi * Time.deltaTime);

        Vector2 hareket = hedef.position - transform.position;
        float mesafe = hareket.magnitude;

        if (!tezgahaVardi || cikiyor)
        {
            transform.position = pozisyon;

            animator.SetFloat("Speed", hareketHizi);
            animator.SetFloat("Vertical", hareket.y);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
            animator.SetFloat("Vertical", 0f);
        }

        // Tezgaha vardı mı?
        if (!tezgahaVardi && mesafe < 0.05f)
        {
            tezgahaVardi = true;
            beklemeSayaci = beklemeSuresi;

            // idle animasyona geç
            transform.position = hedefTezgah.position;
            animator.SetFloat("Speed", 0f);
            animator.SetFloat("Vertical", 0f);
        }
        if (tezgahaVardi && beklemeSayaci > 0)
        {
            beklemeSayaci -= Time.deltaTime;

            if (beklemeSayaci <= 0)
            {
                cikiyor = true;
            }
        }

        // Çıkışa ulaştıysa yok et
        if (cikiyor && Vector2.Distance(transform.position, cikisNoktasi.position) < 0.05f)
        {
            Destroy(gameObject);
        }
    }
}
