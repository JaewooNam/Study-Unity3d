﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // 플레이어 비행체의 이동속도
    public float Speed = 15.0f;

    // 플레이어 게임오브젝트의 트랜스폼 컴포넌트
    private Transform myTransfrom = null;
    // Start is called before the first frame update
    void Start() {
        // 트랜스폼 컴포넌트를 캐싱.
        myTransfrom = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        // -1 ~ 1 왼쪽 화살키(-1) 오른쪽 화살키 (1)
        float axis = Input.GetAxis("Horizontal");
        
        // 매 프레임 당 이 게임 오브젝트가 우리가 원하는 속도와 방향으로 이동하는 양
        Vector3 moveAmount = axis * Speed * -Vector3.right * Time.deltaTime;

        myTransfrom.Translate(moveAmount);
    }
}
