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

    public Sprite[] spriteF;
    public Sprite[] spriteM;

    public Vector2 limitPoint1;
    public Vector2 limitPoint2;

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

    private void OnDrawGizmos() {
        Vector2 limitPoint3 = new Vector2(limitPoint2.x, limitPoint1.y);
        Vector2 limitPoint4 = new Vector2(limitPoint1.x, limitPoint2.y);

        // 선을 그림
        Gizmos.color = Color.red;

        Gizmos.DrawLine(limitPoint1, limitPoint3);
        Gizmos.DrawLine(limitPoint3, limitPoint2);
        Gizmos.DrawLine(limitPoint1, limitPoint4);
        Gizmos.DrawLine(limitPoint4, limitPoint2);
    }
}
