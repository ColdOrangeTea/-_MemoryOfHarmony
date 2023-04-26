using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu_TeamNumberControl : MonoBehaviour
{
    // 10 未分配
    public int default_TeamNumber = 0;
    public int temporary_TeamNumber = 10;
    public int teamNumber = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetTeamNumber();
    }

    // 所有物件的Update都執行過 LateUpdate 才會執行
    void LateUpdate()
    {
        if (GameMenu.isTA_Yes == true)
        {

            GameMenu.isTA_Yes = false;
        }

    }

    public void SetTeamNumber()
    {
        if (GameMenu.isTA_Yes)
        {
            teamNumber = temporary_TeamNumber;
            Debug.Log("順序: " + teamNumber);
            temporary_TeamNumber = 10;
        }

    }

    // 被點擊時記錄下自己的順序
    public void GetTemporary_TeamNumber()
    {
        if (GameMenu.isArranging)
        {
            if (GameMenu.teamOrder == 7) return; //排滿順序了
            temporary_TeamNumber = GameMenu.teamOrder;
            GameMenu.teamOrder += 1;
        }
        Debug.Log("暫存順序: " + temporary_TeamNumber);
    }
}
