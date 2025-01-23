/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/20
 * ����: ������ �� ����(�ν��Ͻ�), ���ڰ��� ���� ���� ����, ��ġ ����
 */

using UnityEngine;

using ZL.Unity.ObjectPooling;

using ZL.Unity.Collections;

namespace ArmadaInvencible.CDO
{
    public class SpiralEnemySpawner : Enemy
    {
        [SerializeField]

        //Ǯ Dictionary
        private SerializableDictionary<string, GameObjectPool<Enemy>> prefabList;

        //��Ÿ��
        private float coolTime = 0;

        private float coolTime2 = 0;

        private float coolTime3 = 0;

        private float coolTime4 = 0;

        private float timeDley = 3f;

        [SerializeField] private float testTime;

        //������ ��ġ
        [SerializeField]
        
        private float EnemyPosition = 3.14f;

        [Header("�ð� ���� �� ����")]

        [SerializeField]

        //���� �ֱ� //���� ���� ���� ����
        private float spiralSpawnDelay;

        //���� ���� ����
        protected bool isBossSpawn = false;

        protected int counteBossSpawn = 0;

        //�����ֱ� ������Ƽ //���� ���� ���� ����
        public float SpiralSpawnDelay
        {
            get
            {
                return spiralSpawnDelay;
            }

            set
            {
                if (value < 0.3f)
                {
                    spiralSpawnDelay = 0.3f;
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

            testTime = Time.time;   
        }

        private void Shoot1()
        {
            //�� ���� ����
            coolTime += Time.deltaTime;

            if (coolTime > timeDley * SpiralSpawnDelay)
            {
                RandomInt();

                CreateCluster(1, "SpiralEnemy1");

                coolTime = 0;
            }
        }

        private void Shoot2()
        {
            coolTime2 += Time.deltaTime;

            if (coolTime2 > timeDley *1.4f * SpiralSpawnDelay)
            {
                RandomInt();

                CreateCluster(2, "SpiralEnemy2");

                coolTime2 = 0;
            }
        }

        private void Shoot3()
        {
            coolTime3 += Time.deltaTime;

            if (coolTime3 > timeDley*1.7 * SpiralSpawnDelay)
            {
                RandomInt();

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
        private float sds(Vector2 start, Vector2 end)
        {
            Vector2 ver = end - start;

            return Mathf.Atan2(ver.y, ver.x) * Mathf.Rad2Deg;
        }

        //������ġ
        private void RandomInt()
        {
            //0�ϰ��(5,0), 3.14�ϰ��(-5,0)
            EnemyPosition = Random.Range(0, 3.14f * 2);
        }

        //�ڵ� ��ȯ
        private void Update()
        {
            testTime += Time.deltaTime;

            if(isBossSpawn == false)
            {
                Shoot1();

                Shoot2();

                Shoot3();
            }
            
            coolTime4 += Time.deltaTime;

            if (coolTime4 > 30)
            {
                SpiralSpawnDelay -= 0.3f;

                counteBossSpawn++;

                coolTime4 = 0;
            }

            if(counteBossSpawn == 5)
            {
                isBossSpawn = true;
            }
            
            //��ġ
            rCreateCluster();
        }
    }
}