/*
 * �ۼ���: ������
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �����ϴ� �� ��Ʈ��
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace CHM
{
    public class StraightEnemyCorntrol : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;//��ǥ�������� ���� ����
        [SerializeField]
        private float speed;//���� �ӵ�
        [SerializeField]
        private int straightEnemyHP;//�ϴ� HP����
        void Start()
        {

        }
        void OnTriggerEnter2D(Collider2D collifer)//�ͷ� ������ �ı�
        {
            if (collifer.CompareTag("Player"))
            {
                Destroy(gameObject);//�÷��̾ ������ �����
            }
            if (collifer.CompareTag("Bullet"))
            {
                Destroy(gameObject);//�Ѿ� ������ �����
            }
        }

        void Update()
        {
            Vector3 direction = player.transform.position - transform.position;//Ÿ�������� - �������� ��
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}