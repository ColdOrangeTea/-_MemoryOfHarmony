using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    //---UI顯示控制---
    public static bool isOpenGameMenu = false;
    public GameObject gameMenu;
    public GameObject gameMenu_Team;
    public GameObject gameMenu_Item;
    public GameObject gameMenu_Skill;
    public GameObject gameMenu_Equipment;
    public GameObject gameMenu_Status;
    public GameObject gameMenu_Hint;
    public GameObject gameMenu_Save;
    public GameObject gameMenu_Setting;

    // ---隊伍編排---
    private List<int> allTeamNumber = new List<int>();
    // 分配隊伍順序用的數字，每次編輯隊伍順序之前會重製
    public static int teamOrder = 0;
    public static bool isArranging = false;
    public static bool isTA_Yes = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameMenuControl();
    }

    // 用來開啟Team頁面的按鈕控制
    public void TeamButtonControl()
    {
        CloseAllGameMenu();
        Debug.Log("隊伍順序");
        gameMenu_Team.SetActive(true);
    }
    public void TeamArrangementButtonControl()
    {
        Debug.Log("開始編排隊伍順序");
        isArranging = true;
        teamOrder = 0;
    }
    public void TA_YesButtonControl()
    {
        Debug.Log("隊伍順序OK");
        isArranging = false;
        isTA_Yes = true;
    }
    public void TA_NoButtonControl()
    {
        Debug.Log("取消編輯");
        isArranging = false;
    }

    // 關閉所有遊戲選單的功能介面
    void CloseAllGameMenu()
    {
        gameMenu_Team.SetActive(false);
        gameMenu_Item.SetActive(false);
        gameMenu_Skill.SetActive(false);
        gameMenu_Equipment.SetActive(false);
    }
    // 用來開啟Item頁面的按鈕控制
    public void ItemButtonControl()
    {
        CloseAllGameMenu();
        Debug.Log("開啟item選單");
        gameMenu_Item.SetActive(true);
    }
    // 用來開啟Skill頁面的按鈕控制
    public void SkillButtonControl()
    {
        CloseAllGameMenu();
        Debug.Log("開啟Skill選單");
        gameMenu_Skill.SetActive(true);
    }
    // 用來開啟Equipment頁面的按鈕控制
    public void EquipmentButtonControl()
    {
        CloseAllGameMenu();
        Debug.Log("開啟Equipment選單");
        gameMenu_Equipment.SetActive(true);
    }
    // 開關GameMenu
    void GameMenuControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameMenu.activeInHierarchy)
            {
                if (isArranging) return;

                Debug.Log("關閉遊戲選單");
                CloseAllGameMenu();
                gameMenu.SetActive(false);
                isOpenGameMenu = false;
            }
            else
            {
                Debug.Log("開啟遊戲選單");
                gameMenu.SetActive(true);
                isOpenGameMenu = true;
            }
        }
    }

}
