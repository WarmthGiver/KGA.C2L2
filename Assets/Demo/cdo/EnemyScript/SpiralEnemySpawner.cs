/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/20
 * ����: ������ �� ����(�ν��Ͻ�), ���ڰ��� ���� ���� ����, ��ġ ����
 */
using UnityEngine;
using ZL.Unity.ObjectPooling;
using ZL.Unity.Collections;
using CC;

namespace CHO
{

    public class SpiralEnemySpawner : Enemy
    {
        //Ǯ�� Dictionary
        [SerializeField] private SerializableDictionary<string, GameObjectPool<Enemy>> prefabList;

        //��Ÿ��
        private float coolTime = 0;
        private float coolTime2 = 0;
        private float coolTime3 = 0;
        [SerializeField] private float coolTime4 = 0;
        private float timeDley = 3f;

        //������ ��ġ
        [SerializeField] private float EnemyPosition = 3.14f;

        [Header("�ð� ���� �� ����")]
        [SerializeField] private float spiralSpawnDelay; //���� �ֱ� //���� ���� ���� ����

        //�����ֱ� ������Ƽ //���� ���� ���� ����
        public float SpiralSpawnDelay
        {
            get
            {
                return spiralSpawnDelay;
            }
            set
            {
                if (value < 0.2f)
                {
                    spiralSpawnDelay = 0.2f;
                }
                else
                {
                    spiralSpawnDelay = value;
                }
            }
        }


        private void Start()
        {
            //ó�� �����̼� �ٲ� => ������ ���� �պ��� �ҷ���
            var dod = transform.rotation;
            dod.z = -180;
            transform.rotation = dod;

            InvokeRepeating("spiralSpawnDelay1", 1, 3);
        }

        private void spiralSpawnDelay1()
        {
            SpiralSpawnDelay -= 0.2f;
        }

        private void Shoot1()
        {
            //�� ���� ����
            coolTime += Time.deltaTime;
            if (coolTime > timeDley * SpiralSpawnDelay)
            {
                randomInt();
                CreateCluster(1, "SpiralEnemy1");
                coolTime = 0;
            }
        }

        private void Shoot2()
        {
            coolTime2 += Time.deltaTime;
            if (coolTime2 > timeDley *1.4f * SpiralSpawnDelay)
            {
                randomInt();
                CreateCluster(2, "SpiralEnemy2");
                coolTime2 = 0;
            }
        }

        private void Shoot3()
        {
            coolTime3 += Time.deltaTime;
            if (coolTime3 > timeDley*1.7 * SpiralSpawnDelay)
            {
                randomInt();
                CreateCluster(3, "SpiralEnemy3");
                coolTime3 = 0;
            }
        }

        






        //���� ����
        //���ڰ�(���,���̸�)
        private void CreateCluster(int enemyCounter, string enemyName)
        {
            Vector2 centerPosition = transform.position;  // �߽� ��ġ ����

            int euler = 360 / enemyCounter;

            // ���� ����
            for (int i = 0; i < enemyCounter; i++)
            {
                Vector2 currentPosition = transform.position;  // ���� ��ġ

                // ������ ���� ���� ���� ���
                Vector2 direction = Quaternion.Euler(0, 0, euler * i) * transform.up;

                // ���� ��ġ ���
                Vector2 createPosition = currentPosition + direction * 0.25f;//(��ü ����)

                var ee = prefabList[enemyName].Generate();
                ee.transform.position = createPosition;
                ee.transform.rotation = transform.rotation;

                ee.gameObject.SetActive(true);//�����***
            }

        }


        //������5 ����(��ġ)���� ��ġ ����
        private void rCreateCluster()
        {
            //EnemyPosition += Time.deltaTime; 
            float x = 5 * Mathf.Cos(EnemyPosition);
            float y = 5 * Mathf.Sin(EnemyPosition);
            transform.position = new Vector2(x, y);

            var dd = transform.position - Vector3.zero;

            var angde = sds(Vector2.zero, dd);
            transform.rotation = Quaternion.Euler(0, 0, angde);


        }

        //��¥ ���Ѱ�****
        //������ ������
        //start ��������, end �ٷκ�������
        float sds(Vector2 start, Vector2 end)
        {
            Vector2 ver = end - start;
            return Mathf.Atan2(ver.y, ver.x) * Mathf.Rad2Deg;

        }

        //������ġ
        private void randomInt()
        {
            //0�ϰ��(5,0), 3.14�ϰ��(-5,0)
            EnemyPosition = Random.Range(0, 3.14f * 2);


        }


        private void Update()
        {
            //�ڵ� ��ȯ
            Shoot1();
            Shoot2();
            Shoot3();

            //coolTime4 += Time.deltaTime;
            //if (coolTime4 > 30)
            //{

            //    SpiralSpawnDelay -= 0.2f;

            //    coolTime4 = 0;
            //}

            Debug.Log("spiralSpawnDelay"+ spiralSpawnDelay);

            //��ġ
            rCreateCluster();

            //���콺 Ŭ����  Ȱ��ȭ
            //if (Input.GetMouseButtonDown(0))
            //{
            //    randomInt();
            //    CreateCluster(3, "SpiralEnemy1");

            //}
            //if (Input.GetMouseButtonDown(1))
            //{
            //    var dod = base.transform.rotation;
            //    dod.z = 0;
            //    transform.rotation = dod;
            //    transform.position = new Vector3(4.5f, 0, 0);
            //    CreateCluster(4, "SpiralEnemy1");

            //}

            //�ӽ� Ȯ�ο� 1~4���� ����
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    randomInt();
            //    CreateCluster(1, "SpiralEnemy1");
            //}
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    randomInt();
            //    CreateCluster(2, "SpiralEnemy1");
            //}
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    randomInt();
            //    CreateCluster(3, "SpiralEnemy2");
            //}
            //if (Input.GetKeyDown(KeyCode.R))
            //{
            //    randomInt();
            //    CreateCluster(4, "SpiralEnemy3");
            //}




        }



    }
}