using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTTSpawnerRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationspeed;//���ۺ��� ���� �ӵ�
    [SerializeField]
    private int radius;//������
    
    float speed;//������ ���� ���ǵ�
    Vector3 spawnerPos;
    Vector3 targetPos;

    void Update()
    {
        LookCircleRotation(radius);

    }
    void LookCircleRotation(int circleradius)
    {
        targetPos = new Vector3(0, 0, 0);//��ǥ
        spawnerPos = transform.position;
        speed += Time.deltaTime * rotationspeed;
        //Vector3 angle = spawnerPos - targetPos;//������ - ��ǥ = �Ÿ� = ������        
        var angle2 = GetAngle(spawnerPos, targetPos);//���������� ��ǥ�� ����
        //Vector3 dir = new Vector3(Mathf.Cos(angle2), Mathf.Sin(angle2));   
        float x = circleradius * Mathf.Cos(speed);//������ �� * ������ �ӵ�
        float y = circleradius * Mathf.Sin(speed);
        Vector3 newPos = new Vector3(x, y);
        transform.position = newPos;
        transform.rotation = Quaternion.Euler(0, 0, angle2);
        
    }
    float GetAngle(Vector2 start, Vector2 end)//�������� ������ ������ ����
    {
        Vector2 ver2 = end - start;
        return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Rad2Deg - 90;
       
    }
}
