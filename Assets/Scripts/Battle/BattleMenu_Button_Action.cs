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
        actTypeBool[flee] = true;
        Debug.Log("逃跑");
        SetNull();
        SceneManager.LoadScene("WorldMap");

    }

    void SetNull()
    {
        if (actTypeBool[flee] == true)
        {
            BattleMenu_Button_TeamMember.characterData_Info_Click = null;
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
