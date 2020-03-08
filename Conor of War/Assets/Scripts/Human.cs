using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
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
    public float mySpeed;

    public bool isAttacking = false;

    public GameObject currentTarget;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        mySpeed = speed;
    }

    void Update()
    {
        myRb.velocity = new Vector2(-speed, 0);

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(currentTarget == null)
        {
            isAttacking = false;
            speed = mySpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //slowing the object that collides with the back of another object
        if (collision.CompareTag("Wizard") && collision.gameObject.transform.position.x < transform.position.x)
        {
            //Debug.Log("Demon");
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();
            speed = h.speed;
        }

        if (collision.CompareTag("Rogue") && collision.gameObject.transform.position.x < transform.position.x)
        {
            //Debug.Log("Skeleton");
            //speed = skeletonSpeed;
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();
            speed = h.speed; ;
        }

        if (collision.CompareTag("Archer") && collision.gameObject.transform.position.x < transform.position.x)
        {
            // Debug.Log("Vampire");
            //speed = vampireSpeed;
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();
            speed = h.speed;
        }

        if (collision.CompareTag("Knight") && collision.gameObject.transform.position.x < transform.position.x)
        {
            //Debug.Log("Werewolf");
            //speed = werewolfSpeed;
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();
            speed = h.speed;
        }

        if (collision.CompareTag("Soldier") && collision.gameObject.transform.position.x < transform.position.x)
        {
            //Debug.Log("Zombie");
            //speed = zombieSpeed;
            GameObject humanInFront = collision.gameObject;
            Human h = humanInFront.GetComponent<Human>();
            speed = h.speed;
        }


        if (collision.gameObject.transform.parent.tag == "Monsters1" && !isAttacking)
        {
            //speed = 0;
            Debug.Log("is in contact");
            currentTarget = collision.gameObject;
            isAttacking = true;
            Invoke("Attack", 3f);
        }

       

    }



    /*private void OnTriggerExit2D(Collider2D collision)
    {
        speed = mySpeed;

        Debug.Log(gameObject.name + "has exited");
        if (collision.gameObject.transform.parent.tag == "Monsters1")
        {
            isAttacking = false;
            currentTarget = null;
        }
    }*/

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.parent.tag == "Monsters1")
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
        if (collision.gameObject.transform.parent.tag == "Monsters1")
        {
            isAttacking = false;
            currentTarget = null;
        }
    }*/

    IEnumerator Cooldown()
    {

        yield return new WaitForSeconds(3f);
    }

    void Attack()
    {
        
        
        if (currentTarget != null)
        {
            currentTarget.GetComponent<Monster>().health -= damagePerSecond;
            Invoke("Attack", 3f);
        }

    }
}
