using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData_Info : MonoBehaviour // Character類資料分配、存取 放入Button_TeamNumber_n
{
    [Header("傳遞資料的物件")]
    [SerializeField]
    protected internal UnitData enemyData;

    // 所有角色的 UnitData型別資料儲存成一個陣列，元素n = teamNumber(隊伍順序)
    public UnitData[] enemyMember;

    [Header("資料 bool")]
    // 標記被按的按鈕
    public bool isClick = false;

    [Header("資料 int")]

    public int enemyID = 999;

    void Start()
    {

    }

}


