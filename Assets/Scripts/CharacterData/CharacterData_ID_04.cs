using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData_ID_04 : CharacterData
{
    public override void InitCharacterData()
    {
        characterID = 4;

        // 雙向紀錄角色在隊伍中的順序
        teamNumber = 4;
        characterName = "Fortuna";
        maxHp = 800;
        hp = 600;
        maxMp = 700;
        mp = 546;
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
