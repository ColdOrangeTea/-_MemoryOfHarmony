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
    // public Text teamNumber_Panel_Text;
    // public Text Character_TeamNumber_Text;

    // ---HP、MP的控制---

    [Header("資料 float")]

    // 計算Hp比例
    public float percentage_Hp = 1.0f;

    // HpBar全長180px 在畫面中到血槽底部時是(38,n)、滿血的位置是(218,n) 
    public float percentage_Hp_For_Image = 180.0f;

    // 計算Mp比例
    public float percentage_Mp = 1.0f;

    // MpBar全長180px 在畫面中到血槽底部時是(38,n)、滿血的位置是(218,n) 
    public float percentage_Mp_For_Image = 180.0f;

    [Header("UI物件Image")]
    public Image hpBar;
    public Image mpBar;
    // Start is called before the first frame update
    void Start()
    {
        InitTeamNumberData_Object();
        GetTeamNumberInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HpControl()
    {
        float float_Hp = characterData_Info.characterData.hp;

        percentage_Hp = (float_Hp / characterData_Info.characterData.maxHp);
        percentage_Hp_For_Image = 38 + (180.0f * percentage_Hp);
        hpBar.transform.position = new Vector3(percentage_Hp_For_Image, hpBar.transform.position.y, hpBar.transform.position.z);
    }
    void MpControl()
    {
        float float_Mp = characterData_Info.characterData.mp;

        percentage_Mp = (float_Mp / characterData_Info.characterData.maxMp);
        percentage_Mp_For_Image = 38 + (180.0f * percentage_Mp);
        mpBar.transform.position = new Vector3(percentage_Mp_For_Image, mpBar.transform.position.y, mpBar.transform.position.z);
    }

    // 讀取會顯示在UI上的角色資訊
    public void GetTeamNumberInfo()
    {
        // 抓取物件
        characterData_Info = GetComponent<CharacterData_Info>();

        Character_Name_Text.text = characterData_Info.characterData.characterName;
        Character_Hp_Text.text = characterData_Info.characterData.hp.ToString() + " / " + characterData_Info.characterData.maxHp.ToString();
        Character_Mp_Text.text = characterData_Info.characterData.mp.ToString() + " / " + characterData_Info.characterData.maxMp.ToString();
        Debug.Log("characterData_Info: " + characterData_Info + " characterData_Info.characterData.hp: " + characterData_Info.characterData.hp);

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
        hpBar = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
        mpBar = this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
        Character_Name_Text = this.gameObject.transform.GetChild(2).GetComponent<Text>();
        Character_Hp_Text = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        Character_Mp_Text = this.gameObject.transform.GetChild(4).GetComponent<Text>();
    }
}
