using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject zombie, werewolf, vampire, skeleton, demon;
    public GameObject soldier, knight, archer, rogue, wizard;
    public GameObject monsterSpawn, humanSpawn;
    private Vector2 monsterSpawnPos;
    private Vector2 humanSpawnPos;

    public float zombieCooldownTime, werewolfCooldownTime, vampireCooldownTime, skeletonCooldownTime, demonCooldownTime;
    [SerializeField] private float zombieCost = 10f, werewolfCost = 30f, vampireCost = 20f, skeletonCost = 20f, demonCost = 80f;

    public float currency = 100f;
    public Text currencyText;
    public string currencyName;

    void Start()
    {
        monsterSpawnPos = new Vector2(monsterSpawn.transform.position.x, monsterSpawn.transform.position.y);
        humanSpawnPos = new Vector2(humanSpawn.transform.position.x, humanSpawn.transform.position.y);
        
        currencyText.text = currencyName + ": " + currency.ToString(); ///display currency at the top of the screen
    }

    void Update()
    {
        currencyText.text = currencyName + ": " + currency.ToString(); ///display currency at the top of the screen
    }

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
}
