using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject zombie, werewolf, vampire, skeleton, demon;
    public GameObject soldier, knight, archer, rogue, wizard;

    public Transform cameraT;
    public GameObject monsterSpawn1, monsterSpawn2, monsterSpawn3, humanSpawn;
    private Vector2 monsterSpawnPos;
    private Vector2 humanSpawnPos;

    public float zombieCooldownTime, werewolfCooldownTime, vampireCooldownTime, skeletonCooldownTime, demonCooldownTime;
    [SerializeField] private float zombieCost = 10f, werewolfCost = 30f, vampireCost = 20f, skeletonCost = 20f, demonCost = 80f;

    public float currency = 100f;
    public Text currencyText;
    public string currencyName;

    void Start()
    {
        monsterSpawnPos = new Vector2(monsterSpawn1.transform.position.x, monsterSpawn1.transform.position.y);
        humanSpawnPos = new Vector2(humanSpawn.transform.position.x, humanSpawn.transform.position.y);

        currencyText.text = currencyName + ": " + currency.ToString(); ///display currency at the top of the screen
    }

    void Update()
    {
        currencyText.text = currencyName + ": " + currency.ToString(); ///display currency at the top of the screen
    }
    
    
    /// ///////////////////////////////CHANGING FIGHT ZONES////////////////////////////////////////////////////
    public void FightZone1()
    {
        cameraT.position = new Vector3(cameraT.position.x, 0, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn1.transform.position.x, monsterSpawn1.transform.position.y);
    }

    public void FightZone2()
    {
        cameraT.position = new Vector3(cameraT.position.x, -15, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn2.transform.position.x, monsterSpawn2.transform.position.y);
    }

    public void FightZone3()
    {
        cameraT.position = new Vector3(cameraT.position.x, -30, cameraT.position.z);
        monsterSpawnPos = new Vector2(monsterSpawn3.transform.position.x, monsterSpawn3.transform.position.y);
    }
    /// ///////////////////////////////CHANGING FIGHT ZONES////////////////////////////////////////////////////


    /// ///////////////////////////////SPAWNING MONSTERS////////////////////////////////////////////////////
    public void Zombie()
    {
        if(currency >= zombieCost)
        {
            StartCoroutine(ZombieCoroutine(zombieCooldownTime));
            currency -= zombieCost;
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



    /// ///////////////////////////////MONSTER COOLDOWN TIMERS////////////////////////////////////////////////////
    IEnumerator ZombieCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject zombGO = Instantiate(zombie, monsterSpawnPos, zombie.transform.rotation);
        zombGO.transform.parent = GameObject.Find("Monsters1").transform;
    }

    IEnumerator WerewolfCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject wereGO = Instantiate(werewolf, monsterSpawnPos, zombie.transform.rotation);
        wereGO.transform.parent = GameObject.Find("Monsters1").transform;
    }

    IEnumerator VampireCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject vampGO = Instantiate(vampire, monsterSpawnPos, zombie.transform.rotation);
        vampGO.transform.parent = GameObject.Find("Monsters1").transform;
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
