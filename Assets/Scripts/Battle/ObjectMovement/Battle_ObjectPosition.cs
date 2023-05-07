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
    public UnitPosition[] unitPosition = new UnitPosition[5];
    private CharacterData_Info info;

    // 所有角色的 UnitData型別資料儲存成一個陣列，元素n = teamNumber(隊伍順序)
    public GameObject battleMenu_TeamMember; // 手動掛BattleMenu_TeamMember物件
    public CharacterData_Info[] teamMemberData = new CharacterData_Info[4];
    public Transform[] hero = new Transform[5];
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
        if (BattleMenu_Button_TeamMember.characterData_Info_Click == null)
        {
            if (info == null) return;
            // hero陣列的第0個物件是Empty 所以是1開始
            Debug.Log("hero.Length: " + hero.Length);

            hero[info.characterData.teamNumber + 1].transform.position = new Vector3(
            unitPosition[info.characterData.teamNumber + 1].x,
            unitPosition[info.characterData.teamNumber + 1].y,
            unitPosition[info.characterData.teamNumber + 1].z);
            info = null;

        }
        else
        {
            if (hero[BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.teamNumber + 1].transform.position == new Vector3(-2, 0, 1.8f)) return;
            Debug.Log("hero.動起來: " + BattleMenu_Button_TeamMember.characterData_Info_Click);
            hero[BattleMenu_Button_TeamMember.characterData_Info_Click.characterData.teamNumber + 1].transform.position = new Vector3(-2, 0, 1.8f);
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
