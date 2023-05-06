using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleMenuControl : MonoBehaviour
{
    public void StartButton()
    {
        Debug.Log("開始遊戲");
        SceneManager.LoadScene("WorldMap");
    }

    public void ReplayButton()
    {
        Debug.Log("回到標題");
        SceneManager.LoadScene("Title");
    }

    public void QuitButton()
    {
        Debug.Log("結束遊戲");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
