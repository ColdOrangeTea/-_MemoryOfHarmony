using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_Info : MonoBehaviour // Item類資料分配、存取 放入Item_n
{
    [Header("傳遞資料的物件")]
    public ItemData itemData;

    [Header("資料 bool")]
    public static bool isClick = false;

    [Header("分配道具資料用")]
    // 99 未分配
    public int itemID = 99;

}
