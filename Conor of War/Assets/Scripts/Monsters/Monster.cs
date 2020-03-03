using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D myRb;

    public string name;
    private float health;
    private float cost;
    private float cooldown;
    public string speedRate;
    private float speed;
    public string characterType;
    private float damagePerSecond;
    private float pointPerKill;

    private float zombieSpeed = 2f, werewolfSpeed = 1f, vampireSpeed = 2f, skeletonSpeed = 3f, demonSpeed = 1f;
    [SerializeField] private float mySpeed;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();

        if (name == "Zombie")
        {
            health = 70f;
            cost = 10f;
            cooldown = 1f;
            mySpeed = zombieSpeed;
            speed = zombieSpeed;
            damagePerSecond = 20f;
            pointPerKill = 15f;
        }

        if (name == "Werewolf")
        {
            health = 210f;
            cost = 30f;
            cooldown = 3f;
            mySpeed = werewolfSpeed;
            speed = werewolfSpeed;
            damagePerSecond = 60f;
            pointPerKill = 45f;
        }

        if (name == "Vampire")
        {
            health = 40f;
            cost = 20f;
            cooldown = 2f;
            mySpeed = vampireSpeed;
            speed = vampireSpeed;
            damagePerSecond = 15f;
            pointPerKill = 30f;
        }

        if (name == "Skeleton")
        {
            health = 80f;
            cost = 20f;
            cooldown = 2f;
            mySpeed = skeletonSpeed;
            speed = skeletonSpeed;
            damagePerSecond = 60f;
            pointPerKill = 30f;
        }

        if (name == "Demon")
        {
            health = 50f;
            cost = 80f;
            cooldown = 8f;
            mySpeed = demonSpeed;
            speed = demonSpeed;
            damagePerSecond = 20f;
            pointPerKill = 120f;
        }
    }


    void Update()
    {
        myRb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //slowing the object that collides with the back of another object
        if (collision.CompareTag("Demon") && collision.gameObject.transform.position.x > transform.position.x)
        {
            //Debug.Log("Demon");
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();
            speed = m.speed;
        }

        if (collision.CompareTag("Skeleton") && collision.gameObject.transform.position.x > transform.position.x)
        {
            //Debug.Log("Skeleton");
            //speed = skeletonSpeed;
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();
            speed = m.speed;
        }

        if (collision.CompareTag("Vampire") && collision.gameObject.transform.position.x > transform.position.x)
        {
            // Debug.Log("Vampire");
            //speed = vampireSpeed;
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();
            speed = m.speed;
        }

        if (collision.CompareTag("Werewolf") && collision.gameObject.transform.position.x > transform.position.x)
        {
            //Debug.Log("Werewolf");
            //speed = werewolfSpeed;
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();
            speed = m.speed;
        }

        if (collision.CompareTag("Zombie") && collision.gameObject.transform.position.x > transform.position.x)
        {
            //Debug.Log("Zombie");
            //speed = zombieSpeed;
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();
            speed = m.speed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = mySpeed;
    }
}
