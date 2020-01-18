using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤, 접근이 쉽고, 메모리 낭비를 방지.
    public static GameManager gm;
    // long: 양수로 922경 정도 저장 가능
    public static long money;
    
    public GameObject prefabCoffee;

    private void Awake() {
        // 현재의 게임 매니저 스크립트
        gm = this;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // EarnMoney();
        CreateCoffee();
    }

    public void EarnMoney() {
        if (Input.GetMouseButtonDown(0)) {
          money += 1;
          Debug.Log(money);
        }
    }

    void CreateCoffee() {
      if (Input.GetMouseButtonDown(0)) {
          Vector2 mousePosition = Camera.main.ScreenToWorldPoint(
            Input.mousePosition
          );

          // 위치값을 줄때는 각도값을 같이 줘야함.
          Instantiate(prefabCoffee, mousePosition, Quaternion.identity);
      }
    }
}
