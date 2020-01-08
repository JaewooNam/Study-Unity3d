using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    public float EnemySpeed = 50.0f;
    private Transform myTransform = null;
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
            myTransform.position = new Vector3(Random.Range(
                -60.0f, 60.0f), 50.0f, 0.0f
            );
        }
    }
}
