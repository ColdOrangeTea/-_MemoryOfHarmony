using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Encounter : MonoBehaviour
{
    public string battleField_Name = "BattleFeid_00";

    public static bool isEncounterEnemy = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isEncounterEnemy = true;
            GoToBattleField();
        }
    }

    void GoToBattleField()
    {
        SceneManager.LoadScene(battleField_Name);
    }
}
