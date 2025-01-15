/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: ������ �� ����
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CHM
{


    public class SpiralEnemy : Enemy
    {
        

        //�� �ӵ�
        [SerializeField] private float eulerEuler = 90f;

        //������ ���� = �ӵ�
        [SerializeField] private float gap = 0.0005f;

        //�Ÿ�
        private float distance;

        //�� hp
        public float spiralEnemyHp = 5f;



        //�ﰢ�Լ��� (�Ⱦ���)
        //private float randomEnemyPosition = 0;
        //private float R = 5;

        private void Start()
        {
            distance = Vector2.Distance(playerObj.transform.position, transform.position);
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
            transform.RotateAround(playerObj.transform.position, Vector3.forward, eulerEuler * Time.deltaTime);

            var direction = (transform.position - playerObj.transform.position).normalized;
            distance -= gap;
            transform.position = playerObj.transform.position + direction * distance;

            //�ﰢ�Լ�
            //R = R - speed;
            //randomEnemyPosition += Time.deltaTime;
            //float x = R * Mathf.Cos(randomEnemyPosition );
            //float y = R * Mathf.Sin(randomEnemyPosition );
            //transform.position = new Vector2(x, y);

            //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);


        }
    }

}