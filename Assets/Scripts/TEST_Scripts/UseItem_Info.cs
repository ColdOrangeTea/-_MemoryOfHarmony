using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem_Info : MonoBehaviour
{
    [SerializeField] public Item item;
    public int USEID = 0;
    public int num;

    public string iname = "";

    void Start()
    {
        Debug.Log("num: " + num + "USEID: " + USEID);
        // Debug.Log("num: " + num);
    }
    void Update()
    {

    }
}
