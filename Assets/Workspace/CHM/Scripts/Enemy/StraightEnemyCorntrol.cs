/*
 * �ۼ���: ������
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �����ϴ� �� ��Ʈ��
*/

using ArmadaInvencible.CDO;

using UnityEngine;

namespace ArmadaInvencible.CHM
{
    public class StraightEnemyCorntrol : Enemy
    {
        [SerializeField]
        
        private float speed;

        private void Update()
        {
            //Ÿ�������� - �������� ��
            Vector3 direction = new Vector3(0,0,0) - transform.position;

            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }
    }
}