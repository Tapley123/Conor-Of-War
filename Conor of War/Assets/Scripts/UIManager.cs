using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject zombie, werewolf, vampire, skeleton, demon;
    public GameObject soldier, knight, archer, rogue, wizard;
    public GameObject monsterSpawn, humanSpawn;
    private Vector2 monsterSpawnPos;
    [SerializeField] private Vector2 humanSpawnPos;

    public float zombieCooldownTime, werewolfCooldownTime, vampireCooldownTime, skeletonCooldownTime, demonCooldownTime;

    void Start()
    {
        monsterSpawnPos = new Vector2(monsterSpawn.transform.position.x, monsterSpawn.transform.position.y);
        humanSpawnPos = new Vector2(humanSpawn.transform.position.x, humanSpawn.transform.position.y);
    }

    void Update()
    {

    }

    public void Zombie()
    {
        StartCoroutine(ZombieCoroutine(zombieCooldownTime));
    }

    public void Werewolf()
    {
        StartCoroutine(WerewolfCoroutine(werewolfCooldownTime));
    }

    public void Vampire()
    {
        StartCoroutine(VampireCoroutine(vampireCooldownTime));
    }

    public void Skeleton()
    {
        StartCoroutine(SkeletonCoroutine(skeletonCooldownTime));
    }

    public void Demon()
    {
        StartCoroutine(DemonCoroutine(demonCooldownTime));
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
