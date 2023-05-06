using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_UI_Item_OnOff : MonoBehaviour // 遊戲選單中的ItemData顯示控制，要手動把程式掛在 Item_n
{
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
    public Text item_Button_Use_numberOfItems_Text;

    void Start()
    {
        InitItemData_Object();
    }

    void Update()
    {
        UI_Onoff();
        isClicked();
        UseItem();
    }

    void UseItem()
    {
        if (GameMenu_Button_Item.isUsingItem)
            GetItem_NumberOfItems();
    }

    void UI_Onoff()
    {
        ShowItem_Button_Use_01();
        ShowItem_Layer_00();
        ShowItem_Layer_01();
        ShowItem_Button_ItemLabel();
        ShowItem_Button_Use_00();
    }

    void ShowItem_Button_Use_01()
    {
        if (GameMenu_Button_Item.isUsingItem == true)
        {
            item_Button_Use_01.SetActive(true);
        }
        else
        {
            if (item_Button_Use_01.activeInHierarchy == true)
                item_Button_Use_01.SetActive(false);
        }

    }

    void ShowItem_Layer_00()
    {
        if (GameMenu_Button_Item.isUsingItem == true)
        {
            item_Layer_00.SetActive(false);
        }
        else
        {
            if (item_Layer_00.activeInHierarchy == false)
                item_Layer_00.SetActive(true);
        }
    }

    void ShowItem_Layer_01()
    {
        if (GameMenu_Button_Item.isUsingItem == true)
        {
            item_Layer_01.SetActive(false);
        }
        else
        {
            if (item_Layer_01.activeInHierarchy == false)
                item_Layer_01.SetActive(true);
        }
    }

    void ShowItem_Button_ItemLabel()
    {
        if (GameMenu_Button_Item.isUsingItem == true)
        {
            item_Button_ItemLabel.SetActive(false);
        }
        else
        {
            if (item_Button_ItemLabel.activeInHierarchy == false)
                item_Button_ItemLabel.SetActive(true);
        }
    }

    // 顯示使用道具的版面和文字 用在 isClicked()
    void ShowItem_Button_Use_00()
    {
        if (GameMenu_Button_Item.isUsingItem == true)
        {
            item_Button_Use_00.SetActive(false);
            return;
        }
        else
        {
            if (GameMenu_Button_Item.isClick == false) return;
            item_Button_Use_00.SetActive(true);
            item_Button_Use_Text.text = GameMenu_Button_Item.item_Click.itemName;
        }

    }

    // 顯示物品敘述 用在 UseItem()
    void GetItem_NumberOfItems()
    {
        item_Button_Use_numberOfItems_Text.text = "  道具數量:" + GameMenu_Button_Item.item_Click.numberOfItems.ToString();
        Debug.Log("物品數量: " + item_Button_Use_numberOfItems_Text.text);
    }

    // 顯示物品敘述 用在 isClicked()
    void GetItem_description()
    {

        item_Description_Text.text = GameMenu_Button_Item.item_Click.itemDescription;
        Debug.Log("物品敘述: " + item_Description_Text.text);
    }

    // 顯示物品名稱 用在 isClicked()
    void GetItem_Name()
    {
        item_Button_Use_Text.text = GameMenu_Button_Item.item_Click.itemName;
        Debug.Log("物品名稱: " + item_Button_Use_Text.text);
    }

    // 點擊任一道具時
    private void isClicked()
    {
        if (GameMenu_Button_Item.isClick == false) return;
        GetItem_description();
        GetItem_Name();
        ShowItem_Button_Use_00();
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

    private void InitItemData_Object()
    {
        item_Layer_00 = transform.parent.GetChild(0).gameObject;
        item_Layer_01 = transform.parent.GetChild(1).gameObject;
        item_Button = this.gameObject.transform.parent.GetChild(2).gameObject;
        item_Button_ItemLabel = item_Button.transform.GetChild(0).gameObject;
        item_Button_Use_00 = item_Button.transform.GetChild(1).gameObject;
        item_Button_Use_01 = item_Button.transform.GetChild(2).gameObject;

        item_Description_Text = transform.parent.GetChild(0).GetChild(0).GetComponent<Text>();
        item_Button_Use_Text = item_Button_Use_00.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        item_Button_Use_numberOfItems_Text = item_Button_Use_01.transform.GetChild(1).GetChild(0).GetComponent<Text>();
    }

}
