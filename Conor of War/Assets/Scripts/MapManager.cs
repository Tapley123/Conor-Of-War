using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    private bool startingValues = true;

    public bool humansWonBattle1, humansWonBattle1Part2, humansWonBattle2, humansWonBattle2Part2, humansWonBattle3, humansWonBattle3Part2, humansWonTheGame, humansSavedTheirBase;
    public bool monstersWonBattle1, monstersWonBattle1Part2, monstersWonBattle2, monstersWonBattle2Part2, monstersWonBattle3, monstersWonBattle3Part2, monstersWonTheGame, monstersSavedTheirBase;
    private bool humansCanProgress = true, monsterCanProgress = true, zoneNeutral = true;
    public static int b1Status = 0, b1p2Status = 0, b2Status = 0, b2p2Status = 0, b3Status = 0, b3p2Status = 0, hbStatus = 0, mbstatus = 0;

    //public static bool battle1Neutral, battle1Part2Neutral, battle2Neutral, battle2Part2Neutral, battle3Neutral, battle3Part2Neutral, battleHbaseNeutral, battleMbaseNeutral;

    public GameObject monsterBase, mMonsterBase, bMonsterBase, tMonsterBase;
    public GameObject humanBase, mHumanBase, bHumanBase, tHumanBase;    
    public GameObject battleZone1, battleZone1Part2, battleZone2, battleZone2Part2, battleZone3, battleZone3Part2;

    public GameObject button1, button1p2, button2, button2p2, button3, button3p2, buttonHBase, buttonMBase;

    private bool useBattleZones = true, useBaseZones = true;

    //public static bool monsterBaseOwned = true;
    //public static bool humanBaseOwned = false;
    //public static bool battleZone1Owned = false, battleZone1Part2Owned = false;
    //public static bool battleZone2Owned = false, battleZone2Part2Owned = false;
    //public static bool battleZone3Owned = false, battleZone3Part2Owned = false;

    void Start()
    {
        if (startingValues)
        {
            /////////Buttons///////////
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button1p2.SetActive(false);
            button2p2.SetActive(false);
            button3p2.SetActive(false);
            buttonHBase.SetActive(false);
            buttonMBase.SetActive(false);
            ////////Monster Base////////
            monsterBase.SetActive(true);
            mMonsterBase.SetActive(true);
            tMonsterBase.SetActive(true);
            bMonsterBase.SetActive(true);
            ////////Human Base//////////
            humanBase.SetActive(false);
            mHumanBase.SetActive(false);
            tHumanBase.SetActive(false);
            bHumanBase.SetActive(false);
            /////////Battle Zones/////////
            battleZone1.SetActive(true);
            battleZone1.SetActive(false);
            battleZone1Part2.SetActive(true);
            battleZone1Part2.SetActive(false);
            battleZone2.SetActive(true);
            battleZone2.SetActive(false);
            battleZone2Part2.SetActive(true);
            battleZone2Part2.SetActive(false);
            battleZone3.SetActive(true);
            battleZone3.SetActive(false);
            battleZone3Part2.SetActive(true);
            battleZone3Part2.SetActive(false);
            ////////Neutral Zones////////////
            /*
            battle1Neutral = true;
            battle1Part2Neutral = true;
            battle2Neutral = true;
            battle2Part2Neutral = true;
            battle3Neutral = true;
            battle3Part2Neutral = true;
            battleHbaseNeutral = true;
            battleMbaseNeutral = true;
            */
            /////////who won what battle/////
            humansWonBattle1 = false;
            humansWonBattle2 = false;
            humansWonBattle3 = false;
            humansWonBattle1Part2 = false;
            humansWonBattle2Part2 = false;
            humansWonBattle3Part2 = false;
            humansWonTheGame = false;

            monstersWonBattle1 = false;
            monstersWonBattle2 = false;
            monstersWonBattle3 = false;
            monstersWonBattle1Part2 = false;
            monstersWonBattle2Part2 = false;
            monstersWonBattle3Part2 = false;
            monstersWonTheGame = false;
        }
    }
    

    void Update()
    {
        //calculate if a zone is owned by monsters = 1, humans = 2 or nuetral = 0;
        if(humansCanProgress && monsterCanProgress)
        {
            if (b1Status == 1)
                monstersWonBattle1 = true;
            if (b1p2Status == 1)
                monstersWonBattle1Part2 = true;

            if (b2Status == 1)
                monstersWonBattle2 = true;
            if (b2p2Status == 1)
                monstersWonBattle2Part2 = true;

            if (b3Status == 1)
                monstersWonBattle3 = true;
            if (b3p2Status == 1)
                monstersWonBattle3Part2 = true;

            if (mbstatus == 1)
                monstersSavedTheirBase = true;



            if (b1Status == 2)
                humansWonBattle1 = true;
            if (b1p2Status == 2)
                humansWonBattle1Part2 = true;

            if (b2Status == 2)
                humansWonBattle2 = true;
            if (b2p2Status == 2)
                humansWonBattle2Part2 = true;

            if (b3Status == 2)
                humansWonBattle3 = true;
            if (b3p2Status == 2)
                humansWonBattle3Part2 = true;

            if (hbStatus == 2)
                humansSavedTheirBase = true;
        }

        if (monsterCanProgress)
        {
            /*
            //if monsters won battle 1 and the second part is neutral
            if(monstersWonBattle1)
            {
                buttonMBase.SetActive(false);
                button1.SetActive(false);
            }
            if(monstersWonBattle1 && monstersWonBattle1Part2)
            {
                buttonMBase.SetActive(false);
                button1.SetActive(false);
                button1p2.SetActive(false);
            }

            if (monstersWonBattle1 && b1p2Status == 0)
            {
                button1.SetActive(false);
                button1p2.SetActive(true);
                battleZone1.SetActive(true);
            }
            //if monsters won battle 1 and the second part of battle 1
            if (monstersWonBattle1Part2 && monstersWonBattle1)
            {
                button1p2.SetActive(false);
                tHumanBase.SetActive(true);
                battleZone1Part2.SetActive(true);
                buttonHBase.SetActive(true);
            }
            */
        }

        if (humansCanProgress)
        {
            /*
            if (humansWonBattle1)
            {
                buttonHBase.SetActive(false);
                button1.SetActive(false);
                buttonMBase.SetActive(true);
                tMonsterBase.SetActive(false);
                battleZone1.SetActive(false);
            }
            if (humansWonBattle1 && humansWonBattle1Part2)
            {
                buttonHBase.SetActive(false);
                button1.SetActive(false);
                button1p2.SetActive(false);
            }

            if(humansWonBattle1Part2 && monstersWonBattle1)
            {
                button1p2.SetActive(false);
                battleZone1Part2.SetActive(false);
                button1.SetActive(true);
            }
            */
        }

        if(humansCanProgress && monsterCanProgress)
        {
            //if you are in Battle 1
            if (b1Status == 0 || monstersWonBattle1 && humansWonBattle1Part2 || humansWonBattle1 && monstersSavedTheirBase)
            {
                button1.SetActive(true);
                button1p2.SetActive(false);
                monsterBase.SetActive(true);
                tMonsterBase.SetActive(true);
            }
            //if you are in Battle 1 part 2
            if (monstersWonBattle1)
            {
                button1.SetActive(false);
                button1p2.SetActive(true);
                monsterBase.SetActive(true);
                tMonsterBase.SetActive(true);
                battleZone1.SetActive(true);
            }

            //if you are in the human base
            if (monstersWonBattle1 && monstersWonBattle1Part2)
            {
                button1.SetActive(false);
                buttonHBase.SetActive(true);
                button1p2.SetActive(false);
                monsterBase.SetActive(true);
                tMonsterBase.SetActive(true);
                battleZone1.SetActive(true);
                battleZone1Part2.SetActive(true);
                tHumanBase.SetActive(true);
            }

            //if you are in the monster base
            if(humansWonBattle1)
            {
                button1.SetActive(false);
                buttonMBase.SetActive(false);
            }
        }
        

        /*
        if(useBaseZones)
        {
            if (monsterBaseOwned)
            {
                monsterBase.SetActive(true);
            }
            else
                monsterBase.SetActive(false);


            if(humanBaseOwned)
            {
                humanBase.SetActive(true);
                mHumanBase.SetActive(true);
                tHumanBase.SetActive(true);
                bHumanBase.SetActive(true);
            }
            if (!humanBaseOwned)
                humanBase.SetActive(false);
        }
        
        ///////Change Map for monsters///////
        if(useBattleZones)
        {
            if (battleZone1Owned)
            {
                battleZone1.SetActive(true);
                tMonsterBase.SetActive(true);
            }
            else
            {
                battleZone1.SetActive(false);
            }
            //////////////////////Add in if they are at your base that the first battle is not active

            if (battleZone1Part2Owned)
            {
                battleZone1Part2.SetActive(true);
                tHumanBase.SetActive(true);
            }
            else
            {
                battleZone1Part2.SetActive(false);
            }


            if (battleZone2Owned)
            {
                battleZone2.SetActive(true);
                mMonsterBase.SetActive(true);
            }
            else
            {
                battleZone2.SetActive(false);
            }


            if (battleZone2Part2Owned)
            {
                battleZone2Part2.SetActive(true);
                mHumanBase.SetActive(true);
            }
            else
            {
                battleZone2Part2.SetActive(false);
            }


            if (battleZone3Owned)
            {
                battleZone3.SetActive(true);
                bMonsterBase.SetActive(true);
            }
            else
            {
                battleZone3.SetActive(false);
            }


            if (battleZone3Part2Owned)
            {
                battleZone3Part2.SetActive(true);
                bHumanBase.SetActive(true);
            }
            else
            {
                battleZone3Part2.SetActive(false);
            }
        }

        //////Change Map for Humans////////
        if(useBattleZones)
        {
            ////////////////if the humans take the first zone///////////////////
            if (!battleZone1Owned && !battle1Neutral)
            {
                battleZone1.SetActive(false);
                tMonsterBase.SetActive(false);
                button1.SetActive(false);
                buttonMBase.SetActive(true);
            }
            //if the humans take the second part of the first battle
            if(!battleZone1Part2Owned && !battle1Part2Neutral)
            {
                battleZone1Part2.SetActive(false);
                button1p2.SetActive(false);
                button1.SetActive(true);
            }

            
            ////////////////if the humans take the second zone///////////////////
            if (!battleZone2Owned && !battle2Neutral)
            {
                battleZone2.SetActive(false);
                mMonsterBase.SetActive(false);
                button2.SetActive(false);
                buttonMBase.SetActive(true);
            }
            //if the humans take the second part of the second battle
            if (!battleZone2Part2Owned && !battle2Part2Neutral)
            {
                battleZone2Part2.SetActive(false);
                button2p2.SetActive(false);
                button2.SetActive(true);
            }
        }

        //////Change Buttons////
        if(useBattleZones)
        {
            //if you control the first battle point but not the second part
            if(battleZone1Owned && !battleZone1Part2Owned)
            {
                button1.SetActive(false);
                button1p2.SetActive(true);
            }
            //if you control the second part of the first battle point
            if(battleZone1Part2Owned && !humanBaseOwned)
            {
                button1p2.SetActive(false);
                buttonHBase.SetActive(true);
            }


            //if you control the second battle point but not the second part
            if (battleZone2Owned && !battleZone2Part2Owned)
            {
                button2.SetActive(false);
                button2p2.SetActive(true);
            }
            //if you control the second part of the second battle point
            if (battleZone2Part2Owned && !humanBaseOwned)
            {
                button2p2.SetActive(false);
                buttonHBase.SetActive(true);
            }


            //if you control the third battle point but not the second part
            if (battleZone3Owned && !battleZone3Part2Owned)
            {
                button3.SetActive(false);
                button3p2.SetActive(true);
            }
            //if you control the second part of the third battle point
            if (battleZone3Part2Owned && !humanBaseOwned)
            {
                button3p2.SetActive(false);
                buttonHBase.SetActive(true);
            }
        }

        /////neutral zones/////
        if(useBattleZones)
        {
            if(battle1Neutral && !battleZone1Owned)
            {
                button1.SetActive(true);
            }
            if(battleZone1Part2Owned && !battleZone1Part2Owned)
            {
                button1p2.SetActive(true);
            }


            if(battle2Neutral && !battleZone2Owned)
            {
                button2.SetActive(true);
            }
            if (battleZone2Part2Owned && !battleZone2Part2Owned)
            {
                button2p2.SetActive(true);
            }


            if (battle3Neutral && !battleZone3Owned)
            {
                button3.SetActive(true);
            }
            if (battleZone3Part2Owned && !battleZone3Part2Owned)
            {
                button3p2.SetActive(true);
            }

            /*
            if(battleMbaseNeutral && !monsterBaseOwned)
            {
                buttonMBase.SetActive(true);
            }
            if(battleHbaseNeutral && !humanBaseOwned)
            {
                buttonHBase.SetActive(true);
            }
            
        }
        */
    }
}
