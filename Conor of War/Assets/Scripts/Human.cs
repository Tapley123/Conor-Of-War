using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private string attacker;
    private bool dead = false;

    private Rigidbody2D myRb;

    public float health;
    private float fullHealth;
    public Transform healthBar;

    public float cost;
    public float cooldown;

    public string speedRate;
    public float speed;
    private float mySpeed;
    private bool stopped = false;

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
            Dead();

        float healthNormalized = health / fullHealth;
        SetHealthBarSize(healthNormalized);

        ////////////////////////////Change the health bar colour depending on the amount of health//////////////////////////
        if (healthNormalized >= .6)
            SetHealthBarColour(Color.green);
        if (healthNormalized > .2 && healthNormalized < .6)
            SetHealthBarColour(Color.yellow);
        if (healthNormalized <= .2)
            SetHealthBarColour(Color.red);
        ////////////////////////////Change the health bar colour depending on the amount of health//////////////////////////
    }


    private void Dead()
    {
        StartCoroutine(DeathCoroutine(3)); //delay destroying the gameobject
        this.transform.position = new Vector3(1000, 1000);
    }

    public void SetHealthBarSize(float sizeNormalized)
    {
        healthBar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetHealthBarColour(Color colour)
    {
        healthBar.Find("Bar Sprite").GetComponent<SpriteRenderer>().color = colour;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///////////////////////slowing the object that collides with the back of another object////////////////////////////////////////
        if (collision.CompareTag("Archer"))
        {
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();

            if (stopped)
                speed = 0;
            else
                speed = h.speed;
        }

        if (collision.CompareTag("Knight"))
        {
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();

            if (stopped)
                speed = 0;
            else
                speed = h.speed;
        }

        if (collision.CompareTag("Rogue"))
        {
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();

            if (stopped)
                speed = 0;
            else
                speed = h.speed;
        }

        if (collision.CompareTag("Soldier"))
        {
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();

            if (stopped)
                speed = 0;
            else
                speed = h.speed;
        }

        if (collision.CompareTag("Wizard"))
        {
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();

            if (stopped)
                speed = 0;
            else
                speed = h.speed;
        }
        ///////////////////////slowing the object that collides with the back of another object////////////////////////////////////////


        ////////////////////////////////////////////////////////ATTACK/////////////////////////////////////////////////
        if (collision.CompareTag("Zombie"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackZombieCoroutine());
            attacker = "Zombie";
        }
        if (collision.CompareTag("Werewolf"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackWerewolfCoroutine());
            attacker = "Werewolf";
        }
        if (collision.CompareTag("Vampire"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackVampireCoroutine());
            attacker = "Vampire";
        }
        if (collision.CompareTag("Skeleton"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackSkeletonCoroutine());
            attacker = "Skeleton";
        }
        if (collision.CompareTag("Demon"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackDemonCoroutine());
            attacker = "Demon";
        }
        ////////////////////////////////////////////////////////ATTACK/////////////////////////////////////////////////
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stopped = false;
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

    IEnumerator DeathCoroutine(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(this.gameObject);
    }
}
