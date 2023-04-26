using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    public static bool isOpenGameMenu = false;
    public GameObject gameMenu;
<<<<<<< HEAD
    public GameObject gameMenu_Item;
    public GameObject gameMenu_Skill;
    public GameObject gameMenu_Equipment;
    public GameObject gameMenu_Status;
    public GameObject gameMenu_Hint;
    public GameObject gameMenu_Save;
    public GameObject gameMenu_Setting;

    public Button button_Item;
    public Button button_Skill;
    public Button button_Equipment;
    public Button button_Status;
    public Button button_Hint;
    public Button button_Save;
    public Button button_Setting;
=======
    public Button item;
    public Button Skill;
>>>>>>> origin/main

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OpenGameMenu();
    }

<<<<<<< HEAD
    // 關閉所有遊戲選單的功能介面
    void CloseAllGameMenu()
    {
        gameMenu_Item.SetActive(false);
        gameMenu_Skill.SetActive(false);
        gameMenu_Equipment.SetActive(false);
    }

    public void ItemButtonControl()
    {
        CloseAllGameMenu();
        Debug.Log("開啟item選單");
        gameMenu_Item.SetActive(true);
    }
    public void SkillButtonControl()
    {
        CloseAllGameMenu();
        Debug.Log("開啟Skill選單");
        gameMenu_Skill.SetActive(true);
    }

    public void EquipmentButtonControl()
    {
        CloseAllGameMenu();
        Debug.Log("開啟Equipment選單");
        gameMenu_Equipment.SetActive(true);
=======
    public void ItemButtonControl()
    {
        Debug.Log("Test");

>>>>>>> origin/main
    }

    void OpenGameMenu()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Escape))
=======
         if (Input.GetKeyDown(KeyCode.Escape))
>>>>>>> origin/main
        {
            if (gameMenu.activeInHierarchy)
            {
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
