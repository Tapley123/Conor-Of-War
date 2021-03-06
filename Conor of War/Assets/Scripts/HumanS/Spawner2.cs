﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public int hCurrency, spawnChoice;
    public int knightCost, rogueCost, soldierCost, wizardCost, archerCost;
    public float spawnTimer;

    public int availableHumans;
    public int[] humansCost;

    public GameObject[] humans;

    public List<GameObject> humansOnScreen = new List<GameObject>();

    public Transform humanSpawn1, humanSpawn2, humanSpawn3;

    private void Start()
    {
        availableHumans = 0;
        spawnChoice = 0;
        int[] humansCost = { soldierCost, archerCost, rogueCost, knightCost, wizardCost };
        
    }

    private void Update()
    {
        
        if(hCurrency < 0)
        {
            hCurrency = 0;
        }

        if(hCurrency >= soldierCost)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                availableHumans = 0;
                CheckHumans();
            }
        }
        
    }

    

    void CheckHumans()
    {
        int[] humansCost = { soldierCost, archerCost, rogueCost, knightCost, wizardCost };

        if(hCurrency > 0)
        {
            foreach (int human in humansCost)
            {
                //Debug.Log(human);

                if (human <= hCurrency)
                {
                    availableHumans++;
                }


                if ((human > hCurrency || human == humansCost[4]) && hCurrency > 0)
                {
                    SpawnHuman();
                }

            }
        }

        


    }

    public void SpawnHuman()
    {
        spawnChoice = Random.Range(0, availableHumans);
        spawnTimer = 5;

        int[] humansCost = { soldierCost, archerCost, rogueCost, knightCost, wizardCost };
        Debug.Log(humansCost[spawnChoice]);

        GameObject human = Instantiate(humans[spawnChoice], transform.position, transform.rotation);
        human.transform.parent = GameObject.Find("Humans1").transform;
        humansOnScreen.Add(human);
        hCurrency -= humansCost[spawnChoice];

    }
}
