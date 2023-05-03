using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UseItem_Info_Display : MonoBehaviour
{
    public UseItem_Info useItem_Info;
    public int USEID = 0;
    public int num;
    public string iname = "";

    public Text USEID_Text;

    void Start()
    {
        useItem_Info = GetComponent<UseItem_Info>();
        USEID_Text = GetComponent<Text>();
        GetInfo();
        DisplayInfo();
        Debug.Log("num: " + num + "USEID: " + USEID);

    }
    void DisplayInfo()
    {
        USEID_Text.text = USEID.ToString() + "   " + num + iname;
    }
    void GetInfo()
    {
        USEID = useItem_Info.USEID;
        num = useItem_Info.num;
        iname = useItem_Info.iname;
    }
    void Update()
    {

    }
}
