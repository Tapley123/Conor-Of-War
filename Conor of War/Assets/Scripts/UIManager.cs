using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject zombie, werewolf, vampire, skeleton, demon;
    public GameObject spawnObj;
    [SerializeField] private Vector2 spawnPos;

    void Start()
    {
        spawnPos = new Vector2(spawnObj.transform.position.x, spawnObj.transform.position.y);
    }
    
    void Update()
    {
        
    }

    public void Zombie()
    {
        Instantiate(zombie, spawnPos, zombie.transform.rotation);
    }

    public void Werewolf()
    {
        Instantiate(werewolf, spawnPos, zombie.transform.rotation);
    }

    public void Vampire()
    {
        Instantiate(vampire, spawnPos, zombie.transform.rotation);
    }

    public void Skeleton()
    {
        Instantiate(skeleton, spawnPos, zombie.transform.rotation);
    }

    public void Demon()
    {
        Instantiate(demon, spawnPos, zombie.transform.rotation);
    }
}
