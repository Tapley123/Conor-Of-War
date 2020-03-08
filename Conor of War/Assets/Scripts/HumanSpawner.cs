using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public int hCurrency, spawnChoice;
    public int knightCost, rogueCost, soldierCost, wizardCost, archerCost;
    public float spawnTimer;

    public int availableHumans;
    public int[] humansCost;

    public GameObject[] humans;

    public Transform humanSpawn1, humanSpawn1Part2, humanSpawn2, humanSpawn2Part2, humanSpawn3, humanSpawn3Part2, humanBaseSpawn, monsterBaseSpawn;
    private bool battleZone1 = true, battleZone2 = false, monsterBaseZone = false, humanBaseZone = false;

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
        //Debug.Log(humansCost[spawnChoice]);

        ///////////////////////////////////////////////////////////////////////////////////////////
        if(battleZone1)
        {
            Instantiate(humans[spawnChoice], humanSpawn1.position, transform.rotation);
            Instantiate(humans[spawnChoice], humanSpawn2.position, transform.rotation);
            Instantiate(humans[spawnChoice], humanSpawn3.position, transform.rotation);
        }

        if (battleZone2)
        {
            Instantiate(humans[spawnChoice], humanSpawn1Part2.position, transform.rotation);
            Instantiate(humans[spawnChoice], humanSpawn2Part2.position, transform.rotation);
            Instantiate(humans[spawnChoice], humanSpawn3Part2.position, transform.rotation);
        }
            
        if(monsterBaseZone)
            Instantiate(humans[spawnChoice], monsterBaseSpawn.position, transform.rotation);
        if(humanBaseZone)
            Instantiate(humans[spawnChoice], humanBaseSpawn.position, transform.rotation);
        ///////////////////////////////////////////////////////////////////////////////////////////

        hCurrency -= humansCost[spawnChoice];
    }
}
