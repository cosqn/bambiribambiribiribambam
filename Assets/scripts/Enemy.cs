using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 90;
    int currentHealth;
    bool isHurt = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // isHurt durumunu sıfırla her frame'de
        isHurt = false;
    }

    public void TakeDamage(int damage)
    {
        // Eğer isHurt true değilse hasar al
        if (!isHurt)
        {
            currentHealth -= damage;
            anim.SetTrigger("Hurt");
            isHurt = true;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        anim.SetBool("IsDead", true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Rigidbody2D bileşenini kaldır
        Destroy(GetComponent<Rigidbody2D>());

        // 5 saniye sonra GameObject'i yok et
        Destroy(gameObject, 2f);
    }
}