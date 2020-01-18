using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 0 : 왼쪽 클릭 = 모바일에서 터치와 같음
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
