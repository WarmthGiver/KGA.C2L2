/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/20
 * ����: ������ �� ����
 */

using UnityEngine;

namespace ArmadaInvencible.CDO
{
    public class SpiralEnemy : Enemy
    {
        //�Ÿ�
        private float distance;

        [Header("�ð� ���� ��")]

        [SerializeField]

        //������ ���� = �ӵ�
        private float gap = 0.0005f;

        
        [SerializeField]

        //�� �ӵ�
        private float eulerEuler = 90f;

        private Vector3 center;

        private Vector3 direction;

        private void Start()
        {
            center = Vector3.zero;

            //Distance(A,B) => A,B ���� �Ÿ��� ����
            distance = Vector2.Distance(Vector2.zero, transform.position);
        }

        //Ȱ��ȭ�ɶ� ����ȴ�
        protected override void OnEnable()
        {
            base.OnEnable();

            distance = Vector2.Distance(Vector2.zero, transform.position);
        }

        //������ ���ϰ�, �Ÿ����� ������ ��� ���½����� ������ ������ ��
        private void Update()
        {
            //���� z�� �������� ������Ʈ ������ eulerEuler(����)�� ����, player������ ���� ���������� ����
            transform.RotateAround(center, Vector3.forward, eulerEuler * Time.deltaTime);

            direction = (transform.position - center).normalized;

            distance -= gap * Time.timeScale;

            transform.position = center + direction * distance;
        }
    }
}