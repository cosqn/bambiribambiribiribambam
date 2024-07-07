using System.Collections;
using UnityEngine;

public class hareketlidiken : MonoBehaviour
{
    public Transform target;  // Takip edilecek hedef (örneğin, Skeleton)
    public float horizontalFollowSpeed = 5f;  // Yatay takip hızı
    public float verticalMoveSpeed = 0.9f;  // Dikey hareket hızı
    public float verticalMoveRange = 0.6f;  // Dikey hareket aralığı

    private float originalY;  // Platformun başlangıç dikey pozisyonu

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        if (target != null)
        {
            // Hedefin yatay pozisyonu
            float targetX = target.position.x;

            // Platformun yatayda takibi
            float newX = Mathf.Lerp(transform.position.x, targetX, horizontalFollowSpeed * Time.deltaTime);

            // Dikey hareket için periyodik bir sinüs dalgası kullanarak yukarı-aşağı hareket
            float newY = originalY + Mathf.Sin(Time.time * verticalMoveSpeed) * verticalMoveRange;

            // Yeni konumu uygula
            transform.position = new Vector3(newX, newY, transform.position.z);
        }
    }
}