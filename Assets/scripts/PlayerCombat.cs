using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.3f;
    public int attackDamage = 15;
    public float attackCooldown = 0.55f; 

    private float lastAttackTime; 
    private bool isInvincible = false; 

    public void DamageEnemy()
    {
        // AttackCooldown süresince saldırı yapmamasını kontrol et
        if (Time.time - lastAttackTime < attackCooldown || isInvincible)
        {
            return;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Düşmanın Enemy bileşenine erişim sağla
            Enemy enemy = enemyCollider.GetComponent<Enemy>();

            // Eğer düşmanın Enemy bileşeni varsa hasar ver
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
                FindObjectOfType<AudioManager>().Play("enemyhurt");
            }
        }

        // Saldırı yapıldığında son saldırı zamanını güncelle
        lastAttackTime = Time.time;

        // InvincibilityDuration süresince zarar almamasını sağla
    }

    // Belirli bir süre boyunca zarar almamak için kullanılan coroutine
    

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
