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

    public bool isAttacking = false, isFrozen = false, hasCollided = false;

    public string[] scenes = {"Scene1", "Scene2", "Scene3"};
    public string myScene;

    public GameObject currentTarget;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        mySpeed = speed;

        /////////////////SCENE CHECK////////////////////////////
        
        if(this.gameObject.transform.position.y > -3f)
        {
            myScene = scenes[0];
        }

        if(this.gameObject.transform.position.y > -18f && this.gameObject.transform.position.y < -3f)
        {
            myScene = scenes[1];
        }

        if(this.gameObject.transform.position.y < -19f)
        {
            myScene = scenes[2];
        }
    }

    void Update()
    {
        myRb.velocity = new Vector2(-speed, 0);

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(currentTarget == null && isFrozen == false && hasCollided == false)
        {
            isAttacking = false;
            speed = mySpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isFrozen == false)
        {
            //slowing the object that collides with the back of another object

            if (collision.transform.parent.tag == "Humans1" && collision.gameObject.transform.position.x < transform.position.x)
            {
                //Debug.Log("Demon");
                hasCollided = true;
                GameObject humanInFront = collision.gameObject;
                Human h = humanInFront.GetComponent<Human>();
                speed = h.speed;
            }
        }
        


        

        

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.tag == "Monsters1" && !isAttacking && collision is BoxCollider2D)
        {
            speed = 0;
            //Debug.Log("is in contact");
            currentTarget = collision.gameObject;
            isAttacking = true;
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = mySpeed;

        if (collision.transform.parent.tag == "Humans1" && collision.gameObject.transform.position.x < transform.position.x)
        {
            //Debug.Log("Demon");
            hasCollided = false;
           
            speed = mySpeed;
        }

        if (collision.gameObject.transform.parent.tag == "Monsters1")
        {
            isAttacking = false;
            currentTarget = null;
        }
    }

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

    IEnumerator Attack()
    {
        

        if (currentTarget != null)
        {
            currentTarget.GetComponent<Monster>().health -= damagePerSecond;
            

        }
        yield return new WaitForSeconds(3f);
        isAttacking = false;
    }

    
}
