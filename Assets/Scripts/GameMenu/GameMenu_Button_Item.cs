using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Button_Item : MonoBehaviour
{
    public GameObject item_Button_Use;
    public static bool isUsingItem = false;

    void Start()
    {
        // 找物件
        item_Button_Use = this.gameObject.transform.GetChild(1).gameObject;
    }

    public void IU_YesButtonControl()
    {
        Debug.Log(" 確定使用物品");
        isUsingItem = true;
        GameMenu.isOpenGameMenu_Item = false;
        GameMenu.isOpenGameMenu_Team = true;
        GameMenu.isOpenGameMenu_Team_TeamArrangement = false;
    }
    public void IU_NoButtonControl()
    {
        isUsingItem = false;
        Debug.Log(" 取消使用物品，並退出隊伍人員選擇介面");
        item_Button_Use.gameObject.SetActive(false);
    }
}
