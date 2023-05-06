using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSystem : MonoBehaviour
{
    [SerializeField]
    BattleMenu_Button_Action battleSystem;

    public int playerHp = 100;

    void Start()
    {
        battleSystem = GetComponent<BattleMenu_Button_Action>();
        battleSystem.StatusChanging += OnStatusChanging;
    }
    public void OnStatusChanging(object sender, StatusEventargs e)
    {
        print($"{sender}\t{e.actType} {e.target} {e.amount}");
        if (e.target == "Player")
        {
            if (e.actType == StatusEventargs.ActType.Heal)
            {
                playerHp += e.amount;
            }
            else if (e.actType == StatusEventargs.ActType.Damage)
            {
                playerHp -= e.amount;
            }
        }
    }
}
public class StatusEventargs : System.EventArgs
{
    public ActType actType;
    public string target;
    public int amount;
    public enum ActType
    {
        Damage,
        Heal
    }
    public StatusEventargs(ActType act, string unitData, int value)
    {
        actType = act;
        target = unitData;
        amount = value;
    }

}
