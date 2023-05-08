using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData_ID_01 : UnitData
{
    /* equipID 陣列的說明:
0: weaponID   1: armorID  2: accessoriesID */
    public int[] equipID = new int[3];

    [Header("傳遞資料的物件")]
    [SerializeField]
    private UnitData characterData;

    // 對應ID的子物件資料
    private CharacterData_Info characterData_Info;

    // 所有空物件中的子物件的陣列
    private CharacterData_Info[] characterData_AllInfo;

    // 父物件(內含具有 CharacterData_Info 組件的子物件) 要手動指定物件
    public GameObject characterData_InfoEmpty;

    // 角色在隊伍中的順序
    public int teamNumber = 0;

    void Update()
    {
        SetTeamNumber();
    }

    //  設定隊伍順序
    void SetTeamNumber()
    {
        // 確認更動隊伍成員的順序
        if (GameMenu_Button_TeamNumber.isTA_Yes)
        {
            // 更改 CharacterData_ID_n 紀錄的數值
            teamNumber = characterData_Info.temporary_TeamNumber;

            // Debug.Log("characterData: " + characterData + "  " + "info: " + info + "  " + "characterData.teamNumber:  " + teamNumber);
            SetUnitData();
        }
    }

    // 傳遞資料給CharacterData_Info
    public override void SetUnitData()
    {
        Debug.Log("角色建立 陣列7人");
        characterData_AllInfo = characterData_InfoEmpty.GetComponentsInChildren<CharacterData_Info>();
        foreach (CharacterData_Info a in characterData_AllInfo)
        {
            CharacterData_Info u = a;
            if (u.GetComponent<CharacterData_Info>())
            {
                // Debug.Log(u.GetComponent<CharacterData_Info>());
                if (u.GetComponent<CharacterData_Info>().teamNumber == teamNumber)
                {
                    if (characterID == 1)
                        characterData = GetComponent<CharacterData_ID_01>();


                    characterData_Info = u.GetComponent<CharacterData_Info>();
                    characterData_Info.characterData = characterData;
                    characterData_Info.teamNumber = teamNumber;

                    characterData_Info.teamMember = new UnitData[7];
                    characterData_Info.teamMember[characterData_Info.teamNumber] = characterData_Info.characterData;
                }
            }
        }
    }

    public override void InitUnitData()
    {
        characterID = 1;

        // 角色在隊伍中的順序
        teamNumber = 1;

        unitName = "Execute";

        /* baseUnitData 陣列的說明:
        0: MaxHp   1: Hp  2: MaxMp   3: Mp   4: Attack  5: Defence    6: Speed */
        baseUnitData = new int[] {
            200,100,200,100,
            999,999,60};

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
