using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenuControl : MonoBehaviour
{
    //---UI顯示控制---
    public static bool isOpenGameMenu = false;
    public static bool isOpenGameMenu_Team = false;
    public static bool isOpenGameMenu_Team_TeamArrangement = false;
    public static bool isOpenGameMenu_Item = false;
    public static bool isOpenGameMenu_Skill = false;
    public static bool isOpenGameMenu_Equipment = false;

    //這是Empty
    public GameObject gameMenu_Button;
    public GameObject gameMenu;
    //左側功能選單的按鈕  
    public GameObject gameMenu_Panel;
    public GameObject gameMenu_GameStatus;
    // UI介面
    public GameObject gameMenu_Team;
    public GameObject gameMenu_Team_TeamArrangement;
    public GameObject gameMenu_Item;
    public GameObject gameMenu_Skill;
    public GameObject gameMenu_Equipment;
    public GameObject gameMenu_Status;
    public GameObject gameMenu_Hint;
    public GameObject gameMenu_Save;
    public GameObject gameMenu_Setting;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameMenu();
        UIImageOnOff();

    }

    // 用Bool控制 所有遊戲選單的功能介面
    void CloseAllGameMenu()
    {
        isOpenGameMenu_Team = false;
        isOpenGameMenu_Item = false;
        isOpenGameMenu_Skill = false;
        isOpenGameMenu_Equipment = false;
    }
    // 用Bool控制 開關所有遊戲選單的介面
    void UIImageOnOff()
    {
        if (isOpenGameMenu_Team == false)
            gameMenu_Team.SetActive(false);
        else if (isOpenGameMenu_Team == true)
            gameMenu_Team.SetActive(true);

        if (isOpenGameMenu_Team_TeamArrangement == false)
            gameMenu_Team_TeamArrangement.SetActive(false);
        else if (isOpenGameMenu_Team_TeamArrangement == true)
            gameMenu_Team_TeamArrangement.SetActive(true);

        if (isOpenGameMenu_Item == false)
            gameMenu_Item.SetActive(false);
        else if (isOpenGameMenu_Item == true)
            gameMenu_Item.SetActive(true);

        if (isOpenGameMenu_Skill == false)
            gameMenu_Skill.SetActive(false);
        else if (isOpenGameMenu_Skill == true)
            gameMenu_Skill.SetActive(true);

        if (isOpenGameMenu_Equipment == false)
            gameMenu_Equipment.SetActive(false);
        else if (isOpenGameMenu_Equipment == true)
            gameMenu_Equipment.SetActive(true);
    }

    // 用來開啟Team頁面的按鈕控制
    public void TeamButtonControl()
    {
        // 讓左側的按鈕沒有反應
        if (GameMenu_Button_TeamNumber.isArranging) return;
        if (GameMenu_Button_Item.isUsingItem) return;

        CloseAllGameMenu();
        Debug.Log("隊伍順序");
        isOpenGameMenu_Team = true;
        isOpenGameMenu_Team_TeamArrangement = true;
    }

    // 用來開啟Item頁面的按鈕控制
    public void ItemButtonControl()
    {
        // 讓左側的按鈕沒有反應
        if (GameMenu_Button_TeamNumber.isArranging) return;
        if (GameMenu_Button_Item.isUsingItem) return;

        CloseAllGameMenu();
        Debug.Log("開啟item選單");
        isOpenGameMenu_Item = true;
    }
    // 用來開啟Skill頁面的按鈕控制
    public void SkillButtonControl()
    {
        // 讓左側的按鈕沒有反應
        if (GameMenu_Button_TeamNumber.isArranging) return;
        if (GameMenu_Button_Item.isUsingItem) return;

        CloseAllGameMenu();
        Debug.Log("開啟Skill選單");
        isOpenGameMenu_Skill = true;
    }
    // 用來開啟Equipment頁面的按鈕控制
    public void EquipmentButtonControl()
    {
        // 讓左側的按鈕沒有反應
        if (GameMenu_Button_TeamNumber.isArranging) return;
        if (GameMenu_Button_Item.isUsingItem) return;

        CloseAllGameMenu();
        Debug.Log("開啟Equipment選單");
        isOpenGameMenu_Equipment = true;
    }
    // 開關GameMenu
    void GameMenu()
    {
        // 不能開關選單
        if (GameMenu_Button_TeamNumber.isArranging) return;
        if (GameMenu_Button_Item.isUsingItem) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameMenu.activeInHierarchy)
            {
                Debug.Log("關閉遊戲選單");
                CloseAllGameMenu();
                gameMenu.SetActive(false);
                gameMenu_Button.SetActive(true);
                gameMenu_Panel.SetActive(true);
                gameMenu_GameStatus.SetActive(true);
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
