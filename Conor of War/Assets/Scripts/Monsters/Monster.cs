using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private bool advanceStages = true; //if true you can win
    private bool winZone1 = false, winZone1Part2 = false, winZone2 = false, winZone2Part2 = false, winZone3 = false, winZone3Part2 = false, winZoneHumanBase = false;
    private bool win1 = false, win1Part2 = false, win2 = false, win2Part2 = false, win3 = false, win3Part2 = false, winGame = false;
    private float winTime = 5f;

    private Rigidbody2D myRb;
    public Transform healthBar;

    private bool stopped = false;

    public string monsterName;
    private float health;
    private float fullHealth;
    private float speed;
    private float damagePerSecond;
    private float pointPerKill;

    private float zombieSpeed = 2f, werewolfSpeed = 1f, vampireSpeed = 2f, skeletonSpeed = 3f, demonSpeed = 1f;
    private float zombiePPK = 15f, werewolfPPK = 45f, vampirePPK = 30f, skeletonPPK = 30f, demonPPK = 120f; //points per kill
    private float archerDPS = 15f, knightDPS = 60f, rogueDPS = 60f, soldierDPS = 20f, wizardDPS = 20f;
    private float mySpeed;

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
            health = 120f;
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

        fullHealth = health;
    }


    void Update()
    {
        ///////Map And Advance Stages//////
        if(advanceStages)
        {
            if (win1)
            {
                MapManager.battleZone1Owned = true;
            }
            if (win1Part2)
            {
                MapManager.battleZone1Part2Owned = true;
            }


            if (win2)
            {
                MapManager.battleZone2Owned = true;
            }
            if (win2Part2)
            {
                MapManager.battleZone2Part2Owned = true;
            }


            if (win3)
            {
                MapManager.battleZone3Owned = true;
            }
            if (win3Part2)
            {
                MapManager.battleZone3Part2Owned = true;
            }
        }

        /////////////////////////////////////////////////////Win Conditions/////////////////////////////////////////////////////
        if(advanceStages)
        {
            if (winZone1)
                StartCoroutine(WinCoroutine1(winTime));
            else if (!winZone1)
                StopCoroutine("WinCoroutine1");
            if (winZone1Part2)
                StartCoroutine(WinCoroutine1Part2(winTime));
            else if (!winZone1Part2)
                StopCoroutine("WinCoroutine1Part2");
            
            if (winZone2)
                StartCoroutine(WinCoroutine2(winTime));
            else if (!winZone2)
                StopCoroutine("WinCoroutine2");
            if (winZone2Part2)
                StartCoroutine(WinCoroutine2Part2(winTime));
            else if (!winZone2Part2)
                StopCoroutine("WinCoroutine2Part2");
            
            if (winZone3)
                StartCoroutine(WinCoroutine3(winTime));
            else if (!winZone3)
                StopCoroutine("WinCoroutine3");
            if (winZone3Part2)
                StartCoroutine(WinCoroutine3Part2(winTime));
            else if (!winZone3Part2)
                StopCoroutine("WinCoroutine3Part2");

            if (winZoneHumanBase)
                StartCoroutine(WinCoroutineHumanBase(winTime));
            else if (!winZoneHumanBase)
                StopCoroutine("WinCoroutineHumanBase");
        }
        /////////////////////////////////////////////////////Win Conditions/////////////////////////////////////////////////////


        myRb.velocity = new Vector2(speed, 0);

        if(health <= 0)
        {
            Dead();
        }

        float healthNormalized = health / fullHealth; //Change the health value to be between 0 and 1
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
        Destroy(this.gameObject);
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
        if(advanceStages)
        {
            if (collision.CompareTag("Win1"))
                winZone1 = true;
            if (collision.CompareTag("Win1Part2"))
                winZone1Part2 = true;

            if (collision.CompareTag("Win2"))
                winZone2 = true;
            if (collision.CompareTag("Win2Part2"))
                winZone2Part2 = true;

            if (collision.CompareTag("Win3"))
                winZone3 = true;
            if (collision.CompareTag("Win3Part2"))
                winZone3Part2 = true;

            if (collision.CompareTag("WinGame"))
                winZoneHumanBase = true;
        }
        

        ///////////////////////slowing the object that collides with the back of another object////////////////////////////////////////
        if (collision.CompareTag("Demon") && collision.gameObject.transform.position.x > transform.position.x)
        {
            //Debug.Log("Demon");
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();
            //speed = m.speed;

            if (stopped)
                speed = 0;
            else
                speed = m.speed;
        }

        if (collision.CompareTag("Skeleton") && collision.gameObject.transform.position.x > transform.position.x)
        {
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();

            if (stopped)
                speed = 0;
            else
                speed = m.speed;
        }

        if (collision.CompareTag("Vampire") && collision.gameObject.transform.position.x > transform.position.x)
        {
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();

            if (stopped)
                speed = 0;
            else
                speed = m.speed;
        }

        if (collision.CompareTag("Werewolf") && collision.gameObject.transform.position.x > transform.position.x)
        {
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();

            if (stopped)
                speed = 0;
            else
                speed = m.speed;
        }

        if (collision.CompareTag("Zombie") && collision.gameObject.transform.position.x > transform.position.x)
        {
            GameObject monsterInFront = collision.gameObject;
            Monster m = monsterInFront.GetComponent<Monster>();

            if (stopped)
                speed = 0;
            else
                speed = m.speed;
        }
        ///////////////////////slowing the object that collides with the back of another object////////////////////////////////////////


        ////////////////////////////////////////////////////////ATTACK/////////////////////////////////////////////////
        if (collision.CompareTag("Archer"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackArcherCoroutine());
        }
        if (collision.CompareTag("Knight"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackKnightCoroutine());
        }
        if (collision.CompareTag("Rogue"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackRogueCoroutine());
        }
        if (collision.CompareTag("Soldier"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackSoldierCoroutine());
        }
        if (collision.CompareTag("Wizard"))
        {
            stopped = true;
            speed = 0;
            StartCoroutine(AttackWizardCoroutine());
        }
        ////////////////////////////////////////////////////////ATTACK/////////////////////////////////////////////////
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(advanceStages)
        {
            winZone1 = false;
            winZone2 = false;
            winZone3 = false;
            winZone1Part2 = false;
            winZone2Part2 = false;
            winZone3Part2 = false;
        }

        stopped = false;
        speed = mySpeed;
        StopAllCoroutines();

        if(collision.CompareTag("Archer") || collision.CompareTag("Knight") || collision.CompareTag("Rogue") || collision.CompareTag("Soldier") || collision.CompareTag("Wizard"))
        {
            if (monsterName == "Zombie")
                UIManager.currency = UIManager.currency + zombiePPK;

            if (monsterName == "Werewolf")
                UIManager.currency = UIManager.currency + werewolfPPK;

            if (monsterName == "Vampire")
                UIManager.currency = UIManager.currency + vampirePPK;

            if (monsterName == "Skeleton")
                UIManager.currency = UIManager.currency + skeletonPPK;

            if (monsterName == "Demon")
                UIManager.currency = UIManager.currency + demonPPK;
        }
    }

    
    /// //////////////////////////////////////////////ATTACK COROUTINES///////////////////////////////////////////////////
    IEnumerator AttackArcherCoroutine()
    {
        while(health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= archerDPS;
        }
    }
    IEnumerator AttackKnightCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= knightDPS;
        }
    }
    IEnumerator AttackRogueCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= rogueDPS;
        }
    }
    IEnumerator AttackSoldierCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= soldierDPS;
        }
    }
    IEnumerator AttackWizardCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= wizardDPS;
        }
    }
    /// //////////////////////////////////////////////ATTACK COROUTINES///////////////////////////////////////////////////


    ////////////////////////////////////////////////////WIN COROUTINES////////////////////////////////////////////////////
    IEnumerator WinCoroutine1(float winTime)
    {
        if (winZone1)
        {
            //Debug.Log("Time to win = " + winTime);
            yield return new WaitForSeconds(winTime);
            win1 = true;
            //Debug.Log("Win1");
        }
        else yield return null;
    }

    IEnumerator WinCoroutine1Part2(float winTime)
    {
        if (winZone1Part2)
        {
            yield return new WaitForSeconds(winTime);
            win1Part2 = true;
            //Debug.Log("Win1Part2");
        }
        else yield return null;
    }


    IEnumerator WinCoroutine2(float winTime)
    {
        if (winZone2)
        {
            //Debug.Log("Time to win = " + winTime);
            yield return new WaitForSeconds(winTime);
            win2 = true;
           //Debug.Log("Win2");
        }
        else yield return null;
    }

    IEnumerator WinCoroutine2Part2(float winTime)
    {
        if (winZone2Part2)
        {
            yield return new WaitForSeconds(winTime);
            win2Part2 = true;
            //Debug.Log("Win2Part2");
        }
        else yield return null;
    }


    IEnumerator WinCoroutine3(float winTime)
    {
        if (winZone3)
        {
            yield return new WaitForSeconds(winTime);
            win3 = true;
            //Debug.Log("Win3");
        }
        else yield return null;
    }

    IEnumerator WinCoroutine3Part2(float winTime)
    {
        if (winZone3Part2)
        {
            yield return new WaitForSeconds(winTime);
            win3Part2 = true;
            //Debug.Log("Win3Part2");
        }
        else yield return null;
    }

    IEnumerator WinCoroutineHumanBase(float winTime)
    {
        if (winZoneHumanBase)
        {
            yield return new WaitForSeconds(winTime);
            winGame = true;
            //Debug.Log("Win3Part2");
        }
        else yield return null;
    }
    ////////////////////////////////////////////////////WIN COROUTINES////////////////////////////////////////////////////
}
