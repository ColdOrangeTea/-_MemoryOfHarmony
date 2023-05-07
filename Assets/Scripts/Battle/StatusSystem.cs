using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSystem : MonoBehaviour
{


    void Start()
    {

    }

}


// public class StatusSystem : MonoBehaviour
// {
//     [SerializeField]
//     BattleMenu_Button_Action battleSystem;

// public int playerHp=100;
//     void Start()
//     {
//         battleSystem = GetComponent<BattleMenu_Button_Action>();
//         battleSystem.StatusChanging += OnStatusChanging;
//     }

//     // 實做區塊
//     public void OnStatusChanging(object sender, StatusEventargs e)
//     {
//         print($"{sender}\t{e.actType} {e.target} {e.amount}");
//         if (e.target == "Player")
//         {
//             if (e.actType == StatusEventargs.ActType.Heal)
//             {
//                 BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.baseUnitData[1] += e.amount;
//             }
//             else if (e.actType == StatusEventargs.ActType.Damage)
//             {
//                 playerHp -= e.amount;
//             }
//             else if (e.actType == StatusEventargs.ActType.Flee)
//             {

//             }
//         }
//     }
// }
// // 嘗試中 不知道理解正不正確 System.EventArgs 類似委派(delegate) 的功能 委派用來儲存 "方法的位置"
// // 寫法:    public delegate 回傳類型 委派名稱(傳入參數);
// public class StatusEventargs : System.EventArgs
// {
//     public ActType actType;
//     public string target;
//     public int amount;
//     public enum ActType
//     {
//         Damage,
//         Heal,
//         Flee
//     }
//     public StatusEventargs(ActType act, string unitData, int value)
//     {
//         actType = act;
//         target = unitData;
//         amount = value;
//     }

// }
