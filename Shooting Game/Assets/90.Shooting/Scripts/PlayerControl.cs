using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // 플레이어 비행체의 이동속도
    public float Speed = 15.0f;

    // 플레이어 게임오브젝트의 트랜스폼 컴포넌트
    private Transform myTransfrom = null;
    // Start is called before the first frame update
    void Start()
    {
        // 이 컴포넌트를 얻어오겠다.
        myTransfrom = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
