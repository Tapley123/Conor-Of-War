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

    public List<GameObject> humansOnScreen = new List<GameObject>();

    public Transform humanSpawn1, humanSpawn1Part2, humanSpawn2, humanSpawn2Part2, humanSpawn3, humanSpawn3Part2, humanBaseSpawn, monsterBaseSpawn;
    public static bool battleZone1 = true, battleZone1Part2 = false, battleZone2 = true, battleZone2Part2 = false, battleZone3 = true, battleZone3Part2 = false, monsterBaseZone = false, humanBaseZone = false;

    private void Start()
    {
        battleZone1 = true;
        battleZone2 = true;
        battleZone3 = true;
        availableHumans = 0;
        spawnChoice = 0;
        int[] humansCost = { soldierCost, archerCost, rogueCost, knightCost, wizardCost };
        
    }

    private void Update()
    {
        

        if (hCurrency < 0)
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

        GameObject human;
        ///////////////////////////////////////////////////////////////////////////////////////////  
        if (monsterBaseZone)
        {
            human = Instantiate(humans[spawnChoice], monsterBaseSpawn.position, transform.rotation);
            humansOnScreen.Add(human);
        }
            
        if (humanBaseZone)
        {
            human = Instantiate(humans[spawnChoice], humanBaseSpawn.position, transform.rotation);
            humansOnScreen.Add(human);
        }
            
        if (battleZone1)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn1.position, transform.rotation);
            humansOnScreen.Add(human);
        }
            
        if (battleZone1Part2)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn1Part2.position, transform.rotation);
            humansOnScreen.Add(human);
        }
            
        if (battleZone2)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn2.position, transform.rotation);
            humansOnScreen.Add(human);
        }
            
        if (battleZone2Part2)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn2Part2.position, transform.rotation);
            humansOnScreen.Add(human);
        }
            
        if (battleZone3)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn3.position, transform.rotation);
            humansOnScreen.Add(human);
        }
            
        if (battleZone3Part2)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn3Part2.position, transform.rotation);
            humansOnScreen.Add(human);
        }
            
        /*
            if (monsterBaseZone)
        {
            human = Instantiate(humans[spawnChoice], monsterBaseSpawn.position, transform.rotation);
            humansOnScreen.Add(human);
            human.transform.parent = GameObject.Find("Humans").transform;
        }

        if (humanBaseZone)
        {
            human = Instantiate(humans[spawnChoice], humanBaseSpawn.position, transform.rotation);
            humansOnScreen.Add(human);
            human.transform.parent = GameObject.Find("Humans").transform;
        }

        if (battleZone1)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn1.position, transform.rotation);
            humansOnScreen.Add(human);
            human.transform.parent = GameObject.Find("Humans").transform;
        }

        if (battleZone1Part2)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn1Part2.position, transform.rotation);
            humansOnScreen.Add(human);
            human.transform.parent = GameObject.Find("Humans").transform;
        }

        if (battleZone2)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn2.position, transform.rotation);
            humansOnScreen.Add(human);
            human.transform.parent = GameObject.Find("Humans").transform;
        }

        if (battleZone2Part2)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn2Part2.position, transform.rotation);
            humansOnScreen.Add(human);
            human.transform.parent = GameObject.Find("Humans").transform;
        }

        if (battleZone3)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn3.position, transform.rotation);
            humansOnScreen.Add(human);
            human.transform.parent = GameObject.Find("Humans").transform;
        }

        if (battleZone3Part2)
        {
            human = Instantiate(humans[spawnChoice], humanSpawn3Part2.position, transform.rotation);
            humansOnScreen.Add(human);
            human.transform.parent = GameObject.Find("Humans").transform;
        }
        */
        ///////////////////////////////////////////////////////////////////////////////////////////

        hCurrency -= humansCost[spawnChoice];
    }
}
