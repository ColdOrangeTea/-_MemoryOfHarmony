using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : MonoBehaviour
{
    // ID值 預設999為無效值

    [Header("道具資料")]
    public int itemID = 999;
    public string itemName = " ";
    public string itemDescription = " ";

    // 物品數量
    public int numberOfItems = 99;
    public int price = 0;

    // 確認道具的種類 0:戰鬥可用的道具 1:裝備 2:素材 3:貴重品
    public int sortOfItem = 0;

    // 0代表能在選單、戰鬥中使用 1代表僅能在戰鬥中用 2代表僅能在選單中使用
    public int item_UseInMap = 0;

    /*戰鬥可用的道具的種類: 
    0~10(補)
    00: hp  01: mp  02: HP上限  03: MP上限  
    04: ATK 05: DEF 06: SPEED
    */
    // false為有益(+)  true為有害(-)，所有物品預設為true
    public bool[] isHarmful = new bool[7];

    // 如果這個道具是看 %數 的 rate要改
    public float[] effectRate = new float[7];

    // 影響的數值
    public int[] effectAmount = new int[7];



    [Header("傳遞資料的物件")]

    private ItemData itemData;

    // 對應ID的子物件資料
    public ItemData_Info info;

    // 所有空物件中的子物件的陣列
    public ItemData_Info[] allInfo;

    // 父物件(內含具有 ItemData_Info 組件的子物件) 要手動指定物件
    public GameObject InfoEmpty;

    void Awake()
    {
        Debug.Log("物品資料建立");
        InitItemData();
        SetItemData();
    }

    // 傳遞資料給CharacterData_Info
    private void SetItemData()
    {
        allInfo = InfoEmpty.GetComponentsInChildren<ItemData_Info>();

        foreach (ItemData_Info a in allInfo)
        {
            ItemData_Info u = a;
            if (u.GetComponent<ItemData_Info>())
            {
                if (u.GetComponent<ItemData_Info>().itemID == itemID)
                {
                    if (itemID == 0)
                        itemData = GetComponent<ItemData_ID_00>();
                    if (itemID == 1)
                        itemData = GetComponent<ItemData_ID_01>();
                    if (itemID == 2)
                        itemData = GetComponent<ItemData_ID_02>();

                    info = u.GetComponent<ItemData_Info>();
                    info.itemData = itemData;
                    info.itemID = itemID;
                }
            }
        }
    }

    public abstract void InitItemData();
}
