/* 
 * 작성자: 최동오
 * 수정 날짜: 25/01/20
 * 내용: 나선형 적 생성(인스턴스), 인자값에 따른 군집 생성, 위치 생성
 */
using UnityEngine;
using ZL.Unity.ObjectPooling;
using ZL.Unity.Collections;
using CC;

namespace CHO
{

    public class SpiralEnemySpawner : Enemy
    {
        //풀링 Dictionary
        [SerializeField] private SerializableDictionary<string, GameObjectPool<Enemy>> prefabList;

        //쿨타임
        private float coolTime = 0;
        private float coolTime2 = 0;
        private float timeDley = 3f;

        [Header("라운드 증가 시 변경")]
        [SerializeField] private float spawnRate; //생성 주기 //적을 수록 많이 나옴
        [SerializeField] private float EnemyPosition = 3.14f;//나오는 위치

        private void Start()
        {
            //처음 로테이션 바꿈 => 프리팹 사진 앞보게 할려고
            var dod = transform.rotation;
            dod.z = -180;
            transform.rotation = dod;
        }

        private void Shoot1()
        {
            //적 생성 지연
            coolTime += Time.deltaTime;
            if (coolTime > timeDley * 1.4 * spawnRate)
            {
                randomInt();
                CreateCluster(3, "SpiralEnemy1");
                coolTime = 0;
            }
        }

        private void Shoot2()
        {
            coolTime2 += Time.deltaTime;
            if (coolTime2 > timeDley * spawnRate)
            {
                randomInt();
                CreateCluster(4, "SpiralEnemy1");
                coolTime2 = 0;
            }
        }




        //군집 생성
        //인자값(몇마리,적이름)
        private void CreateCluster(int enemyCounter, string enemyName)
        {
            Vector2 centerPosition = transform.position;  // 중심 위치 저장

            int euler = 360 / enemyCounter;

            // 군집 생성
            for (int i = 0; i < enemyCounter; i++)
            {
                Vector2 currentPosition = transform.position;  // 현재 위치

                // 각도에 따른 방향 벡터 계산
                Vector2 direction = Quaternion.Euler(0, 0, euler * i) * transform.up;

                // 생성 위치 계산
                Vector2 createPosition = currentPosition + direction * 0.25f;//(객체 간격)

                var ee = prefabList[enemyName].Generate();
                ee.transform.position = createPosition;
                ee.transform.rotation = transform.rotation;

                ee.gameObject.SetActive(true);//명시적***
            }

        }


        //반지름5 간격(위치)으로 위치 생성
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

        //진짜 귀한거****
        //각도를 가져옴
        //start 내포지션, end 바로볼포지션
        float sds(Vector2 start, Vector2 end)
        {
            Vector2 ver = end - start;
            return Mathf.Atan2(ver.y, ver.x) * Mathf.Rad2Deg;

        }

        //랜덤위치
        private void randomInt()
        {
            //0일경우(5,0), 3.14일경우(-5,0)
            EnemyPosition = Random.Range(0, 3.14f * 2);


        }


        private void Update()
        {
            //자동 소환
            //Shoot1();
            //Shoot2();

            //위치
            rCreateCluster();


            //마우스 클릭시  활성화
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

            ////임시 확인용 1~4마리 생성
            if (Input.GetKeyDown(KeyCode.Q))
            {
                randomInt();
                CreateCluster(1, "SpiralEnemy1");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                randomInt();
                CreateCluster(2, "SpiralEnemy1");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                randomInt();
                CreateCluster(3, "SpiralEnemy2");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                randomInt();
                CreateCluster(4, "SpiralEnemy3");
            }




        }



    }
}