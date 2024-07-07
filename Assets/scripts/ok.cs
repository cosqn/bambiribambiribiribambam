using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ok : MonoBehaviour
{
    [SerializeField] private float attackInterval;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float arrowSpeed = 10.0f;

    private float lastAttackTime;
    private bool isRightMouseButtonDown;
    private Animator animator;
    private Rigidbody2D rb2d;
    private Vector3 initialPosition;
    private bool isGrounded;
    private bool isBow;
    private bool hasShotArrow;

    private void Start()
    {
        // Karakterin Rigidbody2D bileşenini al
        rb2d = GetComponent<Rigidbody2D>();
        // Karakterin Animator bileşenini al
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        hasShotArrow = false; // Ok atma bayrağını sıfırla
    }

    private void Update()
    {
        // Sağ tıklama durumunu güncelle
        isRightMouseButtonDown = (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire2")); // 1 sağ tık için

        // Karakter yerde mi diye kontrol et
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground")); // Ayarladığınız zemin layer'ına göre düzenleyin.

        // Animator kontrol et
        isBow = animator.GetBool("isBow");

        if (isRightMouseButtonDown)
        {
            // Ok animasyonu oynamıyorsa başlat ve ok atma bayrağını sıfırla
            if (!isBow)
            {
                animator.SetBool("isBow", true);
                hasShotArrow = false;
            }
        }
        else if (!isRightMouseButtonDown && isBow && !hasShotArrow)
        {
            // Sağ tıklama bırakıldı, Ok animasyonu oynuyorsa ve ok henüz atılmadıysa
            float animationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

            if (animationTime >= 1f)
            {
                animator.SetBool("isBow", false); // Ok animasyonunu sıfırla
                ShootArrow(); // Oku at
                hasShotArrow = true; // Ok atma bayrağını ayarla
            }
        }
    }

    // Saldırı yapma koşullarını kontrol eden fonksiyon
    private bool CanAttack()
    {
        // Son saldırıdan bu yana geçen süre attackInterval'dan büyük veya eşitse
        if (Time.time - lastAttackTime >= attackInterval)
        {
            // Son saldırı zamanını güncelle
            lastAttackTime = Time.time;
            return true;
        }
        // Aksi takdirde saldırıya izin verme
        return false;
    }

    // Saldırı eylemi
    private void ShootArrow()
    {
        // Ok objesini yarat
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);

        // Ok objesine bir hız uygula
        Rigidbody2D arrowRigidbody = arrow.GetComponent<Rigidbody2D>();
        arrowRigidbody.velocity = transform.localScale.x > 0 ? Vector2.right * arrowSpeed : Vector2.left * arrowSpeed;
   arrow.transform.localScale = new Vector2(transform.localScale.x,1);
        // Saldırı yapıldığında bir log mesajı yazdır
        Debug.Log("Ok fırlatıldı!");
    }
}