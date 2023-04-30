using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData_ID_04 : MonoBehaviour
{
    public static int characterID = 0;

    // 雙向紀錄角色在隊伍中的順序
    public static int teamNumber = 0;
    public string characterName = "Fortuna";
    public int maxHp = 800;
    public int hp = 600;
    public int maxMp = 700;
    public int mp = 546;
    public int attack = 999;
    public int defence = 999;
    public int speed = 999;
    public int weaponID = 0;
    public int armorID = 0;
    public int accessoriesID = 0;

    // 加上技能、裝備影響的數值
    public int totalMaxHp = 999;
    public int totalHp = 999;
    public int totalMaxMp = 999;
    public int totalMp = 999;
    public int totalAttack = 100;
    public int totalDefence = 100;
    public int totalSpeed = 50;

    void Awake()
    {
        InitCharacterData_ID_04();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void InitCharacterData_ID_04()
    {
        GameMenu_TeamNumberControl.characterData.Add(new CharacterData()
        {
            characterID = characterID,
            // 雙向紀錄角色在隊伍中的順序
            teamNumber = teamNumber,
            characterName = characterName,
            maxHp = maxHp,
            hp = hp,
            maxMp = maxMp,
            mp = mp,
            attack = attack,
            defence = defence,
            speed = speed,
            weaponID = weaponID,
            armorID = armorID,
            accessoriesID = accessoriesID,

            // 加上技能、裝備影響的數值
            totalMaxHp = totalMaxHp,
            totalHp = totalHp,
            totalMaxMp = totalMaxMp,
            totalMp = totalMp,
            totalAttack = totalAttack,
            totalDefence = totalDefence,
            totalSpeed = totalSpeed,
        });
    }

}
