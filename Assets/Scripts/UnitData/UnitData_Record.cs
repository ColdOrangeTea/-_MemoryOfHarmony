using System.Collections;
using System.Collections.Generic;
using UnityEngine;
struct BaseUnitData
{
    // [Header("進戰鬥前記錄的數值")]
    public int characterID;
    public string[] characterName;
    public int[] teamNumber;
    /* equipID 陣列的說明: weaponID    armorID   accessoriesID 
    在同性質資料的陣列用角色ID取得該角色的資料*/
    public int[] weaponID;
    public int[] armorID;
    public int[] accessoriesID;

    [Header("角色資料 原數值")]
    public int[] baseUnitDataMaxHp;
    public int[] baseUnitDataMaxMp;
    public int[] baseUnitDataHp;
    public int[] baseUnitDataMp;
    public int[] baseUnitDataAttack;
    public int[] baseUnitDataDefence;
    public int[] baseUnitDataSpeed;
}
public class UnitData_Record : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
