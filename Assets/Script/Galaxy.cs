using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    //���� : ��ȥ�� ���°�
    //���� : ������ ���°�
    //�¾��� ����, �츮 �༺���� ����, ����
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject earth;
    public GameObject Venus1;
    public GameObject Venus2;
    public GameObject Venus3;
    public GameObject Venus4;
    public GameObject Venus5;


    private void Update()
    {
        //Rotate�� vector������ ȸ���մϴ�. y�� �������� 360�� ���� �� �̴�.
        transform.Rotate(Vector3.up * 360f * Time.deltaTime);
        //RotateAround�� Ÿ���� �������� ȸ���� �մϴ�.
        Mercury.transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        Mercury.transform.Rotate(Vector3.up * 360f * Time.deltaTime);
        Venus.transform.RotateAround(transform.position, Vector3.up, 10 * Time.deltaTime);
        Venus.transform.Rotate(Vector3.up * 360f * Time.deltaTime);
        earth.transform.RotateAround(transform.position, Vector3.up, 30 * Time.deltaTime);
        earth.transform.Rotate(Vector3.up * 360f * Time.deltaTime);
        Venus1.transform.RotateAround(transform.position, Vector3.up, 6 * Time.deltaTime);
        Venus1.transform.Rotate(Vector3.up * 360f * Time.deltaTime);
        Venus2.transform.RotateAround(transform.position, Vector3.up, 40 * Time.deltaTime);
        Venus2.transform.Rotate(Vector3.up * 360f * Time.deltaTime);
        Venus3.transform.RotateAround(transform.position, Vector3.up, 5 * Time.deltaTime);
        Venus3.transform.Rotate(Vector3.up * 360f * Time.deltaTime);
        Venus4.transform.RotateAround(transform.position, Vector3.up, 3 * Time.deltaTime);
        Venus4.transform.Rotate(Vector3.up * 360f * Time.deltaTime);
        Venus5.transform.RotateAround(transform.position, Vector3.up, 60 * Time.deltaTime);
        Venus5.transform.Rotate(Vector3.up * 360f * Time.deltaTime);

    }
}
