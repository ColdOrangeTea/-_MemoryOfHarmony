using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleMenu_Show_UI_Action : MonoBehaviour
{
    [Header("傳遞資料的物件")]
    public CharacterData_Info characterData_Info;

    [Header("UI物件 GameObject")]
    public GameObject battleMenu_Action;
    // [Header("UI物件Image")]

    void Start()
    {
        InitAction_Object();

    }

    // Update is called once per frame
    void Update()
    {
        isClicked();
    }

    void isClicked()
    {
        GetTeamNumberInfo();
        ShowBattleMenu_Action();
    }

    void ShowBattleMenu_Action()
    {
        if (BattleMenu_Button_TeamMember.isClick == false) return;
        if (BattleMenu_Button_TeamMember.isClick == true)
        {
            battleMenu_Action.SetActive(true);

        }
        else
        {
            battleMenu_Action.SetActive(false);
        }

    }

    void GetTeamNumberInfo()
    {
        if (BattleMenu_Button_TeamMember.isClick == false) return;
        characterData_Info = BattleMenu_Button_TeamMember.characterData_Info_Click;
    }

    void InitAction_Object()
    {
        // 抓取物件
        battleMenu_Action = this.gameObject.transform.GetChild(0).gameObject;
    }
}
