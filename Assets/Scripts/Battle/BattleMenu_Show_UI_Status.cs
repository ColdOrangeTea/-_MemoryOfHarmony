using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenu_Show_UI_Status : MonoBehaviour
{
    [Header("傳遞資料的物件")]
    public CharacterData_Info characterData_Info;

    // [Header("資料 bool")]
    // [Header("資料 int")]
    // [Header("資料 float")]
    // [Header("UI物件 GameObject")]

    [Header("UI物件Text")]
    private Text Character_Hp_Text;
    private Text Character_Mp_Text;

    // ---HP、MP的控制---

    [Header("資料 float")]

    // 計算Hp比例
    private float percentage_Hp = 1.0f;

    // HpBar全長180px 在畫面中到血槽底部時是(38,n)、滿血的位置是(218,n) 
    private float percentage_Hp_For_Image = 180.0f;

    // 計算Mp比例
    private float percentage_Mp = 1.0f;

    // MpBar全長180px 在畫面中到血槽底部時是(38,n)、滿血的位置是(218,n) 
    private float percentage_Mp_For_Image = 180.0f;

    [Header("UI物件Image")]
    private Image hpBar;
    private Image mpBar;
    private Image Character_Image;

    void Start()
    {
        InitTeamNumberData_Object();
    }

    void Update()
    {

    }

    void HpControl()
    {
        float float_Hp = characterData_Info.characterData.baseUnitData[1];
        percentage_Hp = (float_Hp / characterData_Info.characterData.baseUnitData[0]);

        percentage_Hp_For_Image = 38 + (180.0f * percentage_Hp);
        hpBar.transform.position = new Vector3(percentage_Hp_For_Image, hpBar.transform.position.y, hpBar.transform.position.z);
    }
    void MpControl()
    {
        float float_Mp = characterData_Info.characterData.baseUnitData[3];
        percentage_Mp = (float_Mp / characterData_Info.characterData.baseUnitData[2]);

        percentage_Mp_For_Image = 38 + (180.0f * percentage_Mp);
        mpBar.transform.position = new Vector3(percentage_Mp_For_Image, mpBar.transform.position.y, mpBar.transform.position.z);
    }

    // 讀取會顯示在UI上的角色資訊
    public void GetTeamNumberInfo()
    {
        Character_Hp_Text.text = characterData_Info.characterData.baseUnitData[1].ToString() + " / " + characterData_Info.characterData.baseUnitData[0].ToString();
        Character_Mp_Text.text = characterData_Info.characterData.baseUnitData[3].ToString() + " / " + characterData_Info.characterData.baseUnitData[2].ToString();

        HpControl();
        MpControl();
    }

    void InitTeamNumberData_Object()
    {
        // 抓取物件
        characterData_Info = GetComponent<CharacterData_Info>();
    }
}
