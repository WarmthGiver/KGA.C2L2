/*
 * �ۼ���: ������
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �����ϴ� �� ��Ʈ��
*/

using UnityEngine;

namespace KGA
{
    public class StraightEnemyCorntrol : Enemy
    {
       

        void Update()
        {
            Vector3 direction = playerObj.transform.position - transform.position;//Ÿ�������� - �������� ��
            direction.Normalize();
            transform.position += direction * 0.5f * Time.deltaTime;
        }
    }
}