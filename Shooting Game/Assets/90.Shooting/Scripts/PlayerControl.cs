using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // 플레이어 비행체의 이동속도
    public float Speed = 15.0f;

    // 플레이어 게임오브젝트의 트랜스폼 컴포넌트
    private Transform myTransform = null;

    // 플레이어가 생성하게될 원본 bullet prefab
    public GameObject BulletPrefab = null;

    // Start is called before the first frame update
    void Start() {
        // 트랜스폼 컴포넌트를 캐싱.
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        // Move
        // -1 ~ 1 왼쪽 화살키(-1) 오른쪽 화살키 (1)
        float axis = Input.GetAxis("Horizontal");
        
        // 매 프레임 당 이 게임 오브젝트가 우리가 원하는 속도와 방향으로 이동하는 양
        Vector3 moveAmount = axis * Speed * -Vector3.right * Time.deltaTime;

        myTransform.Translate(moveAmount);

        // Shooting

        /*
          GetKey: 어떤키가 눌렸냐, 누르고만 있냐 찾는것
          GetKeyDown : 눌러졌을떄
          GetKeyUp : 눌렀다까 떼어졌을떄
        */
        if (Input.GetKeyDown(KeyCode.Space) == true) {
            // 객체를 인스턴스화 한다. (cloning)
            // bullet prefab을 현재 내가 위치에서 회전 시키지 않은 상태로 인스턴스화 시킴.
            Instantiate(BulletPrefab, myTransform.position, Quaternion.identity);
        }
    }
}
