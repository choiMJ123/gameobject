using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deon_Player : MonoBehaviour
{
    public Transform ball; //공의 위치를 컨트롤 합니다.
    public Transform ArmsBallPos; //공의 처음 위치
    public Transform UpPos; //공의 머리 위치
    public Transform RingPos; //공을 넣을 링의 위치
    public float sin; //사인파 값
    public bool isBallHand = false; //공이 손에 있는지 확인하는 값
    public bool isBallFly = false; //공이 날라가고있는지 확인하는 값
    public float T = 0; //날라가는 시간/속도

    private void Start()
    {
        //게임이 시작되면 공의 위치를 플레이어손 위치에 위치 시킵니다.
        ball.transform.position = ArmsBallPos.position;
        //ball의 기능에 접근하여 기능을 하나 막습니다,
        //Kinematic은 물리의 영향을 안받게 하는 기능입니다.
        ball.transform.GetComponent<Rigidbody>().isKinematic = true;
        isBallHand = true;//손에 위치하게 되어 true로 변경

    }
    private void Update()
    {
        //백터 기준으로 움직이는 플레이어를 키보드를 눌러 이동하는 코드
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //값을 대입하여 실제롤 움직이는 코드 방향 * 속도 * 초당 이전 프레임 간격 단위
        transform.position += direction * 10f * Time.deltaTime;
        //이동하는 방향을 바라보게 하기
        transform.LookAt(transform.position + direction);

        if (isBallHand)
        {
            //스페이스바 키입력 한번을 받을수 있습니다.
            if (Input.GetKey(KeyCode.Space)) //누르고 있는동안
            {
                //스페이스바를 눌렀을때 공의 위치는 머리위로
                ball.position = UpPos.position;

                //스페이스바를 누르는동안 플레이어는 던질곳을 바라보게 합니다.
                transform.LookAt(RingPos.position);
            }
            else //공이 손에는 있지만 스페이스바를 누르지 않는다면
            {
                //위아래로 왔다 갔다 하게 하기 Mathf.abs는 값을 절대값으로 만들고
                //Mathf.Sin 그래프를 그립니다. 절대값으로 바운드 되는 모양을 만들어 줍니다.
                ball.position = ArmsBallPos.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * sin));
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) //스페이스바를 누르다가 땐 경우 한번만 if를 돌립니다.
        {
            isBallHand = false; //공이 손에 없다고 해줍니다.
            isBallFly = true; //공이 날라가고 있는 상태
            T = 0; //공의 위치를 다시 초기화
        }

        //공을 던지는 기능
        if (isBallFly) //공이 날아가는 상태인경우
        {
            T += Time.deltaTime; //프레임당 이동속도를 계산하여 더합니다.
            float duration = 0.5f; //지속/지연시간
            float t1 = T / duration;

            Vector3 aPoint = UpPos.position;
            Vector3 bPoint = RingPos.position;
            //출발 위치, 목표 위치 속도)
            Vector3 pos = Vector3.Lerp(aPoint, bPoint, t1);
            //공이 일자로 날라가니 sin 커브를 그려 날립니다.
            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t1 * 3.14f);
            ball.position = pos + arc; //직선과 곡선을 더합니다.

            //공이 다시 정상 작동하게 만듦
            if(t1 >= 1) //1보다 커지는 경우 목표에 도착을 의미 합니다.
            {
                isBallFly = false;
                //공에있는 rigidbody기능에 접근하여 isKonematic(물리효과를 받지 않음 상태)를 다시 비활성화합니다.
                ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
    //트리거를 이용하여 공의 충돌을 체크하고 공을 다시 손에 쥐어지게 합니다.
    //Enter의 뜻은 충돌한 순간을 말합니다.
    private void OnTriggerEnter(Collider other)
    {
        //!를 붙여 값을 부정하여 false상태인지를 묻고
        //&& : 그리고
        //손에 있지 않고 공이 땅에 떨어진 상태인지
        if (!isBallHand && !isBallFly)
        {
            isBallHand = true;
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }


}
