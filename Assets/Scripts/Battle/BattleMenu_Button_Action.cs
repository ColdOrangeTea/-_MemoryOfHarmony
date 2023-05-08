using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMenu_Button_Action : MonoBehaviour
{
    public const int attack = 0;
    public const int skill = 1;
    public const int item = 2;
    public const int equip = 3;
    public const int flee = 4;
    public static bool[] actTypeBool = new bool[5];

    void Update()
    {
        damage();
        Cancel();
    }

    public void BattleOver()
    {
        Debug.Log("結束戰鬥");
        SetNull();
        SceneManager.LoadScene("WorldMap");
        EnemyData_Info.deadCount = 0;
    }
    public void AttackButtonControl()
    {
        actTypeBool[attack] = true;
        Debug.Log("攻擊");
    }
    public void SkillButtonControl()
    {
        // actType[skill] = true;
        Debug.Log("技能");
    }
    public void ItemButtonControl()
    {
        actTypeBool[item] = true;
        Debug.Log("物品");
    }
    public void EquipButtonControl()
    {
        Debug.Log("裝備");
    }
    public void FleeButtonControl()
    {
        // actTypeBool[flee] = true;
        Debug.Log("逃跑");
        SetNull();
        SceneManager.LoadScene("WorldMap");
    }

    void damage()
    {
        if (actTypeBool[attack] == false) return;
        if (BattleMenu_Button_EnemyMember.enemy_Info_Click == null) return;

        Debug.Log("敵人: " + BattleMenu_Button_EnemyMember.enemy_Info_Click + " 角色:" + BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.unitName);
        BattleMenu_Button_EnemyMember.enemy_Info_Click.enemyData.baseUnitData[1] -= BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.baseUnitData[4];
        if (BattleMenu_Button_EnemyMember.enemy_Info_Click.enemyData.baseUnitData[1] <= 0)
        {
            Debug.Log("掛了");
            EnemyData_Info.deadCount += 1;
            Debug.Log("死亡技術: " + EnemyData_Info.deadCount);
            if (EnemyData_Info.deadCount == 2)
            {
                Debug.Log("戰鬥結束");
                // SceneManager.LoadScene("WorldMap");
            }
        }

        BattleMenu_Button_EnemyMember.enemy_Info_Click = null;
        BattleMenu_Button_TeamMember.characterData_Info_Click = null;
        actTypeBool[attack] = false;

    }

    void SetNull()
    {
        if (actTypeBool[flee] == true)
        {
            BattleMenu_Button_TeamMember.characterData_Info_Click = null;
        }
    }

    void Cancel()
    {
        if (Input.GetMouseButtonDown(1))
        {
            actTypeBool[attack] = false;
            actTypeBool[skill] = false;
            actTypeBool[item] = false;
            actTypeBool[equip] = false;
            actTypeBool[flee] = false;
            BattleMenu_Button_TeamMember.characterData_Info_Click = null;
            Debug.Log("右鍵有沒有反應" + BattleMenu_Button_TeamMember.characterData_Info_Click);
        }
    }

}


// public class BattleMenu_Button_Action : MonoBehaviour
// {

//     public event System.EventHandler<StatusEventargs> StatusChanging;
//     void Start()
//     {

//     }

//     void Update()
//     {

//     }

//     void Attack(int damageValue)
//     {

//     }

//     public void AttackButtonControl()
//     {
//         int damageValue = 10;
//         Debug.Log("攻擊");
//         if (this.StatusChanging != null)
//         {
//             StatusChanging(this, new StatusEventargs(StatusEventargs.ActType.Damage, "Player", damageValue));

//         }
//     }
//     public void SkillButtonControl()
//     {
//         Debug.Log("技能");
//     }
//     public void ItemButtonControl()
//     {
//         int healValue = 10;
//         Debug.Log("物品");
//         if (this.StatusChanging != null)
//         {
//             StatusChanging(this, new StatusEventargs(StatusEventargs.ActType.Heal, "Player", healValue));

//         }
//     }
//     public void EquipButtonControl()
//     {
//         Debug.Log("裝備");
//     }
//     public void FleeButtonControl()
//     {
//         Debug.Log("逃跑");
//         SceneManager.LoadScene("WorldMap");

//     }

// }
