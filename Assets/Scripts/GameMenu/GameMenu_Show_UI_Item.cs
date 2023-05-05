using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Show_UI_Item : MonoBehaviour // 遊戲選單中的ItemData顯示控制，要手動把程式掛在 Item_n
{
    [Header("保存道具資訊的資料")]


    public ItemData_Info itemData_Info;
    [Header("資料 bool")]

    // 用來確認在編排時按過的按鈕，避免按過的按鈕能再按
    public bool isClick = false;

    [Header("資料 string")]
    private string item_Description;

    [Header("UI物件 GameObject")]
    // public GameObject itemContent;
    public GameObject item_Layer_00;
    public GameObject item_Layer_01;
    public GameObject item_Button;
    public GameObject item_Button_ItemLabel;
    public GameObject item_Button_Use_00;
    public GameObject item_Button_Use_01;

    [Header("UI物件 Text")]

    // 用來存取顯示在UI版面，可點選的 所有 物件資料
    public Text item_Name_Text;
    public Text item_NumberOfItems_Text;
    public Text item_Description_Text;
    public Text item_Button_Use_Text;
    void Start()
    {
        InitItemData_Object();
        GetItemInfo();

    }
    // Awake 先於Start啟動 
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetItemNumber();
        isClicked();
    }

    // 所有物件的Update都執行過 LateUpdate 才會執行
    void LateUpdate()
    {
        // if (GameMenu_Button_TeamNumber.isTA_Yes == true)
        //     GameMenu_Button_TeamNumber.isTA_Yes = false;

        // if (GameMenu_Button_TeamNumber.isTA_No == true)
        //     GameMenu_Button_TeamNumber.isTA_No = false;
    }

    // 顯示使用道具的版面和文字 用在 isClicked()
    void ShowItem_Layer_00()
    {
        item_Button_Use_00.SetActive(true);
        item_Button_Use_Text.text = GameMenu_Button_Item.item_Use.itemName;
    }

    // 顯示物品敘述 用在 isClicked()
    void Item_description_ButtonControl()
    {
        item_Description = GameMenu_Button_Item.item_Use.itemDescription;
        Debug.Log("物品敘述 item_Description: " + item_Description + " " + "GameMenu_Button_Item.item_Use.itemDescription: " + GameMenu_Button_Item.item_Use.itemDescription);
        item_Description_Text.text = item_Description;
    }

    // 點擊任一道具時
    private void isClicked()
    {
        if (GameMenu_Button_Item.isClick == false) return;
        Item_description_ButtonControl();
        ShowItem_Layer_00();
        GameMenu_Button_Item.isClick = false;
    }

    // 目前道具有多少，就在選單顯示多少道具版面
    void Button_ItemControl()
    {

    }

    //  設定道具順序
    void SetItemNumber()
    {

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

        item_Layer_00 = this.gameObject.transform.parent.parent.parent.parent.parent.GetChild(0).gameObject;
        item_Layer_01 = this.gameObject.transform.parent.parent.parent.parent.gameObject;
        item_Button = this.gameObject.transform.parent.parent.parent.parent.parent.GetChild(2).gameObject;
        item_Button_ItemLabel = item_Button.transform.GetChild(0).gameObject;
        item_Button_Use_00 = item_Button.transform.GetChild(1).gameObject;
        item_Button_Use_01 = item_Button.transform.GetChild(2).gameObject;

        item_Name_Text = this.gameObject.transform.GetChild(0).GetComponent<Text>();
        item_NumberOfItems_Text = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        item_Description_Text = this.gameObject.transform.parent.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponent<Text>();
        item_Button_Use_Text = item_Button_Use_00.transform.GetChild(2).GetChild(0).GetComponent<Text>();
    }

}
