using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_ID_00 : ItemData
{
    public override void InitItemData()
    {
        itemID = 0;
        itemName = "基礎回復藥";
        itemDescription = "藥劑學徒的試作品，回復我方單體HP80點。";

        // 物品數量
        numberOfItems = 99;
        price = 300;

        // 確認道具的種類 0:戰鬥可用的道具 1:裝備 2:素材 3:貴重品
        sortOfItem = 0;

        // 0代表能在選單、戰鬥中使用 1代表僅能在戰鬥中用 2代表僅能在選單中使用
        item_UseInMap = 0;

        /*戰鬥可用的道具的種類: 0~10(補)
        00:hp  01:mp  02:HP上限  03:MP上限  04:ATK  05:DEF  06:SPEED  */
        // false為有益(+)  true為有害(-)，所有物品預設為true
        isHarmful = new bool[7] { false, true, true, true, true, true, true };

        // 如果這個道具是看 %數 的 rate要改
        effectRate = new float[7] { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };

        // 影響的數值
        effectAmount = new int[7] { 80, 0, 0, 0, 0, 0, 0 };

    }
}
