using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deon_Player : MonoBehaviour
{
    public Transform ball; //���� ��ġ�� ��Ʈ�� �մϴ�.
    public Transform ArmsBallPos; //���� ó�� ��ġ
    public Transform UpPos; //���� �Ӹ� ��ġ
    public Transform RingPos; //���� ���� ���� ��ġ
    public float sin; //������ ��
    public bool isBallHand = false; //���� �տ� �ִ��� Ȯ���ϴ� ��
    public bool isBallFly = false; //���� ���󰡰��ִ��� Ȯ���ϴ� ��
    public float T = 0; //���󰡴� �ð�/�ӵ�

    private void Start()
    {
        //������ ���۵Ǹ� ���� ��ġ�� �÷��̾�� ��ġ�� ��ġ ��ŵ�ϴ�.
        ball.transform.position = ArmsBallPos.position;
        //ball�� ��ɿ� �����Ͽ� ����� �ϳ� �����ϴ�,
        //Kinematic�� ������ ������ �ȹް� �ϴ� ����Դϴ�.
        ball.transform.GetComponent<Rigidbody>().isKinematic = true;
        isBallHand = true;//�տ� ��ġ�ϰ� �Ǿ� true�� ����

    }
    private void Update()
    {
        //���� �������� �����̴� �÷��̾ Ű���带 ���� �̵��ϴ� �ڵ�
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //���� �����Ͽ� ������ �����̴� �ڵ� ���� * �ӵ� * �ʴ� ���� ������ ���� ����
        transform.position += direction * 10f * Time.deltaTime;
        //�̵��ϴ� ������ �ٶ󺸰� �ϱ�
        transform.LookAt(transform.position + direction);

        if (isBallHand)
        {
            //�����̽��� Ű�Է� �ѹ��� ������ �ֽ��ϴ�.
            if (Input.GetKey(KeyCode.Space)) //������ �ִµ���
            {
                //�����̽��ٸ� �������� ���� ��ġ�� �Ӹ�����
                ball.position = UpPos.position;

                //�����̽��ٸ� �����µ��� �÷��̾�� �������� �ٶ󺸰� �մϴ�.
                transform.LookAt(RingPos.position);
            }
            else //���� �տ��� ������ �����̽��ٸ� ������ �ʴ´ٸ�
            {
                //���Ʒ��� �Դ� ���� �ϰ� �ϱ� Mathf.abs�� ���� ���밪���� �����
                //Mathf.Sin �׷����� �׸��ϴ�. ���밪���� �ٿ�� �Ǵ� ����� ����� �ݴϴ�.
                ball.position = ArmsBallPos.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * sin));
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) //�����̽��ٸ� �����ٰ� �� ��� �ѹ��� if�� �����ϴ�.
        {
            isBallHand = false; //���� �տ� ���ٰ� ���ݴϴ�.
            isBallFly = true; //���� ���󰡰� �ִ� ����
            T = 0; //���� ��ġ�� �ٽ� �ʱ�ȭ
        }

        //���� ������ ���
        if (isBallFly) //���� ���ư��� �����ΰ��
        {
            T += Time.deltaTime; //�����Ӵ� �̵��ӵ��� ����Ͽ� ���մϴ�.
            float duration = 0.5f; //����/�����ð�
            float t1 = T / duration;

            Vector3 aPoint = UpPos.position;
            Vector3 bPoint = RingPos.position;
            //��� ��ġ, ��ǥ ��ġ �ӵ�)
            Vector3 pos = Vector3.Lerp(aPoint, bPoint, t1);
            //���� ���ڷ� ���󰡴� sin Ŀ�긦 �׷� �����ϴ�.
            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t1 * 3.14f);
            ball.position = pos + arc; //������ ��� ���մϴ�.

            //���� �ٽ� ���� �۵��ϰ� ����
            if(t1 >= 1) //1���� Ŀ���� ��� ��ǥ�� ������ �ǹ� �մϴ�.
            {
                isBallFly = false;
                //�����ִ� rigidbody��ɿ� �����Ͽ� isKonematic(����ȿ���� ���� ���� ����)�� �ٽ� ��Ȱ��ȭ�մϴ�.
                ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
    //Ʈ���Ÿ� �̿��Ͽ� ���� �浹�� üũ�ϰ� ���� �ٽ� �տ� ������� �մϴ�.
    //Enter�� ���� �浹�� ������ ���մϴ�.
    private void OnTriggerEnter(Collider other)
    {
        //!�� �ٿ� ���� �����Ͽ� false���������� ����
        //&& : �׸���
        //�տ� ���� �ʰ� ���� ���� ������ ��������
        if (!isBallHand && !isBallFly)
        {
            isBallHand = true;
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }


}
