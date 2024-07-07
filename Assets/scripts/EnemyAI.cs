using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float distance;
    public float followspeed;

    private Transform target;
    private Animator anim;
    private EnemyCombat enemycombat;

    private bool isFacingRight = true; // Düşmanın hangi yöne baktığını izlemek için bir değişken ekledik.

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        enemycombat = GetComponent<EnemyCombat>();
    }

    void Update()
    {
        EnemyAi();
    }

    void EnemyAi()
    {
        // Düşmanın sürekli olarak oyuncuya dönük olmasını sağlamak için düşmanın konumunu ve hedefin konumunu kullanın.
        Vector3 directionToPlayer = target.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Düşmanın hangi yöne baktığını güncelleyin.
        if (directionToPlayer.x > 0 && isFacingRight)
        {
            Flip();
        }
        else if (directionToPlayer.x < 0 && !isFacingRight)
        {
            Flip();
        }

        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, directionToPlayer.normalized, distance);

        if (hitEnemy.collider != null)
        {
            Debug.DrawLine(transform.position, hitEnemy.point, Color.red);
            anim.SetBool("Attack", true);
            EnemyFollow();
            enemycombat.DamagePlayer();
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + directionToPlayer.normalized * distance, Color.green);
            anim.SetBool("Attack", false);
        }
    }

    void EnemyFollow()
    {
        // Düşmanın sadece sağa ve sola hareket etmesini sağlayın ve yüzünü döndürün.
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, followspeed * Time.deltaTime);
    }

    void Flip()
    {
        // Düşmanın yönünü tersine çevirin ve yüzünü döndürün.
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}