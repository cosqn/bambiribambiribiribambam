using UnityEngine;
using System.Collections;

public class DusmanKontrol : MonoBehaviour
{
    public int health = 100;
    public Animator animator;
    private bool isHurt = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (!isHurt)
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
            else
            {
                animator.SetTrigger("okHurt");
                isHurt = true;
            }
        }
        else
        {
            animator.SetTrigger("lowOk"); // Can azalmadığında "lowOk" animasyonunu çal
        }

        // Her seferinde hasar aldığında isHurt bayrağını sıfırla
        isHurt = false;
    }

    private void Die()
    {
        animator.SetTrigger("okDead");

        // Ölüm animasyonunun süresini al
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float deathAnimationLength = stateInfo.length;

        // Ölüm animasyonunun bitmesini bekleyen Coroutine
        StartCoroutine(DestroyAfterAnimation(deathAnimationLength));
    }

    private IEnumerator DestroyAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
