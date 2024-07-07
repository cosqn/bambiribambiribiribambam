using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform enemyAttackPoint;
    public LayerMask playerLayers;
    private bool isAttacking = false;

    public float enemyAttackRange = 0.3f;
    public int enemyAttackDamage = 22;

    private void Update()
    {
        if (isAttacking)
        {
            // Saldırı animasyonu devam ederken işleri burada yapabilirsiniz.
        }
    }

    public void StartAttackAnimation()
    {
        isAttacking = true;
    }

    public void EndAttackAnimation()
    {
        isAttacking = false;
    }

    public void DamagePlayer()
    {
        if (!isAttacking)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                CharacterHealth characterHealth = enemy.GetComponent<CharacterHealth>();
                if (characterHealth != null)
                {
                    characterHealth.TakeDamage(enemyAttackDamage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }
}