using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Button_Item : MonoBehaviour // 遊戲選單中的按鈕控制，要掛在 Item_Button 
{
    [Header("傳遞資料的物件")]

    // 對應ID的子物件資料
    public ItemData_Info itemData_Info;
    public static ItemData item_Click;

    [Header("資料 bool")]
    public static bool isUsingItem = false;

    // 是否有按道具
    public static bool isClick = false;
    // public static bool isUsingItemEnd = false;


    // 按鈕功能 記錄在UI版面按下的道具資料
    public void GetInfo()
    {
        itemData_Info = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<ItemData_Info>();
        item_Click = itemData_Info.itemData;
    }

    // 按鈕功能 被點擊時紀錄自己(為了使用物品的用途)
    public void isClicked()
    {
        isClick = true;

    }

    // 按鈕功能 被點擊時結束使用物品的功能(為了使用物品的用途)
    public void IU_EndButtonControl()
    {
        Debug.Log(" 確定結束");
        isUsingItem = false;
        // GameMenu.isOpenGameMenu_Item = true;
        GameMenuControl.isOpenGameMenu_Team = false;
        GameMenuControl.isOpenGameMenu_Team_TeamArrangement = true;
    }

    // 按鈕功能 取消使用物品(為了使用物品的用途)
    public void IU_NoButtonControl()
    {
        Debug.Log(" 取消使用物品，並退出隊伍人員選擇介面，回到物品介面");
        isUsingItem = false;

        GameMenuControl.isOpenGameMenu_Team = false;
        GameMenuControl.isOpenGameMenu_Team_TeamArrangement = true;

        Calculation_CharacterData.itemData = null;
    }

    // 按鈕功能 確定要使用物品(為了使用物品的用途)
    public void IU_YesButtonControl()
    {
        Debug.Log(" 確定使用物品");
        isUsingItem = true;

        GameMenuControl.isOpenGameMenu_Team = true;
        GameMenuControl.isOpenGameMenu_Team_TeamArrangement = false;

        Calculation_CharacterData.itemData = item_Click;

    }


}
