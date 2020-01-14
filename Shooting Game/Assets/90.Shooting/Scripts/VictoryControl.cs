using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryControl : MonoBehaviour
{
    private void OnGUI() {
        Debug.Log("Hello WOrld!");
        float CenterX = Screen.width * 0.5f;
        float CenterY = Screen.height * 0.5f;
        Rect ButtonRect = new Rect(CenterX - 100.0f, CenterY - 100.0f, 
          200.0f, 200.0f);
        
        // You Win 이라고 써있는 버튼을 클릭했다면, 
        if (GUI.Button(ButtonRect, "You WIN !!") == true) {
            SceneManager.LoadScene("Level1");
        }
    }
}
