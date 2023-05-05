using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData_Info : MonoBehaviour // Character類資料分配、存取 放入Button_TeamNumber_n
{
    [Header("保存角色資訊的資料")]

    [Header("分配角色順序用")]

    // 目前隊伍人數的最大值
    public static int numberOfMembers = 7;
    public int teamNumber = 99;

    [Header("單個角色的資訊")]
    [SerializeField]
    protected internal UnitData characterData;

    [Header("分配隊伍順序用")]

    [SerializeField]
    // 分配用的暫存數，紀錄人物ID  99代表未分配
    public UnitData temporary_CharacterData;

    // 分配用的暫存數，紀錄隊伍順序 
    public int temporary_TeamNumber = 99;

}
