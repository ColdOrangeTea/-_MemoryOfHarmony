using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleMenu_Show_UI_EnemyMember : MonoBehaviour
{
    public const int attack = 0;
    public const int skill = 1;
    public const int item = 2;
    public const int equip = 3;
    public const int flee = 4;
    [Header("傳遞資料的物件")]
    public EnemyData_Info enemyData_Info;

    // [Header("資料 bool")]
    // [Header("資料 int")]
    // [Header("資料 float")]
    // [Header("UI物件 GameObject")]

    [Header("UI物件Text")]
    public Text enemy_Name_Text;
    public Text enemy_Hp_Text;
    public Text enemy_Mp_Text;

    // ---HP、MP的控制---

    // [Header("資料 float")]

    // // 計算Hp比例
    // public float percentage_Hp = 1.0f;

    // // HpBar全長138px 在畫面中到血槽底部時是(73,n)、滿血的位置是(211,n) 
    // public float percentage_Hp_For_Image = 138.0f;

    // // 計算Mp比例
    // public float percentage_Mp = 1.0f;

    // // MpBar全長138px 在畫面中到血槽底部時是(73,n)、滿血的位置是(211,n) 
    // public float percentage_Mp_For_Image = 138.0f;

    // [Header("UI物件Image")]
    // public Image hpBar;
    // public Image mpBar;

    void Start()
    {
        InitEnemyData_Object();
        GetEnemyDataInfo();
    }

    void Update()
    {
        // if (BattleMenu_Button_Action.actTypeBool[attack] == false) return;s
        GetEnemyDataInfo();
    }

    // void HpControl()
    // {
    //     /* baseUnitData 陣列的說明: 0: MaxHp   1: Hp  2: MaxMp   3: Mp  */
    //     float float_Hp = enemyData_Info.enemyData.baseUnitData[1];
    //     percentage_Hp = (float_Hp / enemyData_Info.enemyData.baseUnitData[0]);

    //     percentage_Hp_For_Image = 73 + (138.0f * percentage_Hp);
    //     hpBar.transform.position = new Vector3(percentage_Hp_For_Image, hpBar.transform.position.y, hpBar.transform.position.z);
    // }
    // void MpControl()
    // {
    //     float float_Mp = enemyData_Info.enemyData.baseUnitData[3];
    //     percentage_Mp = (float_Mp / enemyData_Info.enemyData.baseUnitData[2]);

    //     percentage_Mp_For_Image = 73 + (138.0f * percentage_Mp);
    //     mpBar.transform.position = new Vector3(percentage_Mp_For_Image, mpBar.transform.position.y, mpBar.transform.position.z);
    // }

    // 讀取會顯示在UI上的角色資訊
    public void GetEnemyDataInfo()
    {
        enemy_Name_Text.text = enemyData_Info.enemyData.unitName;
        enemy_Hp_Text.text = "HP: " + enemyData_Info.enemyData.baseUnitData[1].ToString() + " / " + enemyData_Info.enemyData.baseUnitData[0].ToString();
        // enemy_Mp_Text.text = enemyData_Info.enemyData.baseUnitData[3].ToString() + " / " + enemyData_Info.enemyData.baseUnitData[2].ToString();
        // Debug.Log("characterData_Info: " + characterData_Info + " characterData_Info.characterData.hp: " + characterData_Info.characterData.baseUnitData[1]);

        // HpControl();
        // MpControl();
    }

    // // 目前成員有多少，就在選單顯示多少成員版面
    // void Button_TeamNumberControl()
    // {

    // }

    void InitEnemyData_Object()
    {
        // 抓取物件
        enemyData_Info = GetComponent<EnemyData_Info>();
        // 抓取物件
        // hpBar = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
        // mpBar = this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
        enemy_Name_Text = this.gameObject.transform.GetChild(0).GetComponent<Text>();
        enemy_Hp_Text = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        // Character_Mp_Text = this.gameObject.transform.GetChild(4).GetComponent<Text>();
    }
}
