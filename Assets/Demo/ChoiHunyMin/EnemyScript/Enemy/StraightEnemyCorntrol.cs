/*
 * �ۼ���: ������
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �����ϴ� �� ��Ʈ��
*/

using UnityEngine;
using CC;

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
        protected override void OnEnable()
        {
            base.OnEnable();
            
        }
    }
}