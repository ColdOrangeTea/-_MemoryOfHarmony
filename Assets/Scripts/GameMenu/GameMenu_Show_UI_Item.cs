using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Show_UI_Item : MonoBehaviour // 遊戲選單中的ItemData顯示控制，要手動把程式掛在 Item_n
{
    [Header("保存道具資訊的資料")]
    public ItemData_Info itemData_Info;

    [Header("資料 string")]
    private string item_Description;

    [Header("UI物件 Text")] // 用來存取顯示在UI版面，可點選的物件資料
    private Text item_Name_Text;
    public Text item_NumberOfItems_Text;
    void Start()
    {
        InitItemData_Object();
        GetItemInfo();

    }

    // 取得會顯示在UI上的道具資訊 只取遊戲選單會用到的資料就好 用ID分配顯示在UI上的資料 
    private void GetItemInfo()
    {
        // 顯示使用的道具
        // Debug.Log(" 取得會顯示在UI上的角色資訊");
        item_Name_Text.text = itemData_Info.itemData.itemName;
        item_NumberOfItems_Text.text = itemData_Info.itemData.numberOfItems.ToString();
    }

    private void InitItemData_Object()
    {
        itemData_Info = GetComponent<ItemData_Info>();
        item_Name_Text = this.gameObject.transform.GetChild(0).GetComponent<Text>();
        item_NumberOfItems_Text = this.gameObject.transform.GetChild(1).GetComponent<Text>();
    }

}
