using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D myRb;

    public string monsterName;
    public float health;
    public float speed;
    public float damagePerSecond;
    public float pointPerKill;

    public bool canBypass;

    public GameObject currentTarget;


    public bool isAttacking = false;
    

    private float zombieSpeed = 2f, werewolfSpeed = 1f, vampireSpeed = 2f, skeletonSpeed = 3f, demonSpeed = 1f;
    [SerializeField] private float mySpeed;

    void Start()
    {

        myRb = GetComponent<Rigidbody2D>();

        canBypass = true;

        if (gameObject.tag == "Zombie")
        {
            health = 70f;
            mySpeed = zombieSpeed;
            speed = zombieSpeed;
            damagePerSecond = 20f;
            pointPerKill = 15f;
        }

        if (gameObject.tag == "Werewolf")
        {
            health = 210f;
            mySpeed = werewolfSpeed;
            speed = werewolfSpeed;
            damagePerSecond = 60f;
            pointPerKill = 45f;
        }

        if (gameObject.tag == "Vampire")
        {
            health = 40f;
            mySpeed = vampireSpeed;
            speed = vampireSpeed;
            damagePerSecond = 15f;
            pointPerKill = 30f;
        }

        if (gameObject.tag == "Skeleton")
        {
            health = 80f;
            mySpeed = skeletonSpeed;
            speed = skeletonSpeed;
            damagePerSecond = 60f;
            pointPerKill = 30f;
        }

        if (gameObject.tag == "Demon")
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

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
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

        /////////////////////////////////ATTACKING////////////////////////////////////////////////////////


        

        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Vampire" && collision.gameObject.tag == "Werewolf")
        {
            canBypass = false;
        }

        if (collision.gameObject.transform.parent.tag == "Humans1")
        {
            if (canBypass && isAttacking == false)
            {
                speed = 0;
                //Debug.Log("is in contact");
                currentTarget = collision.gameObject;
                isAttacking = true;
                StartCoroutine("Attack");
            }

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = mySpeed;
        Debug.Log(gameObject + "has exited");
        if (collision.gameObject.transform.parent.tag == "Humans1")
        {
            isAttacking = false;
            currentTarget = null;
        }

        if (this.gameObject.tag == "Vampire" && collision.gameObject.tag == "Werewolf")
        {
            canBypass = true;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.parent.tag == "Humans1")
        {
            speed = 0;
            //Debug.Log("is in contact");
            currentTarget = collision.gameObject;
            isAttacking = true;
            Invoke("Attack", 3f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = mySpeed;
        if (collision.gameObject.transform.parent.tag == "Humans1")
        {
            isAttacking = false;
            currentTarget = null;
        }
    }*/

    IEnumerator Attack()
    {
        
        
        if (currentTarget != null)
        {

            currentTarget.GetComponent<Human>().health -= damagePerSecond;
        }
        yield return new WaitForSeconds(3f);
        isAttacking = false;
    }

    
}
