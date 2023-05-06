using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Show_UI_TeamNumber : MonoBehaviour // 遊戲選單中的UI顯示控制，要手動把程式掛在 Button_TeamNumber_n
{
    [Header("傳遞資料的物件")]
    public CharacterData_Info characterData_Info;

    [Header("UI物件 GameObject")]
    // 隊伍成員
    private GameObject button_TeamNumber_00;
    private GameObject button_TeamNumber_01;
    private GameObject button_TeamNumber_02;
    private GameObject button_TeamNumber_03;
    private GameObject button_TeamNumber_04;
    private GameObject button_TeamNumber_05;
    private GameObject button_TeamNumber_06;

    public GameObject teamNumber_Panel;

    [Header("UI物件Text")]
    private Text Character_Name_Text;
    private Text Character_Hp_Text;
    private Text Character_Mp_Text;
    public Text teamNumber_Panel_Text;
    private Text Character_TeamNumber_Text;

    [Header("UI物件Image")]
    private Image hpBar;
    private Image mpBar;

    [Header("資料 float")]
    // 計算Hp比例
    private float percentage_Hp = 1.0f;
    // HpBar全長138px 隊伍左欄在畫面中到血槽底部時是(1048,n)、滿血的位置是(1186,n) 
    // HpBar全長138px 隊伍右欄在畫面中到血槽底部時是(1528,n)、滿血的位置是(1666,n) 

    private float percentage_Hp_For_Image = 138.0f;

    // 計算Mp比例
    private float percentage_Mp = 1.0f;
    // MpBar全長138px 隊伍左欄在畫面中到血槽底部時是(1048,n)、滿血的位置是(1186,n) 
    // MpBar全長138px 隊伍右欄在畫面中到血槽底部時是(1528,n)、滿血的位置是(1666,n) 

    private float percentage_Mp_For_Image = 138.0f;

    void Start()
    {
        InitTeamNumberData_Object();
        GetTeamNumberInfo();
    }

    void Update()
    {
        SetTeamNumber();
        UseItem();
    }

    // 所有物件的Update都執行過 LateUpdate 才會執行
    void LateUpdate()
    {
        if (GameMenu_Button_TeamNumber.isTA_Yes == true)
            GameMenu_Button_TeamNumber.isTA_Yes = false;

        if (GameMenu_Button_TeamNumber.isTA_No == true)
            GameMenu_Button_TeamNumber.isTA_No = false;
    }

    // 重製在進行隊伍編排時用到的暫存數
    void ResetTeamNumber()
    {
        characterData_Info.temporary_TeamNumber = 99;
        characterData_Info.temporary_CharacterData = null;
        teamNumber_Panel.SetActive(false);
        if (characterData_Info.isClick)
        {
            characterData_Info.isClick = false;
        }
    }

    void UseItem()
    {
        if (GameMenu_Button_Item.isUsingItem)
            GetTeamNumberInfo();
    }

    //  設定隊伍順序
    void SetTeamNumber()
    {
        // 確認更動隊伍成員的順序
        if (GameMenu_Button_TeamNumber.isTA_Yes)
        {
            ResetTeamNumber();
            GetTeamNumberInfo();
        }
        if (GameMenu_Button_TeamNumber.isTA_No)// 取消更動
        {
            ResetTeamNumber();
            Debug.Log("順序: " + characterData_Info.temporary_TeamNumber);
        }
    }

    void HpControl()
    {
        /* baseUnitData 陣列的說明: 0: MaxHp   1: Hp  2: MaxMp   3: Mp  */
        float float_Hp = characterData_Info.characterData.baseUnitData[1];
        percentage_Hp = (float_Hp / characterData_Info.characterData.baseUnitData[0]);

        // UI顯示位置在左側 和 右側 的血條位置不一樣
        if (characterData_Info.characterData.teamNumber < 4)
            percentage_Hp_For_Image = 1048 + (138.0f * percentage_Hp);
        else
            percentage_Hp_For_Image = 1528 + (138.0f * percentage_Hp);

        hpBar.transform.position = new Vector3(percentage_Hp_For_Image, hpBar.transform.position.y, hpBar.transform.position.z);

    }
    void MpControl()
    {
        float float_Mp = characterData_Info.characterData.baseUnitData[3];
        percentage_Mp = (float_Mp / characterData_Info.characterData.baseUnitData[2]);

        // UI顯示位置在左側 和 右側 的血條位置不一樣
        if (characterData_Info.characterData.teamNumber < 4)
            percentage_Mp_For_Image = 1048 + (138.0f * percentage_Mp);
        else
            percentage_Mp_For_Image = 1528 + (138.0f * percentage_Mp);

        mpBar.transform.position = new Vector3(percentage_Mp_For_Image, mpBar.transform.position.y, mpBar.transform.position.z);
    }

    // 讀取會顯示在UI上的角色資訊
    public void GetTeamNumberInfo()
    {
        // 抓取物件
        characterData_Info = GetComponent<CharacterData_Info>();

        Character_TeamNumber_Text.text = (1 + characterData_Info.characterData.teamNumber).ToString();
        Character_Name_Text.text = characterData_Info.characterData.characterName;
        Character_Hp_Text.text = characterData_Info.characterData.baseUnitData[1].ToString() + " / " + characterData_Info.characterData.baseUnitData[0].ToString();
        Character_Mp_Text.text = characterData_Info.characterData.baseUnitData[3].ToString() + " / " + characterData_Info.characterData.baseUnitData[2].ToString();
        // Debug.Log("characterData_Info: " + characterData_Info + " characterData_Info.characterData.hp: " + characterData_Info.characterData.hp);

        HpControl();
        MpControl();
    }

    // 目前成員有多少，就在選單顯示多少成員版面
    void Button_TeamNumberControl()
    {
        if (CharacterData_Info.numberOfMembers == 1)
            button_TeamNumber_00.SetActive(true);
        if (CharacterData_Info.numberOfMembers >= 2)
            button_TeamNumber_01.SetActive(true);
        if (CharacterData_Info.numberOfMembers >= 3)
            button_TeamNumber_02.SetActive(true);
        if (CharacterData_Info.numberOfMembers >= 4)
            button_TeamNumber_03.SetActive(true);
        if (CharacterData_Info.numberOfMembers >= 5)
            button_TeamNumber_04.SetActive(true);
        if (CharacterData_Info.numberOfMembers >= 6)
            button_TeamNumber_05.SetActive(true);
        if (CharacterData_Info.numberOfMembers == 7)
            button_TeamNumber_06.SetActive(true);
    }

    void InitTeamNumberData_Object()
    {
        // 抓取物件

        // gameMenu_Show_UI_TeamNumber = GetComponent<GameMenu_Show_UI_TeamNumber>();

        button_TeamNumber_00 = this.gameObject.transform.parent.GetChild(1).gameObject;
        button_TeamNumber_01 = this.gameObject.transform.parent.GetChild(2).gameObject;
        button_TeamNumber_02 = this.gameObject.transform.parent.GetChild(3).gameObject;
        button_TeamNumber_03 = this.gameObject.transform.parent.GetChild(4).gameObject;
        button_TeamNumber_04 = this.gameObject.transform.parent.GetChild(5).gameObject;
        button_TeamNumber_05 = this.gameObject.transform.parent.GetChild(5).gameObject;
        button_TeamNumber_06 = this.gameObject.transform.parent.GetChild(6).gameObject;

        hpBar = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
        mpBar = this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
        Character_Name_Text = this.gameObject.transform.GetChild(2).GetComponent<Text>();
        Character_Hp_Text = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        Character_Mp_Text = this.gameObject.transform.GetChild(4).GetComponent<Text>();
        Character_TeamNumber_Text = this.gameObject.transform.GetChild(5).GetComponent<Text>();

        // 抓取物件
        teamNumber_Panel = this.gameObject.transform.GetChild(6).gameObject;
        teamNumber_Panel_Text = this.gameObject.transform.GetChild(6).GetChild(0).GetComponent<Text>();

    }

}
