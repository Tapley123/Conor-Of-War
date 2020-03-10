using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject monsterBase, mMonsterBase, bMonsterBase, tMonsterBase;
    public GameObject humanBase, mHumanBase, bHumanBase, tHumanBase;    
    public GameObject battleZone1, battleZone1Part2, battleZone2, battleZone2Part2, battleZone3, battleZone3Part2;

    private bool useBattleZones = true, useBaseZones = true;

    public static bool monsterBaseOwned = true;
    public static bool battleZone1Owned = false, battleZone1Part2Owned = false;
    public static bool battleZone2Owned = false, battleZone2Part2Owned = false;
    public static bool battleZone3Owned = false, battleZone3Part2Owned = false;

    void Start()
    {
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
    }
    

    void Update()
    {
        if(useBaseZones)
        {
            if (monsterBaseOwned)
            {
                monsterBase.SetActive(true);
                mMonsterBase.SetActive(true);
                tMonsterBase.SetActive(true);
                bMonsterBase.SetActive(true);
            }
        }
        
        if(useBattleZones)
        {
            if (battleZone1Owned)
            {
                battleZone1.SetActive(true);
            }
            else
            {
                battleZone1.SetActive(false);
            }


            if (battleZone1Part2Owned)
            {
                battleZone1Part2.SetActive(true);
            }
            else
            {
                battleZone1Part2.SetActive(false);
            }


            if (battleZone2Owned)
            {
                battleZone2.SetActive(true);
            }
            else
            {
                battleZone2.SetActive(false);
            }


            if (battleZone2Part2Owned)
            {
                battleZone2Part2.SetActive(true);
            }
            else
            {
                battleZone2Part2.SetActive(false);
            }


            if (battleZone3Owned)
            {
                battleZone3.SetActive(true);
            }
            else
            {
                battleZone3.SetActive(false);
            }


            if (battleZone3Part2Owned)
            {
                battleZone3Part2.SetActive(true);
            }
            else
            {
                battleZone3Part2.SetActive(false);
            }
        }
    }
}
