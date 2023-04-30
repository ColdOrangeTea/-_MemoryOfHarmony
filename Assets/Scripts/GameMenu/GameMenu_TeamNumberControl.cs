using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData
{
    public int characterID = 0;
    public int teamNumber = 0;

    //角色的基礎資料
    [Header("角色的基礎資料")]
    public string characterName = "Dominate";
    public int maxHp = 100;
    public int hp = 50;
    public int maxMp = 100;
    public int mp = 80;
    public int attack = 100;
    public int defence = 100;
    public int speed = 50;
    public int weaponID = 0;
    public int armorID = 0;
    public int accessoriesID = 0;

    // 加上技能、裝備影響的數值
    [Header("加上技能、裝備影響的角色資料")]
    public int totalMaxHp = 999;
    public int totalHp = 999;
    public int totalMaxMp = 999;
    public int totalMp = 999;
    public int totalAttack = 100;
    public int totalDefence = 100;
    public int totalSpeed = 50;
}

public class GameMenu_TeamNumberControl : MonoBehaviour
{
    public static List<CharacterData> characterData = new List<CharacterData>();

    [Header("保存角色資訊的資料")]
    public GameObject characterDataControl;

    [Header("分配隊伍順序用")]
    // 10 未分配
    public int temporary_CharacterID = 10;
    // public int characterID = 0;
    public int temporary_TeamNumber = 10;
    // public int teamNumber = 0;

    // 用來確認在編排時按過的按鈕，避免按過的按鈕能再按
    public bool isClick = false;
    public GameObject teamNumber_Panel;
    public Text teamNumber_Panel_Text;

    [Header("UI物件")]
    public Text Character_Name_Text;
    public Text Character_Hp_Text;
    public Text Character_Mp_Text;
    public Text Character_TeamNumber_Text;
    public Image hpBar;
    public Image mpBar;
    public int characterID = 0;
    public int teamNumber = 0;
    public string characterName = " ";
    public int maxHp = 0;
    public int hp = 0;
    public int maxMp = 0;
    public int mp = 0;
    public GameObject button_TeamArrangement;

