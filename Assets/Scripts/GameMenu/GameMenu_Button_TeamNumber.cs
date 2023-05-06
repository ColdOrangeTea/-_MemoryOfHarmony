using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Button_TeamNumber : MonoBehaviour // 遊戲選單中的按鈕控制，程式要掛在 Team_Button
{
    [Header("傳遞資料的物件")]

    // 對應ID的子物件資料
    public CharacterData_Info characterData_Info;
    public GameMenu_Show_UI_TeamNumber show_UI_TeamNumber;

    [Header("資料 bool")]

    // 是否在編排隊伍中
    public static bool isArranging = false;
    // 按下確認編排的按鈕，確定編排
    public static bool isTA_Yes = false;
    // 按下取消編排的按鈕
    public static bool isTA_No = false;

    // ---隊伍編排---

    // 分配隊伍順序時用到的紀錄次數的資料
    public static int orderOfTeamMembers = 0;

    // 在選單對成員使用物品的(按鈕功能)
    public void ItemUse()
    {
        // 在選單使用物品中
        if (GameMenu_Button_Item.isUsingItem)
        {
            // 使用的物品種類是否正確
            if (Calculation_CharacterData.itemData.sortOfItem == 0)
            {
                // 使用的物品是否能在地圖中使用
                if (Calculation_CharacterData.itemData.item_UseInMap != 0)
                {
                    Debug.Log("物品只能在戰鬥中使用");
                }
            }
            else
            {
                Debug.Log("物品種類不對");
            }
        }
    }

    // 按鈕功能 記錄在UI版面按下的隊伍成員資料
    public void GetInfo()
    {
        characterData_Info = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<CharacterData_Info>();
        show_UI_TeamNumber = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<GameMenu_Show_UI_TeamNumber>();
        Calculation_CharacterData.unitData = characterData_Info.characterData;
    }

    // 按鈕功能 被點擊時顯示下自己的順序
    public void isClicked()
    {
        if (isArranging)
        {
            show_UI_TeamNumber.isClick = true;
            if (show_UI_TeamNumber.isClick)
            {
                Debug.Log("亮起來");
                show_UI_TeamNumber.teamNumber_Panel.SetActive(true);
                show_UI_TeamNumber.orderOfTeamMembers = GameMenu_Button_TeamNumber.orderOfTeamMembers.ToString();
                show_UI_TeamNumber.teamNumber_Panel_Text.text = show_UI_TeamNumber.orderOfTeamMembers;
            }
        }
    }

    // 按鈕功能 被點擊時記錄下自己的順序
    public void TeamNumberButton_GetTemporary_TeamNumber()
    {
        if (isArranging)
        {
            if (orderOfTeamMembers == CharacterData_Info.numberOfMembers) return; // 排到目前隊伍上限的順序不能再點
            if (show_UI_TeamNumber.isClick) return; // 編排中點過的不能再點


            // 暫時記錄當下點選的人物的ID
            characterData_Info.temporary_CharacterData = characterData_Info.characterData;

            // 暫時記錄當下的點選的人物的隊伍順序
            characterData_Info.temporary_TeamNumber = orderOfTeamMembers;

            // 記錄次數
            orderOfTeamMembers += 1;
        }
        Debug.Log("暫存順序: " + characterData_Info.temporary_TeamNumber + " 暫存人物資料: " + characterData_Info.temporary_CharacterData + " 目前順序: " +
         characterData_Info.teamNumber + " 目前人物ID: " + characterData_Info.characterData);
    }

    // 按鈕功能 決定開始隊伍編排
    public void TeamArrangementButtonControl()
    {
        Debug.Log("開始編排隊伍順序");
        isArranging = true;
        orderOfTeamMembers = 0;
    }

    // 按鈕功能 確定隊伍編排
    public void TA_YesButtonControl()
    {
        if (isArranging == false) return;
        if (orderOfTeamMembers < CharacterData_Info.numberOfMembers - 1)
        {
            Debug.Log("隊伍順序還沒編排好所有人");
            return;
        }
        Debug.Log("隊伍順序OK");
        isArranging = false;
        isTA_Yes = true;
    }

    // 按鈕功能 取消隊伍編排
    public void TA_NoButtonControl()
    {
        if (isArranging == false) return;

        isArranging = false;
        isTA_No = true;
        Debug.Log("取消編輯  isTA_No狀態: " + isTA_No);
    }
}
