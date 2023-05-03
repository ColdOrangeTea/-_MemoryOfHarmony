using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected string itemName;
    protected int ID;
    // 對應ID的子物件資料
    public UseItem_Info ui;

    // 所有空物件中的子物件的陣列
    public UseItem_Info[] allUI;
    // 空物件
    public GameObject NT;
    void Awake()
    {
        AAA();
        Use();
        allUI = NT.GetComponentsInChildren<UseItem_Info>();
        foreach (UseItem_Info a in allUI)
        {
            UseItem_Info u = a;
            if (u.GetComponent<UseItem_Info>())
            {
                // Debug.Log(u.GetComponent<UseItem_Info>());
                if (u.GetComponent<UseItem_Info>().USEID == ID)
                {
                    ui = u.GetComponent<UseItem_Info>();
                    ui.num = ID;
                    ui.iname = itemName;
                }
            }
        }
    }

    private void AAA()
    {
        // Debug.Log("動阿 為甚麼不動!!");
    }
    public abstract void Use();
}
