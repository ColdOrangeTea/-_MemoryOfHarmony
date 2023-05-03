using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_ID_02 : ItemData
{
    public override void InitItemData()
    {
        itemID = 2;
        itemName = "回復藥";
        itemDescription = "市場上常見的回復藥，回復我方單體HP150點。";

        sortOfItem = 0;
        // 物品數量
        numberOfItems = 99;
        price = 600;

        item_UseInMap = 0;

        /*戰鬥可用的道具的種類: 
        0~10
        00: hp  01: mp  02: HP上限  03: MP上限  
        04: ATK 05: DEF 06: SPEED
        */
        // false為有益(+)  true為有害(-)
        isHarmful_Hp = false;
        isHarmful_Mp = true;
        isHarmful_MaxHp = true;
        isHarmful_MaxMp = true;
        isHarmful_MAXATK = true;
        isHarmful_MaxDEF = true;
        isHarmful_MaxSPEED = true;

        // 如果這個道具是看 %數 的 rate值要改
        effectRate_00 = 1.0f;
        effectRate_01 = 1.0f;
        effectRate_02 = 1.0f;
        effectRate_03 = 1.0f;
        effectRate_04 = 1.0f;
        effectRate_05 = 1.0f;
        effectRate_06 = 1.0f;

        // 影響的數值
        effectAmount_00 = 150;
        effectAmount_01 = 0;
        effectAmount_02 = 0;
        effectAmount_03 = 0;
        effectAmount_04 = 0;
        effectAmount_05 = 0;
        effectAmount_06 = 0;

        // isInit = true;
    }
}
