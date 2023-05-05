using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu_Button_Action : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

}
