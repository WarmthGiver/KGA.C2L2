using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletControl : MonoBehaviour
{
    //�׽�Ʈ��
    [SerializeField] float speed;    
    Vector3 start;
    Vector3 end;

    private void Start()
    {

    }
    void Update()
    {
        end = new Vector3(0,0,0);//�ϴ� �÷��̾� ��ǥ�� ��ǥ ������ 0,0,0 �̶� �Ȳ��̰� ��
        start = transform.position;//������ ���⼱ ������ �Ѿ� �����ߵǼ� ������ ������
        Vector3 newPos = start - end;//�������� ������ �Ÿ� �����̶� �ؾ��ϳ�       
        var rotZ = GetAngle(start, end);//���� �� ���� ���ϴ� �޼��� 

        Vector3 vec = new Vector3(Mathf.Cos(rotZ), Mathf.Sin(rotZ));
        //������ ��� ���ϱ� �� ������Ʈ���� ���� ���� �Ҵ�
        //Mathf.Cos(����)= x  ,  Mathf.Sin(����) = y
        transform.Translate(vec * speed * Time.deltaTime);
        //�Ѿ� �ӵ�       
        transform.rotation = Quaternion.Euler(0, 0, rotZ-180);
        //z�� ���� �̻ڰ� ������ �����̼��� �� ������ �Ѿ� ������ ����������


        //transform.position += newPos *speed * Time.deltaTime;
       //Quaternion angleAxis = Quaternion.AngleAxis(rotZ + 90f , Vector3.forward);//AngleAxis= ���� �������� ������ ȸ��
       //Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, speed*Time.deltaTime);
        //transform.rotation = rotation;
    }

    float GetAngle(Vector2 start, Vector2 end)//�������� ������ ������ ����
    {
        Vector2 ver2 = end - start;
        return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Rad2Deg +90;
        //���� ������ ��׸� ������ �ٲ� +90�ؾ� ��ǥ�� ������
        //���̿� �غ����� �־ 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
