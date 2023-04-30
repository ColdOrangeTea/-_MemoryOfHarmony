using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_ID_01 : MonoBehaviour
{

    public int itemID = 0;
    public string itemName = "基礎靈藥";
    public string itemDescription = "泡入靈木樹葉的基礎回復藥，據說有讓人身心放鬆的功效。回復我方單體MP30點。";

    // 種類 00: 治療類道具  01: 攻擊類道具  02:武器  03:防具  04:裝飾品  05:素材  06:貴重品
    public int sortOfItem = 0;
    // 物品數量
    public int numberOfItems = 99;
    public int price = 300;

    // 如果這個道具是看 %數 的 rate值要改
    public float rate = 1;

    // 00:HEAL or DAMAGE  (以下是數值短暫上升) 01:ATK 02:DEF 03:SPEED 04:HP 05:MP
    public int effectAmount_00 = 30;
    public int effectAmount_01 = 0;
    public int effectAmount_02 = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        InitItemData_ID_01();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitItemData_ID_01()
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
