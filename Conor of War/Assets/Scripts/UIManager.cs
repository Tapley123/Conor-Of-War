using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject monster1;
    public GameObject spawnObj;
    [SerializeField] private Vector2 spawnPos;

    void Start()
    {
        spawnPos = new Vector2(spawnObj.transform.position.x, spawnObj.transform.position.y);
    }
    
    void Update()
    {
        
    }

    public void SpawnMonster1()
    {
        Instantiate(monster1, spawnPos, monster1.transform.rotation);
        Debug.Log("monster 1 spawn");
    }
}
