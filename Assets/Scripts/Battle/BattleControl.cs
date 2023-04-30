using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleControl : MonoBehaviour
{

    // ---HP、MP的控制---
    public Image hpBar;
    public float maxHp = 100;
    public float hp = 100;
    // 計算Hp比例
    public float percentage_Hp = 1.0f;
    // HpBar全長180px 在畫面中到血槽底部時是(38,n)、滿血的位置是(218,n) 
    public float percentage_Hp_For_Image = 180.0f;
    public Image mpBar;
    public float maxMp = 100;
    public float mp = 100;
    // 計算Mp比例
    public float percentage_Mp = 1.0f;
    // MpBar全長180px 在畫面中到血槽底部時是(38,n)、滿血的位置是(218,n) 
    public float percentage_Mp_For_Image = 180.0f;
    // ---按鈕的控制---
    public Button button_Attack;
    public Button button_Skill;
    public Button button_Item;
    public Button button_Equip;
    public Button button_Flee;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HpControl();
        MpControl();
    }

    public void AttackButtonControl()
    {
        Debug.Log("攻擊");
    }
    public void SkillButtonControl()
    {
        Debug.Log("技能");
    }
    public void ItemButtonControl()
    {
        Debug.Log("物品");
    }
    public void EquipButtonControl()
    {
        Debug.Log("裝備");
    }
    public void FleeButtonControl()
    {
        Debug.Log("逃跑");
    }
    void HpControl()
    {
        if (hp < 0)
            hp = 0;
        percentage_Hp = (hp / maxHp);
        percentage_Hp_For_Image = 38 + (180.0f * percentage_Hp);
        hpBar.transform.position = new Vector3(percentage_Hp_For_Image, hpBar.transform.position.y, hpBar.transform.position.z);
    }
    void MpControl()
    {
        if (mp < 0)
            mp = 0;
        percentage_Mp = (mp / maxMp);
        percentage_Mp_For_Image = 38 + (180.0f * percentage_Mp);
        mpBar.transform.position = new Vector3(percentage_Mp_For_Image, mpBar.transform.position.y, mpBar.transform.position.z);
    }
}
