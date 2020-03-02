using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject zombie, werewolf, vampire, skeleton, demon;
    public GameObject soldier, knight, archer, rogue, wizard;
    public GameObject monsterSpawn, humanSpawn;
    private Vector2 monsterSpawnPos;
    [SerializeField]private Vector2 humanSpawnPos;

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
        Instantiate(zombie, monsterSpawnPos, zombie.transform.rotation);
    }

    public void Werewolf()
    {
        Instantiate(werewolf, monsterSpawnPos, zombie.transform.rotation);
    }

    public void Vampire()
    {
        Instantiate(vampire, monsterSpawnPos, zombie.transform.rotation);
    }

    public void Skeleton()
    {
        Instantiate(skeleton, monsterSpawnPos, zombie.transform.rotation);
    }

    public void Demon()
    {
        Instantiate(demon, monsterSpawnPos, zombie.transform.rotation);
    }
}
