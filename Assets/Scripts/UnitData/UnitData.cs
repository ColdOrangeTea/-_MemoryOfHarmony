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
    public int characterID = 999;
    protected internal int enemyID = 999;

    // // 角色在隊伍中的順序
    // public int teamNumber = 999;
    [SerializeField]
    protected internal string unitName = " ";

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

    // [Header("進戰鬥前記錄的數值")]
    // // 進戰鬥前用來記錄的數值
    // public static int currentTeamNumber = 0;
    // public static int[] currentBaseUnitData = new int[7];
    // public static int[] currentTotalUnitData = new int[7];
    // public static int[] currentEquipID = new int[3];

    void Awake()
    {
        Debug.Log("Unit資料建立");
        InitUnitData();
        SetUnitData();
    }

    void Update()
    {
        HpCheck();
        MpCheck();
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


    // 抽象方法建立

    // 傳遞資料給 物件資料_Info
    public abstract void SetUnitData();
    public abstract void InitUnitData();
}
