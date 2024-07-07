using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D rb2d;
    float moveHorizontal;

    public bool facingRight;

    public float jumpForce;
    public float secondJumpForce; // New variable for the second jump height
    public bool isGrounded;
    public bool canDoubleJump;

    PlayerCombat playercombat;
    public bool characterattack;
    public float charactertimer;

    void Start()
    {
        moveSpeed = 1.2f;
        moveHorizontal = Input.GetAxis("Horizontal");
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        playercombat = GetComponent<PlayerCombat>();
        charactertimer = 1.2f;
    }

    void Update()
    {
        if (playercombat != null)
    {
        playercombat.DamageEnemy();
    }
    else
    {
        // playercombat null ise, gerekli bir işlemi burada yapın (örneğin, hata işleme)
        Debug.LogError("playercombat is null!");
    }
        CharacterMovement();
        CharacterAnimation();
        CharacterAttack();
        CharacterRunAttack();
        CharacterJump();
        CharacterAttackSpacing();
    }

    void CharacterMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);
    }

    void CharacterAnimation()
    {
        if (moveHorizontal > 0)
        {
            anim.SetBool("isRunning", true);
        }
        if (moveHorizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        if (moveHorizontal < 0)
        {
            anim.SetBool("isRunning", true);
        }
        if (facingRight == false && moveHorizontal > 0)
        {
            CharacterFlip();
        }
        if (facingRight == true && moveHorizontal < 0)
        {
            CharacterFlip();
        }
    }

    void CharacterFlip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

void CharacterAttack()
{
    if (playercombat != null)
    {
        playercombat.DamageEnemy();
    }
    else
    {
        // playercombat null ise, gerekli bir işlemi burada yapın (örneğin, hata işleme)
        Debug.LogError("playercombat is null!");
    }
    if (playercombat != null && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")) && moveHorizontal == 0)
    {
        if (characterattack)
        {
            anim.SetTrigger("isAttack");
            playercombat.DamageEnemy();
            characterattack = false;
        }

        FindObjectOfType<AudioManager>().Play("punch");
    }
}

    void CharacterRunAttack()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")&& moveHorizontal > 0 || (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")) && moveHorizontal < 0)
        {
            if (characterattack)
            {
                anim.SetTrigger("isRunAttack");
                playercombat.DamageEnemy();
                characterattack = false;
            }

            FindObjectOfType<AudioManager>().Play("punch");
        }
    }

void CharacterJump()
{
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
    {
        anim.SetBool("isJumping", true);

        if (isGrounded)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            rb2d.velocity = Vector2.up * secondJumpForce;
            canDoubleJump = false;
        }
    }
}

    void CharacterAttackSpacing()
    {
        if (characterattack == false)
        {
            charactertimer -= Time.deltaTime;
        }
        if (charactertimer < 0)
        {
            charactertimer = 0f;
        }
        if (charactertimer == 0f)
        {
            characterattack = true;
            charactertimer = 1.2f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        anim.SetBool("isJumping", false);

        if (col.gameObject.tag == "Grounded")
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        anim.SetBool("isJumping", false);
        if (col.gameObject.tag == "Grounded")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        anim.SetBool("isJumping", true);
        if (col.gameObject.tag == "Grounded")
        {
            isGrounded = false;
        }
    }
}