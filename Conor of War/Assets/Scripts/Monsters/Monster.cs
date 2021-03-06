﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private bool youWon = false; //this bool determines if you won the game

    private float winBattleBonus = 500f;

    private Transform cameraT;

    private bool inMBase = false, inB1 = false, inB1P2 = false, inB2 = false, inB2P2 = false, inB3 = false, inB3P2 = false, inHBase = false;
    private bool monstersCanBeRemovedFromInactiveZones = true;

    private bool advanceStages = true; //if true you can win
    private bool winZone1 = false, winZone1Part2 = false, winZone2 = false, winZone2Part2 = false, winZone3 = false, winZone3Part2 = false, winZoneHumanBase = false, winZoneMonsterBase = false;
    private bool win1 = false, win1Part2 = false, win2 = false, win2Part2 = false, win3 = false, win3Part2 = false, winGame = false;
    private float winTime = 6f;

    private Rigidbody2D myRb;
    public Transform healthBar;

    private bool stopped = false;
    public bool vampCantAttack = false;

    public string monsterName;
    public float health;
    private float fullHealth;
    public float speed;
    private float damagePerSecond;
    private float pointPerKill;

    private float zombieSpeed = 2f, werewolfSpeed = 1f, vampireSpeed = 2f, skeletonSpeed = 3f, demonSpeed = 1f;
    private float zombiePPK = 15f, werewolfPPK = 45f, vampirePPK = 30f, skeletonPPK = 30f, demonPPK = 120f; //points per kill
    private float archerDPS = 15f, knightDPS = 60f, rogueDPS = 60f, soldierDPS = 20f, wizardDPS = 20f;
    private float mySpeed;

    bool isAttacking = false;

    public bool canExplode = false;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        cameraT = GameObject.Find("Main Camera").transform;

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
        KillMonstersWhenInactive();
        /////////////////////////////////////////////////////Win Conditions/////////////////////////////////////////////////////
        if (advanceStages)
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

            if (winZoneMonsterBase)
                StartCoroutine(WinCoroutineMonsterBase(winTime));
            else if (!winZoneMonsterBase)
                StopCoroutine("WinCoroutineMonsterBase");

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

        if(this.gameObject.tag == "Skeleton" && canExplode)
        {
            Debug.Log("boom");
            for(int i = 0; i <= 2; i++)
            {
                GameObject.Find("Human Spawner").GetComponent<HumanSpawner>().humansOnScreen[i].GetComponent<Human>().health -= 40;
            }

            
            
        }
    }

    public void SetHealthBarSize(float sizeNormalized)
    {
        healthBar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetHealthBarColour(Color colour)
    {
        healthBar.Find("Bar Sprite").GetComponent<SpriteRenderer>().color = colour;
    }

    private void KillMonstersWhenInactive()
    {
        //if monster is in monster base and monster base isnt active
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

        //if monster is in human base and monster human isnt active
        if (inHBase && !MapController.humanBaseActive)
            Dead();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        //kill any monseters in inactive zones
        if (monstersCanBeRemovedFromInactiveZones)
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

        if (advanceStages)
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

            if (collision.CompareTag("MSaveBase"))
                winZoneMonsterBase = true;
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

            if (this.gameObject.tag == "Vampire")
            {
                vampCantAttack = true;
            }
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
        if ((this.gameObject.tag == "Vampire" && collision.transform.position.x < this.transform.position.x + 5f) || this.gameObject.tag != "Vampire")
        {
            if(isAttacking == false)
            {
                if (collision.CompareTag("Archer"))
                {
                    stopped = true;
                    speed = 0;
                    StartCoroutine(AttackArcherCoroutine());
                    isAttacking = true;
                }
                if (collision.CompareTag("Knight"))
                {
                    stopped = true;
                    speed = 0;
                    StartCoroutine(AttackKnightCoroutine());
                    isAttacking = true;
                }
                if (collision.CompareTag("Rogue"))
                {
                    stopped = true;
                    speed = 0;
                    StartCoroutine(AttackRogueCoroutine());
                    isAttacking = true;
                }
                if (collision.CompareTag("Soldier"))
                {
                    stopped = true;
                    speed = 0;
                    StartCoroutine(AttackSoldierCoroutine());
                    isAttacking = true;
                }
                if (collision.CompareTag("Wizard"))
                {
                    stopped = true;
                    speed = 0;
                    StartCoroutine(AttackWizardCoroutine());
                    isAttacking = true;
                }
            }
        }
            
        ////////////////////////////////////////////////////////ATTACK/////////////////////////////////////////////////
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (advanceStages)
        {
            winZone1 = false;
            winZone2 = false;
            winZone3 = false;
            winZone1Part2 = false;
            winZone2Part2 = false;
            winZone3Part2 = false;
            winZoneMonsterBase = false;
            winZoneHumanBase = false;
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

        if (collision.CompareTag("Werewolf") && this.gameObject.tag == "Vampire")
        {
            vampCantAttack = false;
        }
    }

    









    /// //////////////////////////////////////////////ATTACK COROUTINES///////////////////////////////////////////////////
    IEnumerator AttackArcherCoroutine()
    {
        while(health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= archerDPS;
            isAttacking = false;
        }
    }
    IEnumerator AttackKnightCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= knightDPS;
            isAttacking = false;
        }
    }
    IEnumerator AttackRogueCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= rogueDPS;
            isAttacking = false;
        }
    }
    IEnumerator AttackSoldierCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= soldierDPS;
            isAttacking = false;
        }
    }
    IEnumerator AttackWizardCoroutine()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            health -= wizardDPS;
            isAttacking = false;
        }
    }
    /// //////////////////////////////////////////////ATTACK COROUTINES///////////////////////////////////////////////////


    ////////////////////////////////////////////////////WIN COROUTINES////////////////////////////////////////////////////
    IEnumerator WinCoroutine1(float winTime)
    {
        if (winZone1)
        {
            yield return new WaitForSeconds(winTime);
            MapController.battleZone1Active = false;
            MapController.battleZone1p2Active = true;
            UIManager.currency += UIManager.winBattleBonusC; //get currency bonus from wining a battle
            if (cameraT.position.y == 0)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }

    IEnumerator WinCoroutine1Part2(float winTime)
    {
        if (winZone1Part2)
        {
            yield return new WaitForSeconds(winTime);
            MapController.battleZone1Active = false;
            MapController.battleZone1p2Active = false;
            MapController.humanBaseActive = true;
            UIManager.currency += UIManager.winBattleBonusC; //get currency bonus from wining a battle
            if (cameraT.position.y == -45) //go back to map
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }


    IEnumerator WinCoroutine2(float winTime)
    {
        if (winZone2)
        {
            yield return new WaitForSeconds(winTime);
            MapController.battleZone2Active = false;
            MapController.battleZone2p2Active = true;
            UIManager.currency += UIManager.winBattleBonusC; //get currency bonus from wining a battle
            if (cameraT.position.y == -15)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }

    IEnumerator WinCoroutine2Part2(float winTime)
    {
        if (winZone2Part2)
        {
            yield return new WaitForSeconds(winTime);
            MapController.battleZone2Active = false;
            MapController.battleZone2p2Active = false;
            MapController.humanBaseActive = true;
            UIManager.currency += UIManager.winBattleBonusC; //get currency bonus from wining a battle
            if (cameraT.position.y == -60)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }


    IEnumerator WinCoroutine3(float winTime)
    {
        if (winZone3)
        {
            yield return new WaitForSeconds(winTime);
            MapController.battleZone3Active = false;
            MapController.battleZone3p2Active = true;
            UIManager.currency += UIManager.winBattleBonusC; //get currency bonus from wining a battle
            if (cameraT.position.y == -30)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }

    IEnumerator WinCoroutine3Part2(float winTime)
    {
        if (winZone3Part2)
        {
            yield return new WaitForSeconds(winTime);
            MapController.battleZone3Active = false;
            MapController.battleZone3p2Active = false;
            MapController.humanBaseActive = true;
            UIManager.currency += UIManager.winBattleBonusC; //get currency bonus from wining a battle
            if (cameraT.position.y == -75)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
        }
        else yield return null;
    }

    IEnumerator WinCoroutineHumanBase(float winTime)
    {
        if (winZoneHumanBase)
        {
            yield return new WaitForSeconds(winTime);
            youWon = true;
            MapController.win = true;
            if (cameraT.position.y == -105)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
            //Debug.Log("Monsters Win");
        }
        else yield return null;
    }

    IEnumerator WinCoroutineMonsterBase(float winTime)
    {
        if (winZoneMonsterBase)
        {
            yield return new WaitForSeconds(winTime);

            UIManager.currency += UIManager.winBattleBonusC; //get currency bonus from wining a battle
            if (cameraT.position.y == -90)
                cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);

            //the base is breache through the first battle lane
            if (!MapController.battleZone1p2Active && !MapController.battleZone1Active)
            {
                MapController.battleZone1Active = true;
                MapController.battleZone1p2Active = false;
                MapController.monsterBaseActive = false;
            }
            //the base is breache through the second battle lane
            if (!MapController.battleZone2p2Active && !MapController.battleZone2Active)
            {
                MapController.battleZone2Active = true;
                MapController.battleZone2p2Active = false;
                MapController.monsterBaseActive = false;
            }
            //the base is breache through the third battle lane
            if (!MapController.battleZone1p2Active && !MapController.battleZone1Active)
            {
                MapController.battleZone3Active = true;
                MapController.battleZone3p2Active = false;
                MapController.monsterBaseActive = false;
            }
        }
        else yield return null;
    }
    ////////////////////////////////////////////////////WIN COROUTINES////////////////////////////////////////////////////
}
