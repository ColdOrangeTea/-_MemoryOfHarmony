using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData_ID_01 : UnitData
{
    private UnitData enemyData;
    public EnemyData_Info enemyData_Info;

    // 所有空物件中的子物件的陣列
    public EnemyData_Info[] enemyData_AllInfo;

    // 父物件(內含具有 EnemyData_Info 組件的子物件) 要手動指定物件
    public GameObject enemyData_InfoEmpty;

    // 傳遞資料給 EnemyData_Info
    public override void SetUnitData()
    {
        Debug.Log("敵人資料建立");
        enemyData_AllInfo = enemyData_InfoEmpty.GetComponentsInChildren<EnemyData_Info>();
        foreach (EnemyData_Info a in enemyData_AllInfo)
        {
            EnemyData_Info u = a;
            if (u.GetComponent<EnemyData_Info>())
            {
                // Debug.Log(u.GetComponent<CharacterData_Info>());
                if (u.GetComponent<EnemyData_Info>().enemyID == enemyID)
                {
                    if (enemyID == 0)
                        enemyData = GetComponent<EnemyData_ID_00>();
                    if (enemyID == 1)
                        enemyData = GetComponent<EnemyData_ID_01>();

                    enemyData_Info = u.GetComponent<EnemyData_Info>();
                    enemyData_Info.enemyData = enemyData;

                    enemyData_Info.enemyMember = new UnitData[7];
                    enemyData_Info.enemyMember[enemyData_Info.enemyID] = enemyData_Info.enemyData;
                }
            }
        }
    }

    public override void InitUnitData()
    {
        characterID = 10;

        unitName = "璃弓石";

        // baseUnitData 陣列的說明:
        // 0: MaxHp   1: Hp  2: MaxMp   3: Mp   4: Attack  5: Defence    6: Speed */
        baseUnitData = new int[] {
            800,800,200,200,
            50,50,50};

        /* totalUnitData 陣列的說明:    
        0: totalMaxHp   1: totalHp  2: totalMaxMp   3: totalMp
        4: totalAttack  5: totalDefence    6: totalSpeed */

        totalUnitData = new int[] {
        baseUnitData[0],baseUnitData[1],baseUnitData[2],baseUnitData[3],
        baseUnitData[4],baseUnitData[5],baseUnitData[6]};
    }
}
