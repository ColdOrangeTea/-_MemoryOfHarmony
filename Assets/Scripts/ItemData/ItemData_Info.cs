using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_Info : MonoBehaviour // Item類資料分配、存取 放入Item_n
{
    [Header("保存道具資訊的資料")]

    public ItemData itemData;
    public ItemData_Info itemData_Info; // 要手動把自己分配入這個物件

    [Header("資料 bool")]
    public static bool isInitItemData = false;

    // [Header("分配道具數量用")]

    // 身上所有物品總數目
    public int itemNumber = 99;

    // 99 未分配
    public int itemID = 99;

    // 一次點一個
    [Header("轉傳用的資料")]
    public static bool isClick = false;

    // Start is called before the first frame update
    void Start()
    {
        itemData_Info = GetComponent<ItemData_Info>();
    }
    // Awake啟動(即使物件Active =false 也可以先取得)
    void Awake()
    {

    }

}
