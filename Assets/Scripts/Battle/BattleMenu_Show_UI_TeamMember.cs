using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleMenu_Show_UI_TeamMember : MonoBehaviour
{
    [Header("傳遞資料的物件")]
    public CharacterData_Info characterData_Info;

    // [Header("資料 bool")]
    // [Header("資料 int")]
    // [Header("資料 float")]
    // [Header("UI物件 GameObject")]

    [Header("UI物件Text")]
    public Text Character_Name_Text;
    public Text Character_Hp_Text;
    public Text Character_Mp_Text;

    // ---HP、MP的控制---

    [Header("資料 float")]

    // 計算Hp比例
    public float percentage_Hp = 1.0f;

    // HpBar全長138px 在畫面中到血槽底部時是(73,n)、滿血的位置是(211,n) 
    public float percentage_Hp_For_Image = 138.0f;

    // 計算Mp比例
    public float percentage_Mp = 1.0f;

    // MpBar全長138px 在畫面中到血槽底部時是(73,n)、滿血的位置是(211,n) 
    public float percentage_Mp_For_Image = 138.0f;

    [Header("UI物件Image")]
    public Image hpBar;
    public Image mpBar;

    void Start()
    {
        InitTeamNumberData_Object();
        GetTeamNumberInfo();
    }

    void Update()
    {

    }

    void HpControl()
    {
        /* baseUnitData 陣列的說明: 0: MaxHp   1: Hp  2: MaxMp   3: Mp  */
        float float_Hp = characterData_Info.characterData.baseUnitData[1];
        percentage_Hp = (float_Hp / characterData_Info.characterData.baseUnitData[0]);

        percentage_Hp_For_Image = 73 + (138.0f * percentage_Hp);
        hpBar.transform.position = new Vector3(percentage_Hp_For_Image, hpBar.transform.position.y, hpBar.transform.position.z);
    }
    void MpControl()
    {
        float float_Mp = characterData_Info.characterData.baseUnitData[3];
        percentage_Mp = (float_Mp / characterData_Info.characterData.baseUnitData[2]);

        percentage_Mp_For_Image = 73 + (138.0f * percentage_Mp);
        mpBar.transform.position = new Vector3(percentage_Mp_For_Image, mpBar.transform.position.y, mpBar.transform.position.z);
    }

    // 讀取會顯示在UI上的角色資訊
    public void GetTeamNumberInfo()
    {
        Character_Name_Text.text = characterData_Info.characterData.characterName;
        Character_Hp_Text.text = characterData_Info.characterData.baseUnitData[1].ToString() + " / " + characterData_Info.characterData.baseUnitData[0].ToString();
        Character_Mp_Text.text = characterData_Info.characterData.baseUnitData[3].ToString() + " / " + characterData_Info.characterData.baseUnitData[2].ToString();
        // Debug.Log("characterData_Info: " + characterData_Info + " characterData_Info.characterData.hp: " + characterData_Info.characterData.baseUnitData[1]);

        HpControl();
        MpControl();
    }

    // 目前成員有多少，就在選單顯示多少成員版面
    void Button_TeamNumberControl()
    {

    }

    void InitTeamNumberData_Object()
    {
        // 抓取物件
        characterData_Info = GetComponent<CharacterData_Info>();
        // 抓取物件
        hpBar = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
        mpBar = this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
        Character_Name_Text = this.gameObject.transform.GetChild(2).GetComponent<Text>();
        Character_Hp_Text = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        Character_Mp_Text = this.gameObject.transform.GetChild(4).GetComponent<Text>();
    }
}
