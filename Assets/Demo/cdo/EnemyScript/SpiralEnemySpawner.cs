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
//using Transform = UnityEngine.Transform;

namespace KGA
{

    public class SpiralEnemySpawner : Enemy
    {
        //적 프리팹
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject prefab2;
        


        //쿨타임
        private float coolTime = 0;
        private float coolTime2 = 0;
        private float timeDley = 3f;
        [Header("라운드 증가 시 변경")]
        [SerializeField] private float angleSpeed;//돌아가는속도
        [SerializeField] private float spawnRate;




        private void Shoot1()
        {
            //Instantiate(prefab, transform.position, transform.rotation);
            //적 생성 지연
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

        //군집
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
            //처음 로테이션 바꿈 => 앞보게함
            var dod = transform.rotation;
            dod.z = -180;
            transform.rotation = dod;
        }

        //군집 생성
        //??프리팹 넣는거나 관련된거 추가하면댐 //리턴
        private void CreateCluster(int enemyCounter)
        {
            //enemyCounter = 3;
            int euler = 360 / enemyCounter;
            //군집
            for (int i = 0; i < enemyCounter; i++)
            {
                Vector2 currentPosition = transform.position;

                Vector2 direction = Quaternion.Euler(0, 0, euler * i) * transform.up;
                Vector2 createPosition = currentPosition + direction * 0.5f;//(객체 간격)

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
            //임시 나올자리 원으로 돔
            transform.RotateAround(Vector2.zero, Vector3.forward, angleSpeed * Time.deltaTime);
            //마우스 클릭시  활성화
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