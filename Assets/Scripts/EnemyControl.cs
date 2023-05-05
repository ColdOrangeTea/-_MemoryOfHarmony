using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject game_area;
    public GameObject enemy_Prefab;

    public int enemy_Count = 0;
    public int enemy_Limit = 100;
    public int enemy_Per_Frame = 1;
    public float spawn_Circle_radius = 100.0f;
    public float death_Circle_radius = 120.0f;

    public float fastest_Speed = 10.0f;
    public float slowest_Speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MaintainPopulation();
    }

    void MaintainPopulation()
    {
        if (enemy_Count < enemy_Limit)
        {
            for (int i = 0; i < enemy_Per_Frame; i++)
            {
                Vector3 position = GetRandomPosition();
            }
        }
    }

    // 網址:https://www.youtube.com/watch?v=u5ieakSbXjA

    Vector3 GetRandomPosition()
    {
        Vector3 position = Random.insideUnitCircle.normalized;
        position *= spawn_Circle_radius;
        position += game_area.transform.position;

        return position;
    }


}
