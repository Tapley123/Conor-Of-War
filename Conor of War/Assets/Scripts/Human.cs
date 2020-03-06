using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Rigidbody2D myRb;

    public float health;
    private float fullHealth;
    public Transform healthBar;

    public float cost;
    public float cooldown;
    public string speedRate;
    public float speed;
    private float mySpeed;
    public string characterType;
    public float damagePerSecond;
    public float pointPerKill;

    private float zombieDPS = 20f, werewolfDPS = 60f, vampireDPS = 15f, skeletonDPS = 60f, demonDPS = 20f;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        mySpeed = speed;
        fullHealth = health;
    }

    void Update()
    {
        myRb.velocity = new Vector2(-speed, 0);

        if(health <= 0)
        {
            Dead();
        }

        float healthNormalized = health / fullHealth;
        SetHealthBarSize(healthNormalized);
    }


    private void Dead()
    {
        Destroy(this.gameObject);
    }

    public void SetHealthBarSize(float sizeNormalized)
    {
        healthBar.localScale = new Vector3(sizeNormalized, 1f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Zombie"))
        {
            speed = 0;
            StartCoroutine(AttackZombieCoroutine());
        }
        if (collision.CompareTag("Werewolf"))
        {
            speed = 0;
            StartCoroutine(AttackWerewolfCoroutine());
        }
        if (collision.CompareTag("Vampire"))
        {
            speed = 0;
            StartCoroutine(AttackVampireCoroutine());
        }
        if (collision.CompareTag("Skeleton"))
        {
            speed = 0;
            StartCoroutine(AttackSkeletonCoroutine());
        }
        if (collision.CompareTag("Demon"))
        {
            speed = 0;
            StartCoroutine(AttackDemonCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = mySpeed;
        StopAllCoroutines();
    }

    /// //////////////////////////////////////////////ATTACK COROUTINES///////////////////////////////////////////////////
    IEnumerator AttackZombieCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= zombieDPS;
        }
    }
    IEnumerator AttackWerewolfCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= werewolfDPS;
        }
    }
    IEnumerator AttackVampireCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= vampireDPS;
        }
    }
    IEnumerator AttackSkeletonCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= skeletonDPS;
        }
    }
    IEnumerator AttackDemonCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= demonDPS;
        }
    }
    /// //////////////////////////////////////////////ATTACK COROUTINES///////////////////////////////////////////////////
}
