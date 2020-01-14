using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    public float EnemySpeed = 50.0f;
    private Transform myTransform = null;
    
    public GameObject Explosion = null;
    // Start is called before the first frame update
    void Start() {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 moveAmount = EnemySpeed * Vector3.back *  Time.deltaTime;
        myTransform.Translate(moveAmount);

        // 화면 밖으로 나갔다면 위치를 다시 세팅.
        if (myTransform.position.y < -50.0f) {
            InitPosition();
        }
    }

    // 내 위치를 초기화시켜주는 함수
    void InitPosition() {
        myTransform.position = new Vector3(Random.Range(
            -60.0f, 60.0f), 50.0f, 0.0f
        );
    }

    // 나의 충돌체 영역에 트리거 설정이 된 충돌체가 부딪히면 발생하는 이벤트 함수
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Bullet") {
            // Enemy를 맞췄다면 점수를 100점씩 증가시킴.
            MainControl.Score += 100;

            // 폭발 이펙트 생성
            Instantiate(Explosion, myTransform.position, Quaternion.identity);

            InitPosition();
            Destroy(other.gameObject);
        }
    }
}
