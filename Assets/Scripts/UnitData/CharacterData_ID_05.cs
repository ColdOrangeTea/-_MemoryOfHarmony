using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData_ID_05 : UnitData
{
    public override void InitCharacterData()
    {
        characterID = 5;

        // 雙向紀錄角色在隊伍中的順序
        teamNumber = 5;
        characterName = "Refectio";
        maxHp = 666;
        hp = 111;
        maxMp = 980;
        mp = 880;
        attack = 999;
        defence = 999;
        speed = 999;
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
