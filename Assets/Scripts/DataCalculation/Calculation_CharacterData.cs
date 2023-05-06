using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculation_CharacterData : MonoBehaviour
{
    [Header("傳遞資料的物件")]

    // 設靜態 抓取要用的物品的資訊
    public static ItemData itemData;

    // 設靜態 抓取要使用的對象
    public static UnitData unitData;

    void Update()
    {
        calculation();
    }

    void calculation()
    {
        if (unitData == null) return;
        if (GameMenu_Button_Item.isUsingItem)
        {
            Debug.Log("使用道具 unitData:" + unitData + " itemData: " + itemData);
            if (!itemData.isHarmful_Hp)
            {
                if (unitData.hp == unitData.maxHp)
                {
                    Debug.Log("HP滿的，無法使用物品");
                    return;
                }
                unitData.hp += itemData.effectAmount_00;
            }

            if (!itemData.isHarmful_Mp)
            {
                if (unitData.hp == unitData.maxHp)
                {
                    Debug.Log("HP滿的，無法使用物品");
                    return;
                }
                unitData.hp += itemData.effectAmount_01;
            }
        }

        unitData = null;
    }
}
