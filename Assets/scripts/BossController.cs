using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public Transform player;
    public float fireInterval = 2.0f;
    public float arrowSpeed = 5.0f;
    public float arrowLifetime = 3.0f;

    private float lastFireTime;
    private int arrowCounter;
    private bool playLowOk; // "lowOk" animasyonunu çalmak için bayrak

    public Animator bossAnimator; // Boss karakterinizin Animator bileşeni

    private void Start()
    {
         bossAnimator = GetComponent<Animator>();
        lastFireTime = Time.time;
        arrowCounter = 0;
        playLowOk = false; // Başlangıçta animasyonu çalmamak için
    }

    private void Update()
    {
        if (Time.time - lastFireTime >= fireInterval)
        {
            if (arrowCounter < 2)
            {
                FireSingleArrow();
                arrowCounter++;
                if (!playLowOk) // Eğer "lowOk" animasyonu daha önce çalmadıysa
                {
                    bossAnimator.SetTrigger("lowOk"); // "lowOk" animasyonunu çal
                    playLowOk = true; // Artık çaldı
                }
            }
            else
            {
                FireTripleArrows();
                arrowCounter = 0;
                playLowOk = false; // Üçlü atış sonrası animasyonu sıfırla
            }

            lastFireTime = Time.time;
        }
    }

    private void FireSingleArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (player.position - firePoint.position).normalized;

        Rigidbody2D arrowRigidbody = arrow.GetComponent<Rigidbody2D>();
        arrowRigidbody.velocity = direction * arrowSpeed;

        arrow.transform.parent = null;
        Destroy(arrow, arrowLifetime);
    }

    private void FireTripleArrows()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
            Vector3 direction = (player.position - firePoint.position).normalized;
            float angle = -15.0f + i * 15.0f;

            Rigidbody2D arrowRigidbody = arrow.GetComponent<Rigidbody2D>();
            arrowRigidbody.velocity = Quaternion.Euler(0, 0, angle) * direction * arrowSpeed;

            arrow.transform.parent = null;
            Destroy(arrow, arrowLifetime);
        }
    }

    // OnCollisionEnter2D, karakter ile okun temasını algılar
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Eğer çarpılan nesnenin etiketi "Player" ise
        {
            CharacterHealth characterHealth = collision.gameObject.GetComponent<CharacterHealth>();
            if (characterHealth != null)
            {
                characterHealth.TakeDamage(10); // Karakterin canını 10 azalt
            }
        }
    }
}
