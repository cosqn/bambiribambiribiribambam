using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool enemyAttack;
    public float enemyTimer = 0.4f;
    public Animator anim;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        enemyTimer = 0.5f;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        GetComponent<CharacterMove>().enabled = false;
        StartCoroutine(DeactivateAfterDeath());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator DeactivateAfterDeath()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    void Update()
    {
        enemyAttackSpacing();
        CharacterDamage();
    }

    void enemyAttackSpacing()
    {
        if (enemyAttack == false)
        {
            enemyTimer -= Time.deltaTime;
        }

        if (enemyTimer < 0)
        {
            enemyTimer = 0f;
        }

        if (enemyTimer == 0f)
        {
            enemyAttack = true;
            enemyTimer = 0.5f;
        }
    }

    void CharacterDamage()
    {
        if (Input.GetMouseButtonDown(0))
        {
            enemyAttack = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (enemyAttack)
        {
            currentHealth -= damage;
            enemyAttack = false;
            anim.SetTrigger("isHurt");
        }

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            currentHealth = 0;
            isDead = true;
            Die();
        }
    }
}
