using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData_ID_03 : CharacterData
{
    public override void InitCharacterData()
    {
        characterID = 3;

        // 雙向紀錄角色在隊伍中的順序
        teamNumber = 3;
        characterName = "Malice";
        maxHp = 999;
        hp = 449;
        maxMp = 999;
        mp = 944;
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
