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
//using Transform = UnityEngine.Transform;

namespace KGA
{

    public class SpiralEnemySpawner : Enemy
    {
        //�� ������
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject prefab2;
        


        //��Ÿ��
        private float coolTime = 0;
        private float coolTime2 = 0;
        private float timeDley = 3f;
        [Header("���� ���� �� ����")]
        [SerializeField] private float angleSpeed;//���ư��¼ӵ�
        [SerializeField] private float spawnRate;




        private void Shoot1()
        {
            //Instantiate(prefab, transform.position, transform.rotation);
            //�� ���� ����
            coolTime += Time.deltaTime;
            if (coolTime > timeDley*1.4* spawnRate)
            {
                Instantiate(prefab, transform.position, transform.rotation);
                coolTime = 0;
            }
        }
        private void Shoot2()
        {
            //Instantiate(prefab2, transform.position, base.transform.rotation);
            coolTime2 += Time.deltaTime;
            if (coolTime2 > timeDley* spawnRate)
            {
                Instantiate(prefab2, transform.position, base.transform.rotation);
                coolTime2 = 0;
            }
        }

        //����
        private void Shoot3()
        {
            Instantiate(prefab2, transform.position, transform.rotation);
            var dod = transform.position;
            dod.x -= 0.5f;
            dod.y -= 0.5f;
            Instantiate(prefab2, dod, transform.rotation);
            dod.x += 1f;
            Instantiate(prefab2, dod, transform.rotation);
        }
       

        private void Start()
        {
            //ó�� �����̼� �ٲ� => �պ�����
            var dod = transform.rotation;
            dod.z = -180;
            transform.rotation = dod;
        }

        //���� ����
        //??������ �ִ°ų� ���õȰ� �߰��ϸ�� //����
        private void CreateCluster(int enemyCounter)
        {
            //enemyCounter = 3;
            int euler = 360 / enemyCounter;
            //����
            for (int i = 0; i < enemyCounter; i++)
            {
                Vector2 currentPosition = transform.position;

                Vector2 direction = Quaternion.Euler(0, 0, euler * i) * transform.up;
                Vector2 createPosition = currentPosition + direction * 0.5f;//(��ü ����)

                Instantiate(prefab, createPosition, transform.rotation);
            }
        }




        private void Update()
        {
            
            coolTime += Time.deltaTime;
            if (coolTime > timeDley * 1.4 * spawnRate)
            {
               
                //Shoot3();   
                coolTime = 0;
            }
            //Shoot1();
            //�ӽ� �����ڸ� ������ ��
            transform.RotateAround(Vector2.zero, Vector3.forward, angleSpeed * Time.deltaTime);
            //���콺 Ŭ����  Ȱ��ȭ
            if (Input.GetMouseButtonDown(0))
            {
                CreateCluster(3);

            }
            if (Input.GetMouseButtonDown(1))
            {
                var dod = base.transform.rotation;
                dod.z = 0;
                base.transform.rotation = dod;
                base.transform.position = new Vector3(4.5f, 0, 0);
                CreateCluster(4);


            }




        }



    }
}