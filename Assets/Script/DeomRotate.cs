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
                //Rotate() ���� ���� �̿��� ȸ��
                //1�ʸ��� 360���� �ð�������� ȸ���մϴ�.
                gameObject.transform.Rotate(new Vector3(0f, 360f * Time.deltaTime, 0f));
                break;
            case 1:
                //�ݽð�������� ȸ��
                gameObject.transform.Rotate(new Vector3(45f * Time.deltaTime, -360f * Time.deltaTime, 0f));
                break;
            case 2:
                // Local(�ڱ� �ڽ�) �������� ȸ��, ���࿡ ���������� ������ �ʴ� �������� Ƨ�ϴ�.
                gameObject.transform.Rotate(new Vector3(0f * Time.deltaTime, -360f * Time.deltaTime, 0f), Space.Self);
                break;
            case 3:
                //World(���� �߽�), ������ �������� �����մϴ�.
                gameObject.transform.Rotate(new Vector3(0f * Time.deltaTime, -360f * Time.deltaTime, 0f), Space.World);
                break;
            case 4: //���������� ȸ��
                //���ͷ� �̵�, ȸ�� �ϴ� ��� Add �ڱ��ڽ��� �����ٰ� ���ϴ� ���
                //���ӵ� ȸ�� �Ǵ� �̵��ϴ� ���� ����
                gameObject.transform.Rotate(new Vector3(90f * Time.deltaTime, 90f * Time.deltaTime, 90f * Time.deltaTime), Space.Self);
                break;
            case 5: // ����� ������ ȸ��
                //����� ������(�� ��������)�� ���� ���� �������
                //* ������ ����Ͽ� ���� �����ϴ� ������� ����Ѵ�.
                //* ���길 ����ϰԵǸ� ������ �����Ǿ� �������� �ʴ� ������ ��������.
                //*=�� ���� ����Ͽ� �ڽ��� ���� ���������� �����ϴ� ������� ���
                gameObject.transform.rotation *= Quaternion.Euler(90f * Time.deltaTime, 90f * Time.deltaTime, 90f * Time.deltaTime);
                break;
            default:
                break;
        }
    }
}
