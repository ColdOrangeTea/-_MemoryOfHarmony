using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData
{
    public int itemID = 99;
    public string itemName = " ";
    public string itemDescription = " ";

    // 種類 00: 治療類道具  01: 攻擊類道具  02:武器  03:防具  04:裝飾品  05:素材  06:貴重品
    public int sortOfItem = 0;
    // 物品數量
    public int numberOfItems = 99;

    public int price = 0;

    // 如果這個道具是看 %數 的 rate要改
    public float rate = 1.0f;

    // 00:HEAL or DAMAGE 01:ATK 02:DEF 03:SPEED 04:HP 05:MP
    public int effectAmount_00 = 0;
    public int effectAmount_01 = 0;
    public int effectAmount_02 = 0;
}

public class GameMenu_ItemControl : MonoBehaviour
{
    public static List<ItemData> itemData = new List<ItemData>();

    [Header("保存道具資訊的資料")]
    public GameObject itemDataControl;

    [Header("分配道具順序用")]
    // 物品總數目
    public int itemNumber = 99;

    // 99 未分配
    public int itemID = 99;

    [Header("單個道具的資訊")]
    public string itemName = " ";
    public string itemDescription = " ";

    [Header("種類" +
    "\n00: 治療類道具  01: 攻擊類道具  02:武器  " +
    "\n03:防具  04:裝飾品  05:素材  06:貴重品")]
    // 種類 00: 治療類道具  01: 攻擊類道具  02:武器  03:防具  04:裝飾品  05:素材  06:貴重品
    public int sortOfItem = 0;
    // 物品數量
    public int numberOfItems = 99;

    public int price = 0;

    // 如果這個道具是看 %數 的 rate要改
    public float rate = 1.0f;

    // 00:HEAL or DAMAGE 01:ATK 02:DEF 03:SPEED 04:HP 05:MP
    public int effectAmount_00 = 0;
    public int effectAmount_01 = 0;
    public int effectAmount_02 = 0;

    [Header("UI物件")]
    // 用迴圈找掛著這個程式的自己  
    public GameObject item;
    public GameObject item_Content;
    // [SerializeField]
    // private ColorBlock cb;
    public Button button_item;
    public Text item_Name_Text;
    public Text item_numberOfItems_Text;
    public Image item_Image;
    public Text item_description_Text;
    public Text item_Button_Use_Text;

    // 一次點一個
    [Header("點到的道具資料")]
    public static bool isClick = false;
    public static int itemID_Use = 99;

    // Start is called before the first frame update
    void Start()
    {
        SetItemInfo();
        GetTeamNumberInfo();
    }
    void Awake()
    {
        Debug.Log(" 物品");
        InitItemData_Object();
        InitItemData();
    }

    // Update is called once per frame
    void Update()
    {
        // SetItemInfo();
    }

    // 按下物品
    public void Item_ButtonControl()
    {
        Debug.Log("物品按鈕");
        item_description_Text.text = itemDescription;
        itemID_Use = itemID;
        // 更新物品的資料
        GetTeamNumberInfo();
    }

    // 取得會顯示在UI上的角色資訊
    private void GetTeamNumberInfo()
    {
        // 顯示使用的道具
        Debug.Log("用的道具、ID:" + itemName + itemID);
        item_Button_Use_Text.text = itemData[itemID].itemName;

        Debug.Log(" 取得會顯示在UI上的角色資訊");
        item_Name_Text.text = itemName;
        item_numberOfItems_Text.text = numberOfItems.ToString();

    }
    // 設定會顯示在UI上的道具資訊 用ID分配顯示在UI上的資料  
    private void SetItemInfo()
    {
        // 迴圈最大值到物件ID的總數
        for (int i = 0; i < 3; i++)
        {
            if (itemID == i)
            {
                itemName = itemData[i].itemName;
                itemDescription = itemData[i].itemDescription;

                // 種類 00: 治療類道具  01: 攻擊類道具  02:武器  03:防具  04:裝飾品  05:素材  06:貴重品
                sortOfItem = itemData[i].sortOfItem;
                // 物品數量
                numberOfItems = itemData[i].numberOfItems;
                price = itemData[i].price;
                rate = itemData[i].rate;

                // 00:HEAL or DAMAGE 01:ATK 02:DEF 03:SPEED 04:HP 05:MP
                effectAmount_00 = itemData[i].effectAmount_00;
                effectAmount_01 = itemData[i].effectAmount_01;
                effectAmount_02 = itemData[i].effectAmount_02;
            }
        }
    }

    // private void Button_ColorSetting()
    // {
    //     cb = new ColorBlock();

    //     cb.normalColor = new Color(255.0f, 255.0f, 255.0f, 255.0f);
    //     cb.highlightedColor = new Color(255.0f, 255.0f, 255.0f, 255.0f);
    //     cb.pressedColor = new Color(255.0f, 151.0f, 0.0f, 123.0f);
    //     cb.selectedColor = new Color(255.0f, 255.0f, 255.0f, 255.0f);
    //     cb.disabledColor = new Color(200.0f, 200.0f, 200.0f, 128.0f);

    //     cb.colorMultiplier = 1;
    //     cb.fadeDuration = 0.1f;
    //     button_item.colors = cb;
    // }

    // Awake啟動(即使物件Active =false 也要先取得)
    private void InitItemData_Object()
    {
        item_Name_Text = this.gameObject.transform.GetChild(0).GetComponent<Text>();
        item_numberOfItems_Text = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        item_Image = this.gameObject.transform.GetChild(2).GetComponent<Image>();
        item_description_Text = gameObject.transform.parent.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponent<Text>();
        item_Button_Use_Text = this.gameObject.transform.parent.parent.parent.parent.parent.GetChild(2).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>();

        item = this.gameObject;
        item_Content = this.gameObject.transform.parent.gameObject;
        button_item = this.gameObject.GetComponent<Button>();

    }

    private void InitItemData()
    {
        // 迴圈最大值到物件ID的總數
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("物品ID");
            if (item_Content.GetComponentInChildren<GameMenu_ItemControl>().itemID == i)
            {
                Debug.Log("物品ID 重複: " + itemID);
                return;
            }
            else
            {
                if (item.name == "Item_" + i.ToString())
                {
                    Debug.Log("物品ID 加入: " + itemID);
                    item.GetComponent<GameMenu_ItemControl>().itemID = i;
                }
            }


        }
    }
}
