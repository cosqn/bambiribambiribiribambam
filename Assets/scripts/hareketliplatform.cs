using UnityEngine;

public class hareketliplatform : MonoBehaviour
{
    public float amplitude = 0.7f;    // Yüksekliğin genliği (platformun gideceği maksimum yükseklik)
    public float speed = 1.2f;        // Hareket hızı

    private Vector3 initialPosition;  // Platformun başlangıç pozisyonu

    void Start()
    {
        // Başlangıç pozisyonunu kaydet
        initialPosition = transform.position;
    }

    void Update()
    {
        // Yükseklik hesapla (sin fonksiyonu ile hareket ettirilecek)
        float height = Mathf.Sin(Time.time * speed) * amplitude;

        // Yeni pozisyonu güncelle
        Vector3 newPosition = initialPosition + new Vector3(0, height, 0);
        transform.position = newPosition;
    }
}