/*
 * 작성자: 최현민
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 직진하는 적 생성하는 오브젝트
 * 한번에 여러 객체 생기게 하는 메서드만들어서 한번에 생기게 만듬
*/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace CHM
{

    public class StraightEnemySpawner : MonoBehaviour
    {
        [SerializeField]
        protected GameObject enemyPrefab;
        //[SerializeField]
        //private bool isRight = true;//반대로 돌게함
        [SerializeField]
        private float spawnerspeed;//빙글빙글 도는 속도
        [SerializeField]
        private float prefabSpeed;//프리팹 생성 속도
        [SerializeField]
        private float coolTime;//쿨타임
        [SerializeField]
        private int radius;
        float speed;
        
        private void Update()
        {
            coolTime += Time.deltaTime;
            speed += Time.deltaTime * spawnerspeed;


               LookTarget();
            
            if (coolTime > prefabSpeed)
            {
            
                squadEnemy();
                coolTime = 0;
            }
            
            //Rotating();
            
        }
        //void Rotating()
        //{
        //
        //    if (isRight == true)
        //    {
        //
        //       transform.RotateAround(dbj.transform.position, Vector3.forward, spawnerspeed * Time.deltaTime);
        //
        //    }
        //    //Vector3.back 넣으면 반대방향으로 돔
        //    else
        //    {
        //        transform.RotateAround(dbj.transform.position, Vector3.back, spawnerspeed * Time.deltaTime);
        //
        //    }
        //}
        void squadEnemy()
        {
            //get 함수 인자값대로 배열에 담김
            //PoolManager.instance.Get(Random.Range(0,10));

            Instantiate(enemyPrefab, transform.position, transform.rotation);

            //Vector3 vector = new Vector3(transform.position.x, transform.position.y);
            //Vector3 vector1 = new Vector3(vector.x -1,vector.y);
            ////Vector3 vector2 = new Vector3(vector.x + 1, vector.y);
            //
            //Instantiate(enemyPrefab, vector, transform.rotation);
            //Instantiate(enemyPrefab, vector1, transform.rotation);
            //Instantiate(enemyPrefab, vector2, transform.rotation);

        }
        void LookTarget()
        {

            var parentPos = transform.parent.position;//parent 는 부모에있는걸 가져올수 있다
            Vector3 targetPos = parentPos;//목표
            Vector2 spawnerPos = transform.position;      
            float x = radius * Mathf.Cos(speed);//반지름 값 * 움직일 속도
            float y = radius * Mathf.Sin(speed);
             
            //이거좀 귀함 여기서 x는 월드좌표?? 기준이 0에서 시작한 반지름이고
            // 거기서 + 돌리고자 하는 기준점의 좌표를 넣어줘야함
            transform.position = new Vector3(x+targetPos.x, y+targetPos.y); 

            //목표 벡터를 바라보는 코드
           
            var angle2 = GetAngle(spawnerPos, Vector2.zero);            
            transform.rotation = Quaternion.Euler(0, 0, angle2);
        }
        float GetAngle(Vector2 start, Vector2 end)//시작점과 끝점에 각도를 구함
        {
            Vector2 ver2 = end - start;
            return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Rad2Deg-90;
            //처음있는 위치에 따라 달라짐
            //라디안 각도를 디그리 각도로 바꿈 -90해야 목표에 도착함
            //높이와 밑변값을 넣어서 
        }
        
    }
}