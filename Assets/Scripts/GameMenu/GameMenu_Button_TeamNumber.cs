using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Button_TeamNumber : MonoBehaviour
{

    [Header("保存角色資訊的資料")]
    public GameObject characterDataControl;
    // 隊伍成員
    public GameObject button_TeamNumber_00;
    public GameObject button_TeamNumber_01;
    public GameObject button_TeamNumber_02;
    public GameObject button_TeamNumber_03;
    public GameObject button_TeamNumber_04;
    public GameObject button_TeamNumber_05;
    public GameObject button_TeamNumber_06;

    // ---隊伍編排---

    // 目前隊伍人數的最大值
    public static int numberOfMembers = 7;

    // 分配用的暫存數，紀錄人物ID
    public static int orderOfTeamMembersID = 0;
    // 分配用的暫存數，紀錄隊伍順序  
    public static int orderOfTeamMembers = 0;

    // 是否在編排隊伍中
    public static bool isArranging = false;
    // 按下確認編排的按鈕，確定編排
    public static bool isTA_Yes = false;
    // 按下取消編排的按鈕
    public static bool isTA_No = false;

    void Update()
    {
        Button_TeamNumberControl();
    }

    // 對成員使用物品的(按鈕功能)
    public void ItemUse()
    {
        // 使用物品中
        if (GameMenu_Button_Item.isUsingItem)
        {
            // GameMenu_ItemControl.itemID_Use
            for (int i = 0; i < 7; i++)
            {
                Debug.Log("幫++: ");
                if (GameMenu_TeamNumberControl.characterID_Click == CharacterData_ID_00.characterID)
                {
                    Debug.Log("東西: " + FindObjectOfType<GameObject>().name == "Button_TeamNumber_0" + i.ToString());
                    GameMenu_TeamNumberControl.characterData[i].hp += GameMenu_ItemControl.itemData[GameMenu_ItemControl.itemID_Use].effectAmount_00;
                }

                else if (GameMenu_TeamNumberControl.characterID_Click == CharacterData_ID_01.characterID)
                {

                }



            }
        }
    }

    // 隊伍編排的按鈕
    public void TeamArrangementButtonControl()
    {
        Debug.Log("開始編排隊伍順序");
        isArranging = true;
        orderOfTeamMembers = 0;
        orderOfTeamMembersID = 0;
    }

    // 確定隊伍編排的按鈕
    public void TA_YesButtonControl()
    {
        if (isArranging == false) return;
        if (orderOfTeamMembers < numberOfMembers - 1)
        {
            Debug.Log("隊伍順序還沒編排好所有人");
            return;
        }
        Debug.Log("隊伍順序OK");
        isArranging = false;
        isTA_Yes = true;
    }

    // 取消隊伍編排的按鈕
    public void TA_NoButtonControl()
    {
        if (isArranging == false) return;

        isArranging = false;
        isTA_No = true;
        Debug.Log("取消編輯  isTA_No狀態: " + isTA_No);
    }

    // 目前成員有多少，就在選單顯示多少成員版面
    void Button_TeamNumberControl()
    {
        if (numberOfMembers == 1)
            button_TeamNumber_00.SetActive(true);
        if (numberOfMembers >= 2)
            button_TeamNumber_01.SetActive(true);
        if (numberOfMembers >= 3)
            button_TeamNumber_02.SetActive(true);
        if (numberOfMembers >= 4)
            button_TeamNumber_03.SetActive(true);
        if (numberOfMembers >= 5)
            button_TeamNumber_04.SetActive(true);
        if (numberOfMembers >= 6)
            button_TeamNumber_05.SetActive(true);
        if (numberOfMembers == 7)
            button_TeamNumber_06.SetActive(true);
    }


}
