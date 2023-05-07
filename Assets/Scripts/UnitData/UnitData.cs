using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitData : MonoBehaviour
{

    const int BASE_UNIT_DATA_MAX_HP = 0;
    const int BASE_UNIT_DATA_HP = 1;
    const int BASE_UNIT_DATA_MAX_MP = 2;
    const int BASE_UNIT_DATA_MP = 3;
    const int BASE_UNIT_DATA_ATTACK = 4;
    const int BASE_UNIT_DATA_DEFENCE = 5;
    const int BASE_UNIT_DATA_SPEED = 6;

    // ID值 預設999為無效值

    [Header("角色資料")]
    protected internal int characterID = 999;

    // 角色在隊伍中的順序
    public int teamNumber = 999;
    [SerializeField]
    protected internal string characterName = " ";

    /* equipID 陣列的說明:
    0: weaponID   1: armorID  2: accessoriesID */
    public int[] equipID = new int[3];

    /* baseUnitData 陣列的說明:
    0: MaxHp   1: Hp  2: MaxMp   3: Mp
    4: Attack  5: Defence    6: Speed */
    [Header("角色資料 原數值")]
    public int[] baseUnitData = new int[7];

    /* totalUnitData 陣列的說明:
    0: totalMaxHp   1: totalHp  2: totalMaxMp   3: totalMp
    4: totalAttack  5: totalDefence    6: totalSpeed */
    [Header("角色資料 加上技能、裝備影響的數值")]
    public int[] totalUnitData = new int[7];

    [Header("進戰鬥前記錄的數值")]
    // 進戰鬥前用來記錄的數值
    public static int currentTeamNumber = 0;
    public static int[] currentBaseUnitData = new int[7];
    public static int[] currentTotalUnitData = new int[7];
    public static int[] currentEquipID = new int[3];
    public bool isRecord = false;

    [Header("傳遞資料的物件")]


    [SerializeField]
    private UnitData characterData;

    // 對應ID的子物件資料
    public CharacterData_Info info;

    // 所有空物件中的子物件的陣列
    public CharacterData_Info[] allInfo;

    // 父物件(內含具有 CharacterData_Info 組件的子物件) 要手動指定物件
    public GameObject InfoEmpty;

    void Awake()
    {
        Debug.Log("角色資料建立");
        InitCharacterData();
        SetCharacterData();
    }

    void Update()
    {
        HpCheck();
        MpCheck();
        SetTeamNumber();
        // RecordCurrentData();
    }


    // // 記錄進戰鬥前的數值
    // private void RecordCurrentData()
    // {
    //     if (Enemy_Encounter.isEncounterEnemy == false) return;
    //     // Debug.Log("狀態isEncounterEnemy: " + Enemy_Encounter.isEncounterEnemy);
    //     // Debug.Log("戰鬥前紀錄了沒" + characterName + baseUnitData[1]);

    //     currentTeamNumber = teamNumber;
    //     currentBaseUnitData = baseUnitData;
    //     currentTotalUnitData = totalUnitData;
    //     currentEquipID = equipID;

    //     isRecord = true;
    //     foreach (CharacterData_Info a in allInfo)
    //     {
    //         if (a.characterData.isRecord == false) return;
    //     }

    //     if (isRecord == false) return;

    //     foreach (CharacterData_Info a in allInfo)
    //     {
    //         if (a.characterData.isRecord == true)
    //             a.characterData.isRecord = false;
    //     }
    //     Enemy_Encounter.isEncounterEnemy = false;
    // }

    //  設定隊伍順序
    void SetTeamNumber()
    {
        // 確認更動隊伍成員的順序
        if (GameMenu_Button_TeamNumber.isTA_Yes)
        {
            // 更改 CharacterData_ID_n 紀錄的數值
            teamNumber = info.temporary_TeamNumber;

            // Debug.Log("characterData: " + characterData + "  " + "info: " + info + "  " + "characterData.teamNumber:  " + teamNumber);
            SetCharacterData();
        }
    }

    private void HpCheck()
    {
        /* baseUnitData 陣列的說明:  0: MaxHp   1: Hp */
        float float_Hp = baseUnitData[1];

        if (baseUnitData[1] < 0)
            baseUnitData[1] = 0;
        if (baseUnitData[1] > baseUnitData[0])
            baseUnitData[1] = baseUnitData[0];
    }

    private void MpCheck()
    {
        /* baseUnitData 陣列的說明:  2: MaxMp   3: Mp*/
        float float_Mp = baseUnitData[3];

        if (baseUnitData[3] < 0)
            baseUnitData[3] = 0;
        if (baseUnitData[3] > baseUnitData[2])
            baseUnitData[3] = baseUnitData[2];
    }


    // 傳遞資料給CharacterData_Info
    private void SetCharacterData()
    {
        allInfo = InfoEmpty.GetComponentsInChildren<CharacterData_Info>();
        foreach (CharacterData_Info a in allInfo)
        {
            CharacterData_Info u = a;
            if (u.GetComponent<CharacterData_Info>())
            {
                // Debug.Log(u.GetComponent<CharacterData_Info>());
                if (u.GetComponent<CharacterData_Info>().teamNumber == teamNumber)
                {
                    if (characterID == 0)
                        characterData = GetComponent<CharacterData_ID_00>();
                    if (characterID == 1)
                        characterData = GetComponent<CharacterData_ID_01>();
                    if (characterID == 2)
                        characterData = GetComponent<CharacterData_ID_02>();
                    if (characterID == 3)
                        characterData = GetComponent<CharacterData_ID_03>();
                    if (characterID == 4)
                        characterData = GetComponent<CharacterData_ID_04>();
                    if (characterID == 5)
                        characterData = GetComponent<CharacterData_ID_05>();
                    if (characterID == 6)
                        characterData = GetComponent<CharacterData_ID_06>();

                    info = u.GetComponent<CharacterData_Info>();
                    info.characterData = characterData;
                    info.teamNumber = teamNumber;

                    info.teamMember = new UnitData[7];
                    info.teamMember[info.teamNumber] = info.characterData;
                }
            }
        }
    }
    // 抽象方法建立
    public abstract void InitCharacterData();
}
