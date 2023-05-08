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

    public GameObject battleOver; // 手動掛
    // [Header("UI物件Image")]

    public Text Talking;

    void Start()
    {
        InitUI_Object();
    }

    void Update()
    {
        isClicked();
        GetTalking();

        if (EnemyData_Info.deadCount == 2)
        {
            battleOver.SetActive(true);
        }
    }

    void isClicked()
    {
        // GetTeamNumberInfo();
        ShowBattleMenu_Action();
        ShowBattle_Status();
    }
    public const int attack = 0;
    public const int skill = 1;
    public const int item = 2;
    public const int equip = 3;
    public const int flee = 4;

    void GetTalking()
    {
        if (EnemyData_Info.deadCount == 2)
        {
            Talking.text = "戰鬥結束";

        }
        if (BattleMenu_Button_Action.actTypeBool[attack] == false) return;
        if (BattleMenu_Button_EnemyMember.enemy_Info_Click == null) return;

        Talking.text = BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.unitName +
                   "對" + BattleMenu_Button_EnemyMember.enemy_Info_Click.enemyData.unitName + "造成" +
                   BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.baseUnitData[4].ToString() + "傷害";

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
