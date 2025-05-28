using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirinKontrol : MonoBehaviour
{
    public GameObject firinKapali;
    public GameObject firinAcik;
    public Transform player;
    public GameObject hamburgerPrefab;
    public Transform hamburgerSpawnNoktasi;
    public float etkileşimMesafesi = 0.5f;

    private bool acikMi = false;
    private bool hamburgerDroplandimi = false;
    private bool fırınKullanildi = false;

    void Update()
    {
        if (fırınKullanildi)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
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

        firinAcik.SetActive(acikMi);
        firinKapali.SetActive(!acikMi);

        if (acikMi && !hamburgerDroplandimi)
        {
            StartCoroutine(Hamburgeri5SaniyeSonraDropEt());
        }
    }

    IEnumerator Hamburgeri5SaniyeSonraDropEt()
    {
        hamburgerDroplandimi = true;
        yield return new WaitForSeconds(5f);
        Vector3 konum = hamburgerSpawnNoktasi.position;
        Instantiate(hamburgerPrefab, konum, Quaternion.identity);
        firinKapali.SetActive(true);
        firinAcik.SetActive(false);
        fırınKullanildi = true;
    }
}
