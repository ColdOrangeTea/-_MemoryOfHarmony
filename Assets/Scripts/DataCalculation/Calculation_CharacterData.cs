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
        UseItemCalculation();
    }

    void UseItemCalculation()
    {
        if (unitData == null) return;
        if (GameMenu_Button_Item.isUsingItem)
        {
            Debug.Log("使用道具 unitData:" + unitData + " itemData: " + itemData);
            if (itemData.isHarmful[0] == false)
            {
                if (unitData.baseUnitData[1] == unitData.baseUnitData[0])
                {
                    Debug.Log(unitData.characterName + "HP滿的，無法使用物品");
                    unitData = null;
                    return;
                }
                unitData.baseUnitData[1] += itemData.effectAmount[0];
                itemData.numberOfItems -= 1;
            }

            if (itemData.isHarmful[1] == false)
            {
                if (unitData.baseUnitData[3] == unitData.baseUnitData[2])
                {
                    Debug.Log(unitData.characterName + "MP滿的，無法使用物品");
                    unitData = null;
                    return;
                }
                unitData.baseUnitData[3] += itemData.effectAmount[1];
                itemData.numberOfItems -= 1;
            }
        }
        unitData = null;
    }
}
