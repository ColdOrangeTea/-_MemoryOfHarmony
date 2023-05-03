using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_ID_01 : ItemData
{
    public override void InitItemData()
    {
        itemID = 1;
        itemName = "基礎靈藥";
        itemDescription = "泡入靈木樹葉的基礎回復藥，據說有讓人身心放鬆的功效。回復我方單體MP30點。";

        sortOfItem = 0;
        // 物品數量
        numberOfItems = 99;
        price = 300;

        item_UseInMap = 0;

        /*戰鬥可用的道具的種類: 
        0~10
        00: hp  01: mp  02: HP上限  03: MP上限  
        04: ATK 05: DEF 06: SPEED
        */
        // false為有益(+)  true為有害(-)
        isHarmful_Hp = true;
        isHarmful_Mp = false;
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
        effectAmount_00 = 0;
        effectAmount_01 = 30;
        effectAmount_02 = 0;
        effectAmount_03 = 0;
        effectAmount_04 = 0;
        effectAmount_05 = 0;
        effectAmount_06 = 0;

        // isInit = true;

    }
}
