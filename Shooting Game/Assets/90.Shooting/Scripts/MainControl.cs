using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    static public int Score = 0;
    static public int Life = 3;
    public GUISkin mySkin = null;

    public void OnGUI() {
        // change skin 
        GUI.skin = mySkin;
        // 위치 (x, y), 폭, 높이
        Rect labelRect1 = new Rect(10.0f, 10.0f, 400.0f, 100.0f);
        // static이라 클래스이름으로 변수를 접근
        GUI.Label(labelRect1, "SCORE : " + MainControl.Score);
        Rect labelRect2 = new Rect(10.0f, 110.0f, 400.0f, 100.0f);
        GUI.Label(labelRect2, "LIFE: " + MainControl.Life);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainControl.Score > 500) {
            MainControl.Score = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }
    }
}
