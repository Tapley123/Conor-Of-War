using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private bool youLost = false; // this bool determins if you lost the game

    private Transform cameraT;

    private bool inMBase = false, inB1 = false, inB1P2 = false, inB2 = false, inB2P2 = false, inB3 = false, inB3P2 = false, inHBase;
    private bool humansCanBeRemovedFromInactiveZones = true;

    private bool humansCanPushBack = true;
    private bool win1 = false, win1Part2 = false, win2 = false, win2Part2 = false, win3 = false, win3Part2 = false, winGame = false, winHBase = false;
    private float loseTime = 10f;

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

        cameraT = GameObject.Find("Main Camera").transform;

        myRb = GetComponent<Rigidbody2D>();
        mySpeed = speed;
        fullHealth = health;
    }

    void Update()
    {
        KillHumansWhenInactive();
        /////////////////////////////////////////////////////Lose Conditions/////////////////////////////////////////////////////
        if (humansCanPushBack)
        {
            if (win1)
                StartCoroutine(WinCoroutine1(loseTime));
            else if (!win1)
                StopCoroutine("WinCoroutine1");
            if (win1Part2)
                StartCoroutine(WinCoroutine1Part2(loseTime));
            else if (!win1Part2)
                StopCoroutine("WinCoroutine1Part2");

            if (win2)
                StartCoroutine(WinCoroutine2(loseTime));
            else if (!win2)
                StopCoroutine("WinCoroutine2");
            if (win2Part2)
                StartCoroutine(WinCoroutine2Part2(loseTime));
            else if (!win2Part2)
                StopCoroutine("WinCoroutine2Part2");

            if (win3)
                StartCoroutine(WinCoroutine3(loseTime));
            else if (!win3)
                StopCoroutine("WinCoroutine3");
            if (win3Part2)
                StartCoroutine(WinCoroutine3Part2(loseTime));
            else if (!win3Part2)
                StopCoroutine("WinCoroutine3Part2");

            if (winHBase)
                StartCoroutine(WinCoroutineHumanBase(loseTime));
            else if(!winHBase)
                StopCoroutine("WinCoroutineHumanBase");

            if (winGame)
                StartCoroutine(WinCoroutineMonsterBase(loseTime));
            else if(!winGame)
                StopCoroutine("WinCoroutineMonsterBase");
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

    private void KillHumansWhenInactive()
    {
        //if human is in monster base and monster base isnt active
        if (inMBase && !MapController.monsterBaseActive)
            Dead();

        if (inB1 && !MapController.battleZone1Active)
            Dead();
        if (inB1P2 && !MapController.battleZone1p2Active)
            Dead();

        if (inB2 && !MapController.battleZone2Active)
            Dead();
        if (inB2P2 && !MapController.battleZone2p2Active)
            Dead();

        if (inB3 && !MapController.battleZone3Active)
            Dead();
        if (inB3P2 && !MapController.battleZone3p2Active)
            Dead();
        
        //if human is in human base and monster human isnt active
        if (inHBase && !MapController.humanBaseActive)
            Dead();
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        //kill any humans in inactive zones
        if(humansCanBeRemovedFromInactiveZones)
        {
            if (collision.CompareTag("KillAllMBase"))
                inMBase = true;

            if (collision.CompareTag("KillAllB1"))
                inB1 = true;
            if (collision.CompareTag("KillAllB1P2"))
                inB1P2 = true;

            if (collision.CompareTag("KillAllB2"))
                inB2 = true;
            if (collision.CompareTag("KillAllB2P2"))
                inB2P2 = true;

            if (collision.CompareTag("KillAllB3"))
                inB3 = true;
            if (collision.CompareTag("KillAllB3P2"))
                inB3P2 = true;

            if (collision.CompareTag("KillAllHBase"))
                inHBase = true;
        }
        

        //////////Push Back Zones////////////
        if(humansCanPushBack)
        {
            if (collision.CompareTag("Lose1"))
                win1 = true;
            if (collision.CompareTag("Lose1Part2"))
                win1Part2 = true;

            if (collision.CompareTag("Lose2"))
                win2 = true;
            if (collision.CompareTag("Lose2Part2"))
                win2Part2 = true;

            if (collision.CompareTag("Lose3"))
                win3 = true;
            if (collision.CompareTag("Lose3Part2"))
                win3Part2 = true;

            if (collision.CompareTag("LoseGame"))
                winGame = true;

            if (collision.CompareTag("HSaveBase"))
                winHBase = true;
                
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
        
        win1 = false;
        win1Part2 = false;
        win2 = false;
        win2Part2 = false;
        win3 = false;
        win3Part2 = false;
        winGame = false;
        winHBase = false;
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
    IEnumerator WinCoroutine1(float loseTime)
    {
        if (win1)
        {
            yield return new WaitForSeconds(loseTime);
            MapController.monsterBaseActive = true;
            MapController.battleZone1Active = false;
            MapController.battleZone1p2Active = false;
            if (cameraT.position.y == 0)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }
    IEnumerator WinCoroutine1Part2(float loseTime)
    {
        if (win1Part2)
        {
            MapController.battleZone1Active = true;
            MapController.battleZone1p2Active = false;
            if (cameraT.position.y == -45)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }


    IEnumerator WinCoroutine2(float loseTime)
    {
        if (win2)
        {
            yield return new WaitForSeconds(loseTime);
            MapController.monsterBaseActive = true;
            MapController.battleZone2Active = false;
            MapController.battleZone2p2Active = false;
            if (cameraT.position.y == -15)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }
    IEnumerator WinCoroutine2Part2(float loseTime)
    {
        if (win2Part2)
        {
            yield return new WaitForSeconds(loseTime);
            MapController.battleZone2Active = true;
            MapController.battleZone2p2Active = false;
            if (cameraT.position.y == -60)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }


    IEnumerator WinCoroutine3(float loseTime)
    {
        if (win3)
        {
            yield return new WaitForSeconds(loseTime);
            MapController.monsterBaseActive = true;
            MapController.battleZone3Active = false;
            MapController.battleZone3p2Active = false;
            if (cameraT.position.y == -30)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }
    IEnumerator WinCoroutine3Part2(float loseTime)
    {
        if (win3Part2)
        {
            yield return new WaitForSeconds(loseTime);
            MapController.battleZone3Active = true;
            MapController.battleZone3p2Active = false;
            if (cameraT.position.y == -75)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }
    IEnumerator WinCoroutineHumanBase(float loseTime)
    {
        if(winHBase)
        {
            yield return new WaitForSeconds(loseTime);

            if (cameraT.position.y == -105)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);

            //the base is breache through the first battle lane
            if (!MapController.battleZone1p2Active && !MapController.battleZone1Active)
            {
                MapController.battleZone1Active = false;
                MapController.battleZone1p2Active = true;
                MapController.humanBaseActive = false;
            }
            //the base is breache through the second battle lane
            if (!MapController.battleZone2p2Active && !MapController.battleZone2Active)
            {
                MapController.battleZone2Active = false;
                MapController.battleZone2p2Active = true;
                MapController.humanBaseActive = false;
            }
            //the base is breache through the third battle lane
            if (!MapController.battleZone1p2Active && !MapController.battleZone1Active)
            {
                MapController.battleZone3Active = false;
                MapController.battleZone3p2Active = true;
                MapController.humanBaseActive = false;
            }
        }
        else yield return null;
    }
    IEnumerator WinCoroutineMonsterBase(float loseTime)
    {
        if (winGame)
        {
            yield return new WaitForSeconds(loseTime);
            //Debug.Log("Humans Win");
            if (cameraT.position.y == -90)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
            youLost = true;
            MapController.lose = true;
        }
        else yield return null;
    }
}
