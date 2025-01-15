/* 
 * 작성자: 최동오
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 나선형 적 구현
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CHM
{


    public class SpiralEnemy : Enemy
    {
        

        //원 속도
        [SerializeField] private float eulerEuler = 90f;

        //들어오는 간격 = 속도
        [SerializeField] private float gap = 0.0005f;

        //거리
        private float distance;

        //적 hp
        public float spiralEnemyHp = 5f;



        //삼각함수용 (안쓰임)
        //private float randomEnemyPosition = 0;
        //private float R = 5;

        private void Start()
        {
            distance = Vector2.Distance(playerObj.transform.position, transform.position);
        }

        //임의 충돌 발생시 
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
            //양의 z축 기준으로 오브젝트 주위를 eulerEuler(각도)로 돌고, player쪽으로 들어와 나선형으로 보임
            transform.RotateAround(playerObj.transform.position, Vector3.forward, eulerEuler * Time.deltaTime);

            var direction = (transform.position - playerObj.transform.position).normalized;
            distance -= gap;
            transform.position = playerObj.transform.position + direction * distance;

            //삼각함수
            //R = R - speed;
            //randomEnemyPosition += Time.deltaTime;
            //float x = R * Mathf.Cos(randomEnemyPosition );
            //float y = R * Mathf.Sin(randomEnemyPosition );
            //transform.position = new Vector2(x, y);

            //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);


        }
    }

}