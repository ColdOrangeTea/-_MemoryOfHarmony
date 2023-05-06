using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu_Button_Action : MonoBehaviour
{

    public event System.EventHandler<StatusEventargs> StatusChanging;
    void Start()
    {

    }

    void Update()
    {

    }

    void Attack(int damageValue)
    {

    }

    public void AttackButtonControl()
    {
        int damageValue = 10;
        Debug.Log("攻擊");
        if (this.StatusChanging != null)
        {
            StatusChanging(this, new StatusEventargs(StatusEventargs.ActType.Damage, "Player", damageValue));

        }
    }
    public void SkillButtonControl()
    {
        Debug.Log("技能");
    }
    public void ItemButtonControl()
    {
        int healValue = 10;
        Debug.Log("物品");
        if (this.StatusChanging != null)
        {
            StatusChanging(this, new StatusEventargs(StatusEventargs.ActType.Heal, "Player", healValue));

        }
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
