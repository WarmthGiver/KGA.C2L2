/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: ������ �� ����
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KGA
{


    public class SpiralEnemy : Enemy
    {
        

        //�Ÿ�
        private float distance;

        //�� hp
        public float spiralEnemyHp = 5f;

        //������ ���� = �ӵ�
        [SerializeField] private float gap = 0.0005f;

        [Header("���� ���� ��")]
        //�� �ӵ�
        [SerializeField] private float eulerEuler = 90f;

        Vector3 center;


        //�ﰢ�Լ��� (�Ⱦ���)
        //private float randomEnemyPosition = 0;
        //private float R = 5;

        private void Start()
        {
            distance = Vector2.Distance(Vector2.zero, transform.position);
            center = transform.position;
            center = Vector3.zero;
        }

        //���� �浹 �߻��� 
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.tag == "Player")
        //    {
        //        Destroy(gameObject);
        //    }
        //    if(collision.gameObject.tag == "Bullet")
        //    {
        //        Destroy(collision.gameObject);
        //        Destroy(gameObject);
        //    }
        //
        //}




        private void Update()
        {
            
            //���� z�� �������� ������Ʈ ������ eulerEuler(����)�� ����, player������ ���� ���������� ����
            transform.RotateAround(center, Vector3.forward, eulerEuler * Time.deltaTime);

            var direction = (transform.position - center).normalized;
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