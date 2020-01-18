using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeControl : MonoBehaviour
{
    // Sprite Component에 접근해서 스프라이트 항목을 스크립트에서 수정.
    SpriteRenderer spr;
    public Employee info;
    // 이름, 성별, 능력치 (기획, 프로그래밍, 디자인, 사운드), 월급, 체력

    public float speed;

    public Vector2 prevPosition;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        info.hp = 100;
        // info.gender = Gender.Female;

        StartCoroutine(EarnMoneyAuto());
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        SpriteChange();
    }

    IEnumerator EarnMoneyAuto() {
        while (true) {
            // static으로 햇기때문에 접근가능 (.money)
            GameManager.money += 1;

            // 괄호 안에 입력한 숫자만큼 기다렸다가 다음 코드를 실행.
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator Move() {
        while (true) {
            float x = transform.position.x + Random.Range(-2f, 2f);
            float y = transform.position.y + Random.Range(-2f, 2f);

            // 새로운 벡터2 타입의 변수를 넣을 수 있다.
            Vector2 target = new Vector2(x, y);
            target = CheckTarget(target);

            // 현재 위치를 저장, 타겟으로 움직이기 전에 전의 위치를 기억
            prevPosition = transform.position;
          
            // 목표 지점에 거의 도착했을때 새로운 위치를 줌. (for 자연스러움), return 남은 거리 값
            while (Vector2.Distance(transform.position, target) > 0.01f) {
                // 실제 이동 (현재위치, 목표위치, 속도)
                transform.position = Vector2.MoveTowards(transform.position,
                    target, speed);
                yield return null;
            }

            // 도착 했을 때 1초 대기시킴
            yield return new WaitForSeconds(1.0f);
        }
    }

    Vector2 CheckTarget(Vector2 currentTarget) {
        Vector2 temp = currentTarget;
        
        // 위치 수정

        // 왼쪽으로 너무 치우침
        if (currentTarget.x < GameManager.gm.limitPoint1.x) {
            temp = new Vector2(currentTarget.x + 4, temp.y);
        } else if (currentTarget.x > GameManager.gm.limitPoint2.x) {
            temp = new Vector2(currentTarget.x - 4, temp.y);
        }

        // 너무 위로 올라감
        if (currentTarget.y > GameManager.gm.limitPoint1.y) {
            temp = new Vector2(temp.y, currentTarget.y - 4);
        } else if (currentTarget.y < GameManager.gm.limitPoint2.y) {
            temp = new Vector2(temp.y, currentTarget.y + 4);
        }

        return temp;
    }

    void SpriteChange() {
        Sprite[] set = null;
        // 0: front, 1: back, 2: side
        if (info.gender == Gender.Female) {
            set = GameManager.gm.spriteF;
        } else {
            set = GameManager.gm.spriteM;
        }

        // 현재 위치 값 - 전의 위치 값
        // 형 변환
        Vector2 abs = (Vector2)transform.position - prevPosition;

        // x 값으로 움직인 절대 값 > y 값으로 움직인 절대 값
        if (Mathf.Abs(abs.x) > Mathf.Abs(abs.y)) {
            // 왼쪽 또는 오른쪽으로
            spr.sprite = set[2];
            if (transform.position.x > prevPosition.x) {
                spr.flipX = false;
            } else if (transform.position.x < prevPosition.x) {
                spr.flipX = true;
            }
        } else {
            // y 값으로 움직인 값이 더 큰 경우
            spr.flipX = false;
            if (transform.position.y > prevPosition.y) { // 위
                spr.sprite = set[1];
            } else if (transform.position.y < prevPosition.y) { // 아래
                spr.sprite = set[0];
            }
        }
    }
}

public enum Gender
{
    Female = 0,
    Male = 1
}

[System.Serializable]
public class Employee
{
    public string name;
    public Gender gender;

    public float design;
    public float programming;
    public float art;
    public float sound;
    public float hp;
    public long salary;
    
}