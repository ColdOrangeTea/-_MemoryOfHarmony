using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData_Info : MonoBehaviour // Character類資料分配、存取 放入Button_TeamNumber_n
{
    [Header("傳遞資料的物件")]
    [SerializeField]
    protected internal UnitData characterData;
    public GameMenu_Show_UI_TeamNumber show_UI_TeamNumber;

    // 所有角色的 UnitData型別資料儲存成一個陣列，元素n = teamNumber(隊伍順序)
    public UnitData[] teamMember;

    [Header("資料 bool")]
    // 標記被按的按鈕
    public bool isClick = false;

    [Header("分配角色資料用")]

    // 目前隊伍人數的最大值
    public static int numberOfMembers = 7;
    //隊伍中的順序
    public int teamNumber = 99;

    [Header("分配隊伍順序用")]

    [SerializeField]
    // 分配用的暫存數，紀錄人物ID  99代表未分配
    public UnitData temporary_CharacterData;

    // 分配用的暫存數，紀錄隊伍順序 
    public int temporary_TeamNumber = 99;

    void Start()
    {
        show_UI_TeamNumber = GetComponent<GameMenu_Show_UI_TeamNumber>();
    }

}


