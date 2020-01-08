using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    // 총알을 위로 보내기 위한 컨트롤러
    public float BulletSpeed = 100.0f;
    // 트랜스폼 컴포넌트를 캐싱한다.
    private Transform myTransform = null;
    // Start is called before the first frame update
    void Start() {
        // 만약 똑같은 컴포넌트가 여러개 있을 경우? -> 가장 상단에 있는 것을 가져온다.
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        Vector3  moveAmount = BulletSpeed * Vector3.up * Time.deltaTime;
        myTransform.Translate(moveAmount);

        // 화면 밖으로 나가면 사라지게 한다.
        if (myTransform.position.y > 60.0f) {
            // 이 스크립트가 지금 붙어있는 게임 오브젝트
            Destroy(gameObject); // gameObject = BulletPrefab
        }
    }
}
