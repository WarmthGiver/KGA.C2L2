/* 
 * 작성자: 최동오
 * 수정 날짜: 25/01/14
 * 내용: 나선형 적 생성(인스턴스), 군집 함수화
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
        //적 프리팹
        [SerializeField] private List<GameObject> prefabList;


        //쿨타임
        private float coolTime = 0;
        private float coolTime2 = 0;
        private float timeDley = 3f;
        [Header("라운드 증가 시 변경")]
        [SerializeField] private float angleSpeed;//돌아가는속도
        [SerializeField] private float spawnRate; //생성 주기


        private void Start()
        {
            //처음 로테이션 바꿈 => 앞보게 할려고
            var dod = transform.rotation;
            dod.z = -180;
            transform.rotation = dod;
        }

        private void Shoot1()
        {
            //적 생성 지연
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



        //군집 생성
        //인자값(몇마리,몇번쨰 적)
        private void CreateCluster(int enemyCounter, int enemyNumber)
        {
            //enemyCounter = 3;
            int euler = 360 / enemyCounter;
            //군집
            for (int i = 0; i < enemyCounter; i++)
            {
                Vector2 currentPosition = transform.position;
                Vector2 direction = Quaternion.Euler(0, 0, euler * i) * transform.up;
                Vector2 createPosition = currentPosition + direction * 0.5f;//(객체 간격)
                Instantiate(prefabList[enemyNumber], createPosition, transform.rotation);
            }

        }

        

        [SerializeField] private float EnemyPosition = 3;
        //반지름 간격(위치)으로 적 생성
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

        //진짜 귀한거
        //각도를 가져옴
        //start 내포지션, end 바로볼포지션
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
            //임시 나올자리 원으로 돔
            //transform.RotateAround(Vector2.zero, Vector3.forward, angleSpeed * Time.deltaTime);


            //마우스 클릭시  활성화
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