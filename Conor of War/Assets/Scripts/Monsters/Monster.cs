using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D myRb;

    public float health;
    public float cost;
    public float cooldown;
    public string speedRate;
    public float speed;
    public string characterType;
    public float damagePerSecond;
    public float pointPerKill;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        myRb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Demon"))
        {
            Debug.Log("Demon");
        }

        if (collision.CompareTag("Skeleton"))
        {
            Debug.Log("Skeleton");
        }

        if (collision.CompareTag("Vampire"))
        {
            Debug.Log("Vampire");
        }

        if (collision.CompareTag("Werewolf"))
        {
            Debug.Log("Werewolf");
        }

        if (collision.CompareTag("Zombie"))
        {
            Debug.Log("Zombie   ");
        }
    }
}
