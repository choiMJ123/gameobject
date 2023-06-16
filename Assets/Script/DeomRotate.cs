using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeomRotate : MonoBehaviour
{
    public int Type = 0;
    private void Update()
    {
        switch (Type)
        {
            case 0:
                //Rotate() 백터 축을 이용한 회전
                //1초마다 360도를 시계방향으로 회전합니다.
                gameObject.transform.Rotate(new Vector3(0f, 360f * Time.deltaTime, 0f));
                break;
            case 1:
                //반시계방향으로 회전
                gameObject.transform.Rotate(new Vector3(45f * Time.deltaTime, -360f * Time.deltaTime, 0f));
                break;
            case 2:
                // Local(자기 자신) 기준으로 회전, 만약에 뒤집어지면 원하지 않는 방향으로 튑니다.
                gameObject.transform.Rotate(new Vector3(0f * Time.deltaTime, -360f * Time.deltaTime, 0f), Space.Self);
                break;
            case 3:
                //World(공간 중심), 월드축 기준으로 반응합니다.
                gameObject.transform.Rotate(new Vector3(0f * Time.deltaTime, -360f * Time.deltaTime, 0f), Space.World);
                break;
            case 4: //백터축으로 회전
                //백터로 이동, 회전 하는 경우 Add 자기자신의 값에다가 더하는 방식
                //연속된 회전 또는 이동하는 것을 보임
                gameObject.transform.Rotate(new Vector3(90f * Time.deltaTime, 90f * Time.deltaTime, 90f * Time.deltaTime), Space.Self);
                break;
            case 5: // 사원수 축으로 회전
                //사원수 짐벌락(축 증발현상)을 막는 연산 방식으로
                //* 연산을 사용하여 값을 대입하는 방법으로 사용한다.
                //* 연산만 사용하게되면 각도가 고정되어 움직이지 않는 현상이 보여진다.
                //*=을 같이 사용하여 자신의 값에 지속적으로 연산하는 방식으로 사용
                gameObject.transform.rotation *= Quaternion.Euler(90f * Time.deltaTime, 90f * Time.deltaTime, 90f * Time.deltaTime);
                break;
            default:
                break;
        }
    }
}
