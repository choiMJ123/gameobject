using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Democomponents : MonoBehaviour
{
    //변수처럼 선언을 할수 있다.
    Rigidbody rb; 

    int a;
    private void Start()
    {
        //게임이 시갇욀때 초기화 하는 과정을 통해 컴포넌트 연결 수행
        //연결을 할때 누구의 기능을 가져와서 동작을 시킬것인지 명확하게 생각을 하고 연결
        rb = GetComponent<Rigidbody>(); //(이 클래스를 가지고 있는)의 리지드바디를 가져와 연결
        
        rb.isKinematic = false; // .연산자를 통해 기능 안에 모든 포로퍼티 함수 등 기능을 확인하고 사용할 수 있다.

        //기능을 빼놧을때
        GameObject obj = transform.gameObject; //게임오브젝트 변수에 자기자신을 값으로 넣어줌
        //obj.AddComponent<Joint>(); //AddComponent<추가할 기능>();

        
    }
}
