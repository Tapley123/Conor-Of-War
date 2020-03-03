using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D myRb;

    public string monsterName;
    private float health;
    private float speed;
    private float damagePerSecond;
    private float pointPerKill;

    private float zombieSpeed = 2f, werewolfSpeed = 1f, vampireSpeed = 2f, skeletonSpeed = 3f, demonSpeed = 1f;
    [SerializeField] private float mySpeed;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();

        if (monsterName == "Zombie")
        {
            health = 70f;
            mySpeed = zombieSpeed;
            speed = zombieSpeed;
            damagePerSecond = 20f;
            pointPerKill = 15f;
        }

        if (monsterName == "Werewolf")
        {
            health = 210f;
            mySpeed = werewolfSpeed;
            speed = werewolfSpeed;
            damagePerSecond = 60f;
            pointPerKill = 45f;
        }

        if (monsterName == "Vampire")
        {
            health = 40f;
            mySpeed = vampireSpeed;
            speed = vampireSpeed;
            damagePerSecond = 15f;
            pointPerKill = 30f;
        }

        if (monsterName == "Skeleton")
        {
            health = 80f;
            mySpeed = skeletonSpeed;
            speed = skeletonSpeed;
            damagePerSecond = 60f;
            pointPerKill = 30f;
        }

        if (monsterName == "Demon")
        {
            health = 50f;
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
