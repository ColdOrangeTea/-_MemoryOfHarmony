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
        maxHp = 100;
        hp = 50;
        maxMp = 100;
        mp = 80;
        attack = 100;
        defence = 100;
        speed = 50;
        weaponID = 0;
        armorID = 0;
        accessoriesID = 0;

        // 加上技能、裝備影響的數值
        totalMaxHp = 999;
        totalHp = 999;
        totalMaxMp = 999;
        totalMp = 999;
        totalAttack = 100;
        totalDefence = 100;
        totalSpeed = 50;

    }


}
