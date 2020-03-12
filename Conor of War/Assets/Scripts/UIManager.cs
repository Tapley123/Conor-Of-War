using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject zombieDropDown, werewolfDropDown, vampireDropDown, skeletonDropDown, demonDropDown;

    public GameObject zombie, werewolf, vampire, skeleton, demon;
    public GameObject soldier, knight, archer, rogue, wizard;

    public Transform cameraT;
    public GameObject monsterSpawn1, monsterSpawn1Part2, monsterSpawn2, monsterSpawn2Part2, monsterSpawn3, monsterSpawn3Part2, monsterSpawnMyBase, monsterSpawnEnemyBase, humanSpawn;
    private Vector2 monsterSpawnPos;
    private Vector2 humanSpawnPos;

    public float zombieCooldownTime, werewolfCooldownTime, vampireCooldownTime, skeletonCooldownTime, demonCooldownTime;
    [SerializeField] private float zombieCost = 10f, werewolfCost = 30f, vampireCost = 20f, skeletonCost = 20f, demonCost = 80f;

    public static float currency;
    public static float winBattleBonusC;
    [SerializeField] private float startingCurrency = 300f;
    [SerializeField] private float winBattleBonus = 500f;
    public Text currencyText;
    public string currencyName;

    private void Awake()
    {
        currency = startingCurrency;
        winBattleBonusC = winBattleBonus;
    }

    void Start()
    {
        monsterSpawnPos = new Vector2(monsterSpawn1.transform.position.x, monsterSpawn1.transform.position.y);
        humanSpawnPos = new Vector2(humanSpawn.transform.position.x, humanSpawn.transform.position.y);

        currencyText.text = currencyName + ": " + currency.ToString(); ///display currency at the top of the screen

        zombieDropDown.SetActive(false);
        werewolfDropDown.SetActive(false);
        vampireDropDown.SetActive(false);
        skeletonDropDown.SetActive(false);
        demonDropDown.SetActive(false);
    }

    void Update()
    {
        currencyText.text = currencyName + ": " + currency.ToString(); ///display currency at the top of the screen
    }


    ///////////////////////////////////////////////MAP/////////////////////////////////////////////////////////
    public void Map()
    {
        cameraT.position = new Vector3(cameraT.position.x, 15, cameraT.position.z);
    }
    ///////////////////////////////////////////////MAP/////////////////////////////////////////////////////////

    /// ///////////////////////////////CHANGING FIGHT ZONES////////////////////////////////////////////////////
    public void FightZone1()
    {
        cameraT.position = new Vector3(0, 0, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn1.transform.position.x, monsterSpawn1.transform.position.y);
    }
    public void FightZone1Part2()
    {
        cameraT.position = new Vector3(0, -45, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn1Part2.transform.position.x, monsterSpawn1Part2.transform.position.y);
    }



    public void FightZone2()
    {
        cameraT.position = new Vector3(0, -15, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn2.transform.position.x, monsterSpawn2.transform.position.y);
    }
    public void FightZone2Part2()
    {
        cameraT.position = new Vector3(0, -60, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn2Part2.transform.position.x, monsterSpawn2Part2.transform.position.y);
    }



    public void FightZone3()
    {
        cameraT.position = new Vector3(0, -30, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn3.transform.position.x, monsterSpawn3.transform.position.y);
    }
    public void FightZone3Part2()
    {
        cameraT.position = new Vector3(0, -75, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn3Part2.transform.position.x, monsterSpawn3Part2.transform.position.y);
    }



    public void MyBase()
    {
        cameraT.position = new Vector3(0, -90, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawnMyBase.transform.position.x, monsterSpawnMyBase.transform.position.y);
    }
    public void EnemyBase()
    {
        cameraT.position = new Vector3(0, -105, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawnEnemyBase.transform.position.x, monsterSpawnEnemyBase.transform.position.y);
    }
    /// ///////////////////////////////CHANGING FIGHT ZONES////////////////////////////////////////////////////


    /// ///////////////////////////////SPAWNING MONSTERS////////////////////////////////////////////////////
    public void Zombie()
    {
        if(currency >= zombieCost)
        {
            StartCoroutine(ZombieCoroutine(zombieCooldownTime));
            currency -= zombieCost;
            CoolDown.zombieButtonClicked = true;
        }
    }

    public void Werewolf()
    {
        if (currency >= werewolfCost)
        {
            StartCoroutine(WerewolfCoroutine(werewolfCooldownTime));
            currency -= werewolfCost;
        }
    }

    public void Vampire()
    {
        if (currency >= vampireCost)
        {
            StartCoroutine(VampireCoroutine(vampireCooldownTime));
            currency -= vampireCost;
        }
    }

    public void Skeleton()
    {
        if (currency >= skeletonCost)
        {
            StartCoroutine(SkeletonCoroutine(skeletonCooldownTime));
            currency -= skeletonCost;
        }
    }

    public void Demon()
    {
        if (currency >= demonCost)
        {
            StartCoroutine(DemonCoroutine(demonCooldownTime));
            currency -= demonCost;
        }
    }
    /// ///////////////////////////////SPAWNING MONSTERS////////////////////////////////////////////////////


    /// ///////////////////////////////MONSTER DROP DOWN MENUS////////////////////////////////////////////////////
    public void ZombieDropDown()
    {
        zombieDropDown.SetActive(true);
    }
    public void ExitZombieDropDown()
    {
        zombieDropDown.SetActive(false);
    }


    public void WerewolfDropDown()
    {
        werewolfDropDown.SetActive(true);
    }
    public void ExitWerewolfDropDown()
    {
        werewolfDropDown.SetActive(false);
    }


    public void VampireDropDown()
    {
        vampireDropDown.SetActive(true);
    }
    public void ExitVampireDropDown()
    {
        vampireDropDown.SetActive(false);
    }


    public void SkeletonDropDown()
    {
        skeletonDropDown.SetActive(true);
    }
    public void ExitSkeletonDropDown()
    {
        skeletonDropDown.SetActive(false);
    }


    public void DemonDropDown()
    {
        demonDropDown.SetActive(true);
    }
    public void ExitDemonDropDown()
    {
        demonDropDown.SetActive(false);
    }
    /// ///////////////////////////////MONSTER DROP DOWN MENUS////////////////////////////////////////////////////


    /// ///////////////////////////////MONSTER COOLDOWN TIMERS////////////////////////////////////////////////////
    IEnumerator ZombieCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(zombie, monsterSpawnPos, zombie.transform.rotation);
    }

    IEnumerator WerewolfCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(werewolf, monsterSpawnPos, zombie.transform.rotation);
    }

    IEnumerator VampireCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(vampire, monsterSpawnPos, zombie.transform.rotation);
    }

    IEnumerator SkeletonCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(skeleton, monsterSpawnPos, zombie.transform.rotation);
    }

    IEnumerator DemonCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(demon, monsterSpawnPos, zombie.transform.rotation);
    }
    /// ///////////////////////////////MONSTER COOLDOWN TIMERS////////////////////////////////////////////////////
}
