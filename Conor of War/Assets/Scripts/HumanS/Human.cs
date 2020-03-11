using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private bool humansCanPushBack = true;
    private bool lose1 = false, lose1Part2 = false, lose2 = false, lose2Part2 = false, lose3 = false, lose3Part2 = false, loseGame = false, loseMBase = false;
    private float loseTime = 1f;

    private bool slowingObjects = true, attacking = true;

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
    private float testingSpeedBoost = 3; //for testing
    private float mySpeed;
    private bool stopped = false;

    public string characterType;
    public float damagePerSecond;
    public float pointPerKill;

    private float zombieDPS = 20f, werewolfDPS = 60f, vampireDPS = 15f, skeletonDPS = 60f, demonDPS = 20f;
    

    void Start()
    {
        //for testing
        //speed = speed * testingSpeedBoost;

        myRb = GetComponent<Rigidbody2D>();
        mySpeed = speed;
        fullHealth = health;
    }

    void Update()
    {
        /////////////////////////////////////////////////////Lose Conditions/////////////////////////////////////////////////////
        if (humansCanPushBack)
        {
            if (lose1)
                StartCoroutine(LoseCoroutine1(loseTime));
            else if (!lose1)
                StopCoroutine("LoseCoroutine1");
            if (lose1Part2)
                StartCoroutine(LoseCoroutine1Part2(loseTime));
            else if (!lose1Part2)
                StopCoroutine("LoseCoroutine1Part2");

            if (lose2)
                StartCoroutine(LoseCoroutine2(loseTime));
            else if (!lose2)
                StopCoroutine("LoseCoroutine2");
            if (lose2Part2)
                StartCoroutine(LoseCoroutine2Part2(loseTime));
            else if (!lose2Part2)
                StopCoroutine("LoseCoroutine2Part2");

            if (lose3)
                StartCoroutine(LoseCoroutine3(loseTime));
            else if (!lose3)
                StopCoroutine("LoseCoroutine3");
            if (lose3Part2)
                StartCoroutine(LoseCoroutine3Part2(loseTime));
            else if (!lose3Part2)
                StopCoroutine("LoseCoroutine3Part2");

            if (loseMBase)
                StartCoroutine(LoseCoroutineMonsterBase(loseTime));
            else if(!loseMBase)
                StopCoroutine("LoseCoroutineMonsterBase");

            if (loseGame)
                StartCoroutine(LoseCoroutineHumanBase(loseTime));
            else if(!loseGame)
                StopCoroutine("LoseCoroutineHumanBase");
        }
        /////////////////////////////////////////////////////Lose Conditions/////////////////////////////////////////////////////


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
        //////////Push Back Zones////////////
        if(humansCanPushBack)
        {
            if (collision.CompareTag("Lose1"))
                lose1 = true;
            if (collision.CompareTag("Lose1Part2"))
                lose1Part2 = true;

            if (collision.CompareTag("Lose2"))
                lose2 = true;
            if (collision.CompareTag("Lose2Part2"))
                lose2Part2 = true;

            if (collision.CompareTag("Lose3"))
                lose3 = true;
            if (collision.CompareTag("Lose3Part2"))
                lose3Part2 = true;

            if (collision.CompareTag("LoseGame"))
                loseGame = true;

            if (collision.CompareTag("WinGame"))
                loseMBase = true;
                
        }

        ///////////////////////slowing the object that collides with the back of another object////////////////////////////////////////
        if(slowingObjects)
        {
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
        }
        ///////////////////////slowing the object that collides with the back of another object////////////////////////////////////////


        ////////////////////////////////////////////////////////ATTACK/////////////////////////////////////////////////
        if(attacking)
        {
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
        }
        ////////////////////////////////////////////////////////ATTACK/////////////////////////////////////////////////
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stopped = false;
        speed = mySpeed;
        //StopAllCoroutines();
        
        lose1 = false;
        lose1Part2 = false;
        lose2 = false;
        lose2Part2 = false;
        lose3 = false;
        lose3Part2 = false;
        loseGame = false;
        loseMBase = false;
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

    ////////////////////////////////////////////////LOSE GROUND COROUTINES//////////////////////////////////////////////////
    IEnumerator LoseCoroutine1(float loseTime)
    {
        if (lose1)
        {
            yield return new WaitForSeconds(loseTime);
            //MapManager.battleZone1Owned = false;
            //MapManager.battle1Neutral = false;
            //MapManager.humansWonBattle1 = true;
            //MapManager.monstersWonBattle1 = false;
            MapManager.b1Status = 2;
        }
        else yield return null;
    }
    IEnumerator LoseCoroutine1Part2(float loseTime)
    {
        if (lose1Part2)
        {
            yield return new WaitForSeconds(loseTime);
            //MapManager.battleZone1Part2Owned = false;
            //MapManager.battle1Part2Neutral = false;
            //MapManager.humansWonBattle1Part2 = true;
            //MapManager.monstersWonBattle1Part2 = false;
            MapManager.b1p2Status = 2;
        }
        else yield return null;
    }


    IEnumerator LoseCoroutine2(float loseTime)
    {
        if (lose2)
        {
            yield return new WaitForSeconds(loseTime);
            //MapManager.battleZone2Owned = false;
            //MapManager.battle2Neutral = false;
            //MapManager.humansWonBattle2 = true;
            //MapManager.monstersWonBattle2 = false;
            MapManager.b2Status = 2;
        }
        else yield return null;
    }
    IEnumerator LoseCoroutine2Part2(float loseTime)
    {
        if (lose2Part2)
        {
            yield return new WaitForSeconds(loseTime);
            //MapManager.battleZone2Part2Owned = false;
            //MapManager.battle2Part2Neutral = false;
            //MapManager.humansWonBattle2Part2 = true;
            //MapManager.monstersWonBattle2Part2 = false;
            MapManager.b2p2Status = 2;
        }
        else yield return null;
    }


    IEnumerator LoseCoroutine3(float loseTime)
    {
        if (lose3)
        {
            yield return new WaitForSeconds(loseTime);
            //MapManager.battleZone3Owned = false;
            //MapManager.battle3Neutral = false;
            //MapManager.humansWonBattle3 = true;
            //MapManager.monstersWonBattle3 = false;
            MapManager.b3Status = 2;
        }
        else yield return null;
    }
    IEnumerator LoseCoroutine3Part2(float loseTime)
    {
        if (lose3Part2)
        {
            yield return new WaitForSeconds(loseTime);
            //MapManager.battleZone3Part2Owned = false;
            //MapManager.battle3Part2Neutral = false;
            //MapManager.humansWonBattle3Part2 = true;
            //MapManager.monstersWonBattle3Part2 = false;
            MapManager.b3p2Status = 2;
        }
        else yield return null;
    }
    IEnumerator LoseCoroutineHumanBase(float loseTime)
    {
        if(loseGame)
        {
            yield return new WaitForSeconds(loseTime);
            MapManager.hbStatus = 2;
        }
        else yield return null;
    }
    IEnumerator LoseCoroutineMonsterBase(float loseTime)
    {
        if (loseMBase)
        {
            yield return new WaitForSeconds(loseTime);
            MapManager.mbstatus = 2;
        }
        else yield return null;
    }
}
