using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Democomponents : MonoBehaviour
{
    //����ó�� ������ �Ҽ� �ִ�.
    Rigidbody rb; 

    int a;
    private void Start()
    {
        //������ �ð��߶� �ʱ�ȭ �ϴ� ������ ���� ������Ʈ ���� ����
        //������ �Ҷ� ������ ����� �����ͼ� ������ ��ų������ ��Ȯ�ϰ� ������ �ϰ� ����
        rb = GetComponent<Rigidbody>(); //(�� Ŭ������ ������ �ִ�)�� ������ٵ� ������ ����
        
        rb.isKinematic = false; // .�����ڸ� ���� ��� �ȿ� ��� ������Ƽ �Լ� �� ����� Ȯ���ϰ� ����� �� �ִ�.

        //����� ���J����
        GameObject obj = transform.gameObject; //���ӿ�����Ʈ ������ �ڱ��ڽ��� ������ �־���
        //obj.AddComponent<Joint>(); //AddComponent<�߰��� ���>();

        
    }
}
