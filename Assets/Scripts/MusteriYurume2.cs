using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusteriYurume2 : MonoBehaviour
{
    public Transform hedefTezgah;
    public float hareketHizi = 1.5f;
    public float beklemeSuresi = 2f;

    private Animator animator;
    private bool tezgahaVardi = false;
    private float beklemeSayaci = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!tezgahaVardi)
        {
            Vector2 pozisyon = Vector2.MoveTowards(transform.position, hedefTezgah.position, hareketHizi * Time.deltaTime);
            Vector2 hareket = hedefTezgah.position - transform.position;

            transform.position = pozisyon;
            animator.SetFloat("Speed", hareketHizi);
            animator.SetFloat("Vertical", hareket.y);

            if (Vector2.Distance(transform.position, hedefTezgah.position) < 0.05f)
            {
                tezgahaVardi = true;
                beklemeSayaci = beklemeSuresi;

                transform.position = hedefTezgah.position;
                animator.SetFloat("Speed", 0f);
                animator.SetFloat("Vertical", 0f);
            }
        }
        else
        {
            if (beklemeSayaci > 0)
            {
                beklemeSayaci -= Time.deltaTime;

                if (beklemeSayaci <= 0)
                {
                    animator.SetFloat("Speed", 0f);
                    animator.SetFloat("Vertical", 0f);
                }
            }
        }
    }
}
