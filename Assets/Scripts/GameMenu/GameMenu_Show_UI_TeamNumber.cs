using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Show_UI_TeamNumber : MonoBehaviour // 遊戲選單中的UI顯示控制，要手動把程式掛在 Button_TeamNumber_n
{
    [Header("傳遞資料的物件")]
    public CharacterData_Info characterData_Info;

    // // 自己這個程式的物件
    // public GameMenu_Show_UI_TeamNumber gameMenu_Show_UI_TeamNumber;

    [Header("資料 bool")]

    // 用來確認在編排時按過的按鈕，避免按過的按鈕能再按
    public bool isClick = false;

    [Header("資料 int")]

    public int characterID_Click = 99;

    public string orderOfTeamMembers = "";
    [Header("UI物件 GameObject")]
    // 隊伍成員
    public GameObject button_TeamNumber_00;
    public GameObject button_TeamNumber_01;
    public GameObject button_TeamNumber_02;
    public GameObject button_TeamNumber_03;
    public GameObject button_TeamNumber_04;
    public GameObject button_TeamNumber_05;
    public GameObject button_TeamNumber_06;

    public GameObject teamNumber_Panel;

    [Header("UI物件Text")]
    public Text Character_Name_Text;
    public Text Character_Hp_Text;
    public Text Character_Mp_Text;
    public Text teamNumber_Panel_Text;
    public Text Character_TeamNumber_Text;

    [Header("UI物件Image")]
    public Image hpBar;
    public Image mpBar;



    // 計算Hp比例
    public float percentage_Hp = 1.0f;
    // HpBar全長138px 隊伍左欄在畫面中到血槽底部時是(1048,n)、滿血的位置是(1186,n) 
    // HpBar全長138px 隊伍右欄在畫面中到血槽底部時是(1528,n)、滿血的位置是(1666,n) 

    public float percentage_Hp_For_Image = 138.0f;

    // 計算Mp比例
    public float percentage_Mp = 1.0f;
    // MpBar全長138px 隊伍左欄在畫面中到血槽底部時是(1048,n)、滿血的位置是(1186,n) 
    // MpBar全長138px 隊伍右欄在畫面中到血槽底部時是(1528,n)、滿血的位置是(1666,n) 

    public float percentage_Mp_For_Image = 138.0f;
    // Start is called before the first frame update
    void Start()
    {
        InitTeamNumberData_Object();
        GetTeamNumberInfo();

    }
    // Awake 先於Start啟動 
    void Awake()
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
        if (isClick)
        {
            isClick = false;
        }
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
        float float_Hp = characterData_Info.characterData.hp;

        percentage_Hp = (float_Hp / characterData_Info.characterData.maxHp);

        // UI顯示位置在左側 和 右側 的血條位置不一樣
        if (characterData_Info.characterData.teamNumber < 4)
            percentage_Hp_For_Image = 1048 + (138.0f * percentage_Hp);
        else
            percentage_Hp_For_Image = 1528 + (138.0f * percentage_Hp);

        hpBar.transform.position = new Vector3(percentage_Hp_For_Image, hpBar.transform.position.y, hpBar.transform.position.z);

    }
    void MpControl()
    {
        float float_Mp = characterData_Info.characterData.mp;

        percentage_Mp = (float_Mp / characterData_Info.characterData.maxMp);
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
        Character_Hp_Text.text = characterData_Info.characterData.hp.ToString() + " / " + characterData_Info.characterData.maxHp.ToString();
        Character_Mp_Text.text = characterData_Info.characterData.mp.ToString() + " / " + characterData_Info.characterData.maxMp.ToString();
        Debug.Log("characterData_Info: " + characterData_Info + " characterData_Info.characterData.hp: " + characterData_Info.characterData.hp);


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
