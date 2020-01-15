using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterControl : MonoBehaviour {

    [Header("이동관련 속성")]
    [Tooltip("기본이동속도")]
    public float MoveSpeed = 2.0f;
    [Tooltip("달리기속도")]
    public float RunSpeed = 3.5f;
    public float DirectionRotateSpeed = 100.0f;
    public float BodyRotateSpeed = 2.0f; // 몸통의 방향을 변경하기 위한 속도

    [Range(0.01f, 5.0f)]
    public float VelocityChangeSpeed = 0.1f;
    private Vector3 CurrentVelocity = Vector3.zero;
    private Vector3 MoveDirection = Vector3.zero;
    private CharacterController myCharacterController = null;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    // Start is called before the first frame update
    void Start() {
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void OnAnimatorMove() {
      
    }

    void Move() {
        // 현재 메인카메라 게임 오브젝트의 트랜스폼 컴포넌트를 가져옴
        Transform CameraTransform = Camera.main.transform;
        // 실제 카메라가 바라보는 방향이 월드 상에서는 어떤 방향인지 얻어옴
        Vector3 forward = CameraTransform.TransformDirection(Vector3.forward);
        forward.y = 0.0f;

        // y축은 무시.
        Vector3 right = new Vector3(forward.z, 0.0f, -forward.x);

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // 우리가 이동하고자하는 방향
        Vector3 targetDirection = horizontal * right + vertical * forward;

        // 현재 이동하는 방향에서 원하는 방향으로 조금씩 회전
        MoveDirection = Vector3.RotateTowards(MoveDirection, targetDirection,
            DirectionRotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000.0f);

        // 방향이기떄문에 크기는 없애고 방향만 가져옴.
        MoveDirection = MoveDirection.normalized;
        
        float speed = MoveSpeed;

        // 이번 프레임에 움직일 양.
        Vector3 moveAmount = (MoveDirection * speed * Time.deltaTime);

        // 실제 이동하면서 충돌 되었는지 확인.
        collisionFlags = myCharacterController.Move(moveAmount);
    }

    private void OnGUI() {

        GUILayout.Label("현재 속도 : " + GetVelocitySpeed().ToString());
        // 캐릭터 컨트롤러 컴포넌트를 찾았고, 현재 내 캐릭터의 이동속도가 0이 아니라면,
        if (myCharacterController != null && myCharacterController.velocity != Vector3.zero) {
            GUILayout.Label("current Velocity Vector: ", myCharacterController.velocity.ToString());
            GUILayout.Label("current Velocity Magnitude: ", myCharacterController.velocity.magnitude.ToString());
        }
    }

    // 현재 내 캐릭터의 이동속도를 얻어온다.
    float GetVelocitySpeed() {
        if (myCharacterController.velocity == Vector3.zero) {
            CurrentVelocity = Vector3.zero;
        } else {
            Vector3 goalVelocity = myCharacterController.velocity;
            goalVelocity.y = 0.0f;

            // fixedDeltaTime : ???
            CurrentVelocity = Vector3.Lerp(CurrentVelocity, goalVelocity,
                VelocityChangeSpeed * Time.fixedDeltaTime);
        }

        return CurrentVelocity.magnitude;
    }

}
