using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    //Activate Zones
    private bool advance1 = true, advance2 = true, advance3 = true;
    public static bool monsterBaseActive, humanBaseActive;
    public static bool battleZone1Active, battleZone1p2Active;
    public static bool battleZone2Active, battleZone2p2Active;
    public static bool battleZone3Active, battleZone3p2Active;
    //Map Control
    public GameObject monsterBase; 
    public GameObject tMonsterBase, battleZone1, battleZone1Part2, tHumanBase; //Zone 1
    public GameObject mMonsterBase, battleZone2, battleZone2Part2, mHumanBase; //Zone 2
    public GameObject bMonsterBase, battleZone3, battleZone3Part2, bHumanBase; //Zone 3
    public GameObject humanBase;
    //Buttons
    public GameObject buttonMBase;
    public GameObject button1, button1p2; //zone 1
    public GameObject button2, button2p2; //zone 2
    public GameObject button3, button3p2; //zone 3
    public GameObject buttonHBase;

    void Start()
    {
        //Controller Bools
        monsterBaseActive = false;
        battleZone1Active = true;
        battleZone2Active = true;
        battleZone3Active = true;
        battleZone1p2Active = false;
        battleZone2p2Active = false;
        battleZone3p2Active = false;
        humanBaseActive = false;
        //Map Pieces
        monsterBase.SetActive(true);
        tMonsterBase.SetActive(true);
        mMonsterBase.SetActive(true);
        bMonsterBase.SetActive(true);
        battleZone1.SetActive(false);
        battleZone2.SetActive(false);
        battleZone3.SetActive(false);
        battleZone1Part2.SetActive(false);
        battleZone2Part2.SetActive(false);
        battleZone3Part2.SetActive(false);
        tHumanBase.SetActive(false);
        mHumanBase.SetActive(false);
        bHumanBase.SetActive(false);
        humanBase.SetActive(false);
        //Buttons
        buttonMBase.SetActive(false);
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button1p2.SetActive(false);
        button2p2.SetActive(false);
        button3p2.SetActive(false);
        buttonHBase.SetActive(false);
        //Spawn Zones
        HumanSpawner.monsterBaseZone = false;
        HumanSpawner.battleZone1 = true;
        HumanSpawner.battleZone1Part2 = false;
        HumanSpawner.humanBaseZone = false;
    }
    
    void Update()
    {
        


        if(advance1)
        {
            if (monsterBaseActive && !battleZone1Active && !battleZone1p2Active) // add another check
            {
                //Map Pieces
                monsterBase.SetActive(true);
                tMonsterBase.SetActive(false);
                battleZone1.SetActive(false);
                battleZone1Part2.SetActive(false);
                tHumanBase.SetActive(false);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(true);
                button1.SetActive(false);
                button1p2.SetActive(false);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = true; //remove when all statements are in needs its own statement, i think lol
                HumanSpawner.battleZone1 = false;
                HumanSpawner.battleZone1Part2 = false;
                HumanSpawner.humanBaseZone = false;
            }
            if (battleZone1Active)
            {
                //Map Pieces
                monsterBase.SetActive(true); //
                tMonsterBase.SetActive(true);
                battleZone1.SetActive(false);
                battleZone1Part2.SetActive(false);
                tHumanBase.SetActive(false);
                humanBase.SetActive(false); //
                //Buttons
                buttonMBase.SetActive(false);
                button1.SetActive(true);
                button1p2.SetActive(false);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone1 = true;
                HumanSpawner.battleZone1Part2 = false;
                HumanSpawner.humanBaseZone = false;
            }
            if (battleZone1p2Active)
            {
                //Map Pieces
                monsterBase.SetActive(true); //
                tMonsterBase.SetActive(true);
                battleZone1.SetActive(true);
                battleZone1Part2.SetActive(false);
                tHumanBase.SetActive(false);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(false);
                button1.SetActive(false);
                button1p2.SetActive(true);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone1 = false;
                HumanSpawner.battleZone1Part2 = true;
                HumanSpawner.humanBaseZone = false;
            }
            if (humanBaseActive && !battleZone1Active && !battleZone1p2Active) //add another Check
            {
                //Map Pieces
                monsterBase.SetActive(true);
                tMonsterBase.SetActive(true);
                battleZone1.SetActive(true);
                battleZone1Part2.SetActive(true);
                tHumanBase.SetActive(true);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(false);
                button1.SetActive(false);
                button1p2.SetActive(false);
                buttonHBase.SetActive(true);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone1 = false;
                HumanSpawner.battleZone1Part2 = false;
                HumanSpawner.humanBaseZone = true;
            }
        }
        if (advance2)
        {
            if (monsterBaseActive && !battleZone2Active && !battleZone2p2Active) // add another check
            {
                //Map Pieces
                monsterBase.SetActive(true);
                mMonsterBase.SetActive(false);
                battleZone2.SetActive(false);
                battleZone2Part2.SetActive(false);
                mHumanBase.SetActive(false);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(true);
                button2.SetActive(false);
                button2p2.SetActive(false);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = true; //remove when all statements are in needs its own statement, i think lol
                HumanSpawner.battleZone2 = false;
                HumanSpawner.battleZone2Part2 = false;
                HumanSpawner.humanBaseZone = false;
            }
            if (battleZone2Active)
            {
                //Map Pieces
                monsterBase.SetActive(true); //
                mMonsterBase.SetActive(true);
                battleZone2.SetActive(false);
                battleZone2Part2.SetActive(false);
                mHumanBase.SetActive(false);
                humanBase.SetActive(false); //
                //Buttons
                buttonMBase.SetActive(false);
                button2.SetActive(true);
                button2p2.SetActive(false);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone2 = true;
                HumanSpawner.battleZone2Part2 = false;
                HumanSpawner.humanBaseZone = false;
            }
            if (battleZone2p2Active)
            {
                //Map Pieces
                monsterBase.SetActive(true); //
                mMonsterBase.SetActive(true);
                battleZone2.SetActive(true);
                battleZone2Part2.SetActive(false);
                mHumanBase.SetActive(false);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(false);
                button2.SetActive(false);
                button2p2.SetActive(true);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone2 = false;
                HumanSpawner.battleZone2Part2 = true;
                HumanSpawner.humanBaseZone = false;
            }
            if (humanBaseActive && !battleZone2Active && !battleZone2p2Active) //add another Check
            {
                //Map Pieces
                monsterBase.SetActive(true);
                mMonsterBase.SetActive(true);
                battleZone2.SetActive(true);
                battleZone2Part2.SetActive(true);
                mHumanBase.SetActive(true);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(false);
                button2.SetActive(false);
                button2p2.SetActive(false);
                buttonHBase.SetActive(true);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone2 = false;
                HumanSpawner.battleZone2Part2 = false;
                HumanSpawner.humanBaseZone = true;
            }
        }
        if (advance3)
        {
            if (monsterBaseActive && !battleZone3Active && !battleZone3p2Active) // add another check
            {
                //Map Pieces
                monsterBase.SetActive(true);
                bMonsterBase.SetActive(false);
                battleZone3.SetActive(false);
                battleZone3Part2.SetActive(false);
                bHumanBase.SetActive(false);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(true);
                button3.SetActive(false);
                button3p2.SetActive(false);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = true; //remove when all statements are in needs its own statement, i think lol
                HumanSpawner.battleZone3 = false;
                HumanSpawner.battleZone3Part2 = false;
                HumanSpawner.humanBaseZone = false;
            }
            if (battleZone3Active)
            {
                //Map Pieces
                monsterBase.SetActive(true); //
                bMonsterBase.SetActive(true);
                battleZone3.SetActive(false);
                battleZone3Part2.SetActive(false);
                bHumanBase.SetActive(false);
                humanBase.SetActive(false); //
                //Buttons
                buttonMBase.SetActive(false);
                button3.SetActive(true);
                button3p2.SetActive(false);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone3 = true;
                HumanSpawner.battleZone3Part2 = false;
                HumanSpawner.humanBaseZone = false;
            }
            if (battleZone3p2Active)
            {
                //Map Pieces
                monsterBase.SetActive(true); //
                bMonsterBase.SetActive(true);
                battleZone3.SetActive(true);
                battleZone3Part2.SetActive(false);
                bHumanBase.SetActive(false);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(false);
                button3.SetActive(false);
                button3p2.SetActive(true);
                buttonHBase.SetActive(false);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone3 = false;
                HumanSpawner.battleZone3Part2 = true;
                HumanSpawner.humanBaseZone = false;
            }
            if (humanBaseActive && !battleZone3Active && !battleZone3p2Active) //add another Check
            {
                //Map Pieces
                monsterBase.SetActive(true);
                bMonsterBase.SetActive(true);
                battleZone3.SetActive(true);
                battleZone3Part2.SetActive(true);
                bHumanBase.SetActive(true);
                humanBase.SetActive(false);
                //Buttons
                buttonMBase.SetActive(false);
                button3.SetActive(false);
                button3p2.SetActive(false);
                buttonHBase.SetActive(true);
                //Spawn Zones
                HumanSpawner.monsterBaseZone = false;
                HumanSpawner.battleZone3 = false;
                HumanSpawner.battleZone3Part2 = false;
                HumanSpawner.humanBaseZone = true;
            }
        }
        if (humanBaseActive)
        {
            //Map Pieces
            humanBase.SetActive(false);
            //Buttons
            buttonHBase.SetActive(true);
            //Spawn Zones
            HumanSpawner.humanBaseZone = true;
        }
        if (monsterBaseActive)
        {
            //Map Pieces
            monsterBase.SetActive(true);
            //Buttons
            buttonMBase.SetActive(true);
            //Spawn Zones
            HumanSpawner.monsterBaseZone = true;
        }
    }
}
