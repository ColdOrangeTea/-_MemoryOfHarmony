using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleMenu_Button_TeamMember : MonoBehaviour
{
    [Header("傳遞資料的物件")]
    // public CharacterData_Info characterData_Info;
    public static CharacterData_Info characterData_Info_Click;
    // public static bool isClick = false;

    // 按鈕功能 記錄在UI版面按下的角色資料
    public void GetInfo()
    {
        if (EnemyData_Info.deadCount == 2) return;
        // characterData_Info = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<CharacterData_Info>();
        // characterData_Info_Click = characterData_Info;
        characterData_Info_Click = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<CharacterData_Info>();
        Debug.Log("在不在r" + characterData_Info_Click);
    }
}
