using UnityEngine;

public class xyokyvar : MonoBehaviour
{
    public GameObject xNesnesi; // x nesnesi
    public GameObject yNesnesi; // y nesnesi

    void Update()
    {
        // Her frame'de kontrol et
        KontrolEt();
    }

    void KontrolEt()
    {
        if (xNesnesi != null && !xNesnesi.activeSelf)
        {
            if (yNesnesi != null)
            {
                yNesnesi.SetActive(true); // x nesnesi pasif hale gelirse, y nesnesini aktif hale getir
            }
        }
    }
}