/*
 * �ۼ���: ������
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �����ϴ� �� ��Ʈ��
*/

using UnityEngine;

namespace CHM
{
    public class StraightEnemyCorntrol : Enemy
    {
        [SerializeField] float speed;        
        void Update()
        {
            Vector3 direction = new Vector3(0,0,0) - transform.position;//Ÿ�������� - �������� ��
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
        
    }
}