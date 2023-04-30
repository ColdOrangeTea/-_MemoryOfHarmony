using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_ID_00 : MonoBehaviour
{

    public int itemID = 0;
    public string itemName = "基礎回復藥";
    public string itemDescription = "藥劑學徒的試作品，回復我方單體HP80點。";

    // 種類 00: 治療類道具  01: 攻擊類道具  02:武器  03:防具  04:裝飾品  05:素材  06:貴重品
    public int sortOfItem = 0;
    // 物品數量
    public int numberOfItems = 99;
    public int price = 300;

    // 如果這個道具是看 %數 的 rate值要改
    public float rate = 1;

    // 00:HEAL or DAMAGE  (以下是數值短暫上升) 01:ATK 02:DEF 03:SPEED 04:HP 05:MP
    public int effectAmount_00 = 80;
    public int effectAmount_01 = 0;
    public int effectAmount_02 = 0;

    // public int itemID_ID_00 = 0;
    // public string itemName_ID_00 = "基礎回復藥";
    // public string itemDescription_ID_00 = "藥劑學徒的試作品，回復我方單體HP80點。";

    // // 種類 00: 治療類道具  01: 攻擊類道具  02:武器  03:防具  04:裝飾品  05:素材  06:貴重品
    // public int sortOfItem_ID_00 = 0;
    // // 物品數量
    // public int numberOfItems_ID_00 = 99;
    // public int price_ID_00 = 300;

    // // 如果這個道具是看 %數 的 rate要改
    // public float rate_ID_00 = 1;

    // // 00:HEAL or DAMAGE  (以下是數值短暫上升) 01:ATK 02:DEF 03:SPEED 04:HP 05:MP
    // public int effectAmount_00_ID_00 = 0;
    // public int effectAmount_01_ID_00 = 0;
    // public int effectAmount_02_ID_00 = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        InitItemData_ID_00();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitItemData_ID_00()
    {
        GameMenu_ItemControl.itemData.Add(new ItemData()
        {
            itemID = itemID,
            itemName = itemName,
            itemDescription = itemDescription,
            sortOfItem = sortOfItem,
            numberOfItems = numberOfItems,
            price = price,
            rate = rate,
            effectAmount_00 = effectAmount_00,
            effectAmount_01 = effectAmount_01,
            effectAmount_02 = effectAmount_02,
        });
    }

}
