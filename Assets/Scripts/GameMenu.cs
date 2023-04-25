using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    public static bool isOpenGameMenu = false;
    public GameObject gameMenu;
    public Button item;
    public Button Skill;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OpenGameMenu();
    }

    public void ItemButtonControl()
    {
        Debug.Log("Test");

    }

    void OpenGameMenu()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameMenu.activeInHierarchy)
            {
                Debug.Log("關閉遊戲選單");
                gameMenu.SetActive(false);
                isOpenGameMenu = false;
            }
            else
            {
                Debug.Log("開啟遊戲選單");
                gameMenu.SetActive(true);
                isOpenGameMenu = true;
            }
        }
    }

}
