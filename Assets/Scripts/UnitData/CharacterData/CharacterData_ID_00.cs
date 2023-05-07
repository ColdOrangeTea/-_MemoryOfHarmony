using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData_ID_00 : UnitData
{
    public override void InitCharacterData()
    {
        characterID = 0;

        // 雙向紀錄角色在隊伍中的順序
        teamNumber = 0;
        characterName = "Dominate";

        /* baseUnitData 陣列的說明:
        0: MaxHp   1: Hp  2: MaxMp   3: Mp   4: Attack  5: Defence    6: Speed */
        baseUnitData = new int[] {
            100,50,100,50,
            10,10,50};

        /* equipID 陣列的說明:  
        0: weaponID   1: armorID  2: accessoriesID */
        equipID = new int[] { 99, 99, 99 };

        /* totalUnitData 陣列的說明:    
        0: totalMaxHp   1: totalHp  2: totalMaxMp   3: totalMp
        4: totalAttack  5: totalDefence    6: totalSpeed */

        totalUnitData = new int[] {
        baseUnitData[0],baseUnitData[1],baseUnitData[2],baseUnitData[3],
        baseUnitData[4],baseUnitData[5],baseUnitData[6]};
    }
}