    public static int characterID_Click = 9;

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

    }
    // Awake 先於Start啟動 
    void Awake()
    {
        InitTeamNumberData_Object();
        InitTeamNumberData();
    }

    // Update is called once per frame
    void Update()
    {
        SetTeamNumber();
        SetTeamNumberInfo();
        GetTeamNumberInfo();

    }

    // 所有物件的Update都執行過 LateUpdate 才會執行
    void LateUpdate()
    {
        if (GameMenu_Button_TeamNumber.isTA_Yes == true)
            GameMenu_Button_TeamNumber.isTA_Yes = false;

        if (GameMenu_Button_TeamNumber.isTA_No == true)
            GameMenu_Button_TeamNumber.isTA_No = false;
    }

    void HpControl()
    {
        float float_Hp = hp;

        percentage_Hp = (float_Hp / maxHp);
        if (characterID < 4)
            percentage_Hp_For_Image = 1048 + (138.0f * percentage_Hp);
        else
            percentage_Hp_For_Image = 1528 + (138.0f * percentage_Hp);

        hpBar.transform.position = new Vector3(percentage_Hp_For_Image, hpBar.transform.position.y, hpBar.transform.position.z);

    }
    void MpControl()
    {
        float float_Mp = mp;

        percentage_Mp = (float_Mp / maxMp);
        if (characterID < 4)
            percentage_Mp_For_Image = 1048 + (138.0f * percentage_Mp);
        else
            percentage_Mp_For_Image = 1528 + (138.0f * percentage_Mp);

        mpBar.transform.position = new Vector3(percentage_Mp_For_Image, mpBar.transform.position.y, mpBar.transform.position.z);
    }

    // 設定會顯示在UI上的角色資訊 用ID分配顯示在UI上的資料  不知道怎麼優化rrr 感覺不用重複寫的
    public void SetTeamNumberInfo()
    {
        for (int i = 0; i < 7; i++)
        {
            if (this.characterID == i)
            {
                characterName = characterData[i].characterName;
                maxHp = characterData[i].maxHp;
                hp = characterData[i].hp;
                maxMp = characterData[i].maxMp;
                mp = characterData[i].mp;
                if (hp < 0)
                    hp = 0;
                if (hp > maxHp)
                    hp = maxHp;
                if (mp < 0)
                    mp = 0;
                if (mp > maxMp)
                    mp = maxMp;
            }
        }

        Character_TeamNumber_Text.text = (1 + teamNumber).ToString();

    }

    // 取得會顯示在UI上的角色資訊
    public void GetTeamNumberInfo()
    {
        Character_Name_Text.text = characterName;
        Character_Hp_Text.text = hp.ToString() + " / " + maxHp.ToString();
        Character_Mp_Text.text = mp.ToString() + " / " + maxMp.ToString();
        HpControl();
        MpControl();
    }

    // 重製在進行隊伍編排時用到的暫存數
    public void ResetTeamNumber()
    {
        temporary_TeamNumber = 10;
        temporary_CharacterID = 10;
        if (isClick)
        {
            teamNumber_Panel_Text.text = 0.ToString();
            teamNumber_Panel.SetActive(false);
            isClick = false;
        }

    }

    // 設定隊伍順序
    public void SetTeamNumber()
    {
        // 確認更動隊伍成員的順序
        if (GameMenu_Button_TeamNumber.isTA_Yes)
        {
            teamNumber = temporary_TeamNumber;
            characterID = temporary_CharacterID;
            Debug.Log("順序: " + teamNumber + "ID: " + characterID);
            ResetTeamNumber();
        }
        if (GameMenu_Button_TeamNumber.isTA_No)// 取消更動
        {
            ResetTeamNumber();
            Debug.Log("順序: " + temporary_TeamNumber);
        }

    }

    public void TeamNumberButtonControl()
    {
        characterID_Click = characterID;
    }

    // 被點擊時記錄下自己的順序
    public void TeamNumberButton_GetTemporary_TeamNumber()
    {
        if (GameMenu_Button_TeamNumber.isArranging)
        {
            if (GameMenu_Button_TeamNumber.orderOfTeamMembers == GameMenu_Button_TeamNumber.numberOfMembers) return; // 排到目前隊伍上限的順序不能再點
            if (isClick) return; // 編排中點過的不能再點

            isClick = true;

            // 顯示黃色Panel，顯示順序
            teamNumber_Panel = this.gameObject.transform.GetChild(6).gameObject;
            teamNumber_Panel.SetActive(true);

            teamNumber_Panel_Text = teamNumber_Panel.transform.GetChild(0).GetComponent<Text>();
            teamNumber_Panel_Text.text = (GameMenu_Button_TeamNumber.orderOfTeamMembers + 1).ToString();

            // 暫時記錄當下點選的人物的ID
            temporary_CharacterID = characterID;
            GameMenu_Button_TeamNumber.orderOfTeamMembersID += 1;

            // 暫時記錄當下的點選的人物的隊伍順序
            temporary_TeamNumber = GameMenu_Button_TeamNumber.orderOfTeamMembers;
            GameMenu_Button_TeamNumber.orderOfTeamMembers += 1;
        }
        Debug.Log("暫存順序: " + temporary_TeamNumber + " 暫存人物ID: " + temporary_CharacterID + " 目前順序: " + teamNumber + " 目前人物ID: " + characterID);
    }

    void InitTeamNumberData_Object()
    {
        // 抓取物件
        // characterInfo = characterData.GetComponent<CharacterData>();
        hpBar = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
        mpBar = this.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
        Character_Name_Text = this.gameObject.transform.GetChild(2).GetComponent<Text>();
        Character_Hp_Text = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        Character_Mp_Text = this.gameObject.transform.GetChild(4).GetComponent<Text>();
        Character_TeamNumber_Text = this.gameObject.transform.GetChild(5).GetComponent<Text>();
        // button_TeamArrangement = this.gameObject.transform.parent.GetChild(0).GetComponent<GameObject>();
    }

    // 初始化隊伍成員順序和人物資料的對應
    void InitTeamNumberData()
    {
        for (int i = 0; i < 7; i++)
        {
            if (this.gameObject.tag == "TeamNumber_0" + i.ToString())
            {
                this.characterID = i;
                this.teamNumber = i;
                // Debug.Log(this.characterID);

            }
            // if (this.gameObject.name == "TeamNumber_0" + i.ToString())
            // {
            //     this.characterID = i;
            //     this.teamNumber = i;
            //     Debug.Log(this.characterID);
            // }
        }
    }

}
