using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosolkapıacıl : MonoBehaviour
{
    public GameObject canavar1;
    public GameObject canavar2;
    public GameObject kapı;

    void Update()
    {
        // Her frame'de kontrol et
        KontrolEt();
    }

    void KontrolEt()
    {
        // Her iki canavar da yok oldu mu kontrol et
        if (canavar1 == null && canavar2 == null)
        {
            if (kapı != null)
            {
                kapı.SetActive(false); // Her iki canavar da yoksa kapıyı pasif hale getir
            }
        }
    }

    // Diğer gerekli metodları ekleyebilirsiniz
}