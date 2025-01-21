/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/20
 * ����: ������ �� ����
 */
using UnityEngine;


namespace CHM
{


    public class SpiralEnemy : Enemy
    {
        //�Ÿ�
        private float distance;

        [Header("���� ���� ��")]
        //������ ���� = �ӵ�
        [SerializeField] private float gap = 0.0005f;
        //�� �ӵ�
        [SerializeField] private float eulerEuler = 90f;

        //Vector3.zero
        private Vector3 center;
        private Vector3 direction;

        private void Start()
        {
            //Distance(A,B) => A,B ���� �Ÿ��� ����
            distance = Vector2.Distance(Vector2.zero, transform.position);
            center = Vector3.zero;
        }



        //Ȱ��ȭ�ɶ� ����ȴ�
        private void OnEnable()
        {
            distance = Vector2.Distance(Vector2.zero, transform.position);
        }


        //������ ���ϰ�, �Ÿ����� ������ ��� ���½����� ������ ������ ��
        private void Update()
        {
            
            //���� z�� �������� ������Ʈ ������ eulerEuler(����)�� ����, player������ ���� ���������� ����
            transform.RotateAround(center, Vector3.forward, eulerEuler * Time.deltaTime);

            direction = (transform.position - center).normalized;
            distance -= gap;
            transform.position = center + direction * distance;

            ////�ﰢ�Լ�
            //R = R - 0.001f;
            //randomEnemyPosition += Time.deltaTime;
            //float x = R * Mathf.Cos(randomEnemyPosition);
            //float y = R * Mathf.Sin(randomEnemyPosition);
            //transform.position = new Vector2(x, y);
            //var dire = (transform.rotation.z - playerObj.transform.rotation.z);

            //transform.rotation = Quaternion.Euler(0, 0, -dire);

        }

    }

}