using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitData : MonoBehaviour
{

    // ID值 預設999為無效值

    [Header("角色資料")]
    protected internal int characterID = 999;

    // 角色在隊伍中的順序
    public int teamNumber = 999;
    [SerializeField]
    protected internal string characterName = " ";
    [SerializeField]
    protected internal int maxHp = 0;
    [SerializeField]
    protected internal int hp = 0;
    [SerializeField]
    protected internal int maxMp = 0;
    [SerializeField]
    protected internal int mp = 0;
    protected internal int attack = 0;
    protected internal int defence = 0;
    protected internal int speed = 0;
    protected internal int weaponID = 999;
    protected internal int armorID = 999;
    protected internal int accessoriesID = 999;
    [Header("角色資料 加上技能、裝備影響的數值")]
    // 加上技能、裝備影響的數值
    public int totalMaxHp = 0;
    public int totalHp = 0;
    public int totalMaxMp = 0;
    public int totalMp = 0;
    public int totalAttack = 0;
    public int totalDefence = 0;
    public int totalSpeed = 0;

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
    }

    //  設定隊伍順序
    void SetTeamNumber()
    {
        // 確認更動隊伍成員的順序
        if (GameMenu_Button_TeamNumber.isTA_Yes)
        {
            // 更改 CharacterData_ID_n 紀錄的數值
            teamNumber = info.temporary_TeamNumber;
            Debug.Log("characterData: " + characterData + "  " + "info: " + info + "  " + "characterData.teamNumber:  " + teamNumber);
            SetCharacterData();
        }

    }

    private void HpCheck()
    {
        float float_Hp = hp;

        if (hp < 0)
            hp = 0;
        if (hp > maxHp)
            hp = maxHp;
    }

    private void MpCheck()
    {
        float float_Mp = mp;

        if (mp < 0)
            mp = 0;
        if (mp > maxMp)
            mp = maxMp;
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
