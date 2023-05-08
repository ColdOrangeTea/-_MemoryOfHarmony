using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleMenu_Button_EnemyMember : MonoBehaviour
{

    public const int attack = 0;
    public const int skill = 1;
    public const int item = 2;
    public const int equip = 3;
    public const int flee = 4;
    [Header("傳遞資料的物件")]
    public static EnemyData_Info enemy_Info_Click;
    // public static bool isClick = false;

    // 按鈕功能 記錄在UI版面按下的角色資料
    public void GetInfo()
    {
        // 案成員、案攻擊紐 才能選敵人
        if (BattleMenu_Button_TeamMember.characterData_Info_Click && BattleMenu_Button_Action.actTypeBool[attack] == true)
        {
            enemy_Info_Click = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<EnemyData_Info>();
            Debug.Log("在不在r" + enemy_Info_Click);
        }
    }
}
