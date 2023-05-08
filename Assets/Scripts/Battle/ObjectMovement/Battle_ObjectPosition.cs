using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct UnitPosition
{
    public float x;
    public float y;
    public float z;
}
public class Battle_ObjectPosition : MonoBehaviour // 掛ObjectControl
{
    // 用來記錄Object的位置(x,y,z)
    public UnitPosition[] unitPosition = new UnitPosition[5];

    // 暫時取得的角色資訊
    private CharacterData_Info info;

    // 所有角色的 UnitData型別資料儲存成一個陣列，元素n = teamNumber(隊伍順序)
    public GameObject battleMenu_TeamMember; // 手動掛BattleMenu_TeamMember物件 用來當作抓取 teamMemberData 的parent
    public CharacterData_Info[] teamMemberData = new CharacterData_Info[4];

    // 隊伍成員 Object
    public Transform[] hero = new Transform[5];
    private Vector3 moveForward = new Vector3(-2, 0, 1.8f);
    // 敵人成員 Object
    public Transform[] enemy = new Transform[3];
    void Start()
    {
        InitTeamNumberData_Object();
        for (int i = 1; i < hero.Length; i++)
        {
            unitPosition[i].x = hero[i].transform.position.x;
            unitPosition[i].y = hero[i].transform.position.y;
            unitPosition[i].z = hero[i].transform.position.z;
        }
    }

    void Update()
    {
        MoveToForward();
    }

    void MoveToForward()
    {
        // 沒有點人
        if (BattleMenu_Button_TeamMember.characterData_Info_Click == null)
        {
            // 已經清除暫存的成員資料就不用再清除了
            if (info == null) return;

            // hero陣列的第0個物件是Empty 所以是1開始
            Debug.Log("hero.Length: " + hero.Length);

            hero[info.characterData.teamNumber + 1].transform.position = new Vector3(
            unitPosition[info.characterData.teamNumber + 1].x,
            unitPosition[info.characterData.teamNumber + 1].y,
            unitPosition[info.characterData.teamNumber + 1].z);

            // 清除暫存的成員資料
            info = null;

        }
        else // 點了隊伍成員
        {
            // 已經移動到前面就不用再動了
            if (hero[BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.teamNumber + 1].transform.position == moveForward) return;
            Debug.Log("hero.動起來: " + BattleMenu_Button_TeamMember.characterData_Info_Click);

            // 上一個點的成員還沒歸位 要回去
            if (info != null && hero[info.characterData.teamNumber + 1].transform.position == moveForward)
            {
                hero[info.characterData.teamNumber + 1].transform.position = new Vector3(
            unitPosition[info.characterData.teamNumber + 1].x,
            unitPosition[info.characterData.teamNumber + 1].y,
            unitPosition[info.characterData.teamNumber + 1].z);
            }
            // 角色移動到前面
            hero[BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.teamNumber + 1].transform.position = moveForward;
            info = BattleMenu_Button_TeamMember.characterData_Info_Click;
        }
    }

    void InitTeamNumberData_Object()
    {
        // 抓取物件

        teamMemberData = battleMenu_TeamMember.GetComponentsInChildren<CharacterData_Info>();
        // teamMemberData = transform.parent.parent.GetChild(4).GetChild(0).GetChild(1).GetComponentsInChildren<CharacterData_Info>();
        hero = transform.parent.GetChild(0).GetComponentsInChildren<Transform>();
        enemy = transform.parent.GetChild(1).GetComponentsInChildren<Transform>();
    }

}
