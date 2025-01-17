/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/14
 * ����: ������ �� ����(�ν��Ͻ�), ���� �Լ�ȭ
 */
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;
//using Transform = UnityEngine.Transform;

namespace CHM
{

    public class SpiralEnemySpawner : Enemy
    {
        //�� ������
        [SerializeField] private List<GameObject> prefabList;


        //��Ÿ��
        private float coolTime = 0;
        private float coolTime2 = 0;
        private float timeDley = 3f;
        [Header("���� ���� �� ����")]
        [SerializeField] private float angleSpeed;//���ư��¼ӵ�
        [SerializeField] private float spawnRate; //���� �ֱ�


        private void Start()
        {
            //ó�� �����̼� �ٲ� => �պ��� �ҷ���
            var dod = transform.rotation;
            dod.z = -180;
            transform.rotation = dod;
        }

        private void Shoot1()
        {
            //�� ���� ����
            coolTime += Time.deltaTime;
            if (coolTime > timeDley*1.4* spawnRate)
            {
                CreateCluster(3, 0);
                //Instantiate(prefab, transform.position, transform.rotation);
                coolTime = 0;
            }
        }

        private void Shoot2()
        {
            //Instantiate(prefab2, transform.position, base.transform.rotation);
            coolTime2 += Time.deltaTime;
            if (coolTime2 > timeDley* spawnRate)
            {
                CreateCluster(4, 1);
                //Instantiate(prefab2, transform.position, base.transform.rotation);
                coolTime2 = 0;
            }
        }



        //���� ����
        //���ڰ�(���,����� ��)
        private void CreateCluster(int enemyCounter, int enemyNumber)
        {
            //enemyCounter = 3;
            int euler = 360 / enemyCounter;
            //����
            for (int i = 0; i < enemyCounter; i++)
            {
                Vector2 currentPosition = transform.position;
                Vector2 direction = Quaternion.Euler(0, 0, euler * i) * transform.up;
                Vector2 createPosition = currentPosition + direction * 0.5f;//(��ü ����)
                Instantiate(prefabList[enemyNumber], createPosition, transform.rotation);
            }

        }

        

        [SerializeField] private float EnemyPosition = 3;
        //������ ����(��ġ)���� �� ����
        private void rCreateCluster()
        {
            //EnemyPosition += Time.deltaTime; 
            float x = 5 * Mathf.Cos(EnemyPosition);
            float y = 5 * Mathf.Sin(EnemyPosition);
            transform.position = new Vector2(x, y);
          
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position);
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);

            var dd = transform.position - Vector3.zero;

            var angde = sds(Vector2.zero, dd);
            transform.rotation = Quaternion.Euler(0, 0, angde);


        }

        //��¥ ���Ѱ�
        //������ ������
        //start ��������, end �ٷκ�������
        float sds(Vector2 start, Vector2 end)
        {
            Vector2 ver = end - start;
            return Mathf.Atan2(ver.y, ver.x) * Mathf.Rad2Deg;
            
        }


        private void Update()
        {
            Shoot1();
            Shoot2();

            rCreateCluster();
            //�ӽ� �����ڸ� ������ ��
            //transform.RotateAround(Vector2.zero, Vector3.forward, angleSpeed * Time.deltaTime);


            //���콺 Ŭ����  Ȱ��ȭ
            if (Input.GetMouseButtonDown(0))
            {
                CreateCluster(3, 0);

            }
            if (Input.GetMouseButtonDown(1))
            {
                var dod = base.transform.rotation;
                dod.z = 0;
                transform.rotation = dod;
                transform.position = new Vector3(4.5f, 0, 0);
                CreateCluster(4, 1);


            }


        }



    }
}