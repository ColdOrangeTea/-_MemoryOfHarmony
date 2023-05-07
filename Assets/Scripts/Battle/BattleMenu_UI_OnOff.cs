using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenu_UI_OnOff : MonoBehaviour
{
    [Header("傳遞資料的物件")]
    // public CharacterData_Info characterData_Info;
    // ---------------------------- Status 的資料 ----------------------------

    [Header("UI物件 GameObject")]
    public GameObject battle_Status;

    // ---------------------------- Action 的資料 ----------------------------
    [Header("UI物件 GameObject")]
    public GameObject battleMenu_Action;
    // [Header("UI物件Image")]

    void Start()
    {
        InitUI_Object();
    }

    void Update()
    {
        Cancel();
        isClicked();
    }

    void Cancel()
    {
        if (Input.GetMouseButtonDown(1))
        {
            BattleMenu_Button_TeamMember.characterData_Info_Click = null;
            Debug.Log("右鍵有沒有反應" + BattleMenu_Button_TeamMember.characterData_Info_Click);
        }
    }
    void isClicked()
    {
        // GetTeamNumberInfo();
        ShowBattleMenu_Action();
        ShowBattle_Status();
    }


    void ShowBattle_Status()
    {
        if (BattleMenu_Button_TeamMember.characterData_Info_Click == null)
        {
            if (battle_Status.activeInHierarchy == false) return;
            battle_Status.SetActive(false);
        }
        else
        {
            if (battle_Status.activeInHierarchy == true) return;
            // Debug.Log("WHY");
            battle_Status.SetActive(true);
        }
    }

    void ShowBattleMenu_Action()
    {
        if (BattleMenu_Button_TeamMember.characterData_Info_Click == null)
        {
            if (battleMenu_Action.activeInHierarchy == false) return;
            battleMenu_Action.SetActive(false);
        }
        else
        {
            if (battleMenu_Action.activeInHierarchy == true) return;
            // Debug.Log("輛");
            battleMenu_Action.SetActive(true);
        }
    }

    // // 取得點擊的隊友資料
    // void GetTeamNumberInfo()
    // {
    //     if (BattleMenu_Button_TeamMember.characterData_Info_Click == null) return;
    //     Debug.Log("取得");
    //     characterData_Info = BattleMenu_Button_TeamMember.characterData_Info_Click;
    // }

    void InitUI_Object()
    {
        // 抓取物件
        battle_Status = transform.parent.GetChild(0).GetChild(2).gameObject;
        battleMenu_Action = transform.parent.GetChild(0).GetChild(3).gameObject;

    }
}
