/*
 * 작성자: 최현민
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 직진하는 적 생성하는 오브젝트
 * 한번에 여러 객체 생기게 하는 메서드만들어서 한번에 생기게 만듬
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace CHM
{
    public class StraightEnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;//일단 목표물 설정용
        [SerializeField]
        private GameObject enemyPrefab;//적 프리팹
        [SerializeField]
        public bool isRight = true;//반대로 돌게함
        [SerializeField]
        private float spawnerspeed;//빙글빙글 도는 속도
        [SerializeField]
        private float prefabSpeed;//프리팹 생성 속도
        [SerializeField]
        private float coolTime;//쿨타임

        void Start()
        {


        }


        void Update()
        {
            coolTime += Time.deltaTime;

            if (coolTime > prefabSpeed)
            {

                //Instantiate(enemyPrefab, transform.position, transform.rotation);
                //생성된 애랑 생성하는 애랑 똑같은 위치로 생성
                squadEnemy();

                coolTime = 0;
            }
            Rotating();
            
        }
        void Rotating()
        {
            if (isRight == true)
            {
                transform.RotateAround(player.transform.position, Vector3.forward, spawnerspeed * Time.deltaTime);

            }
            //Vector3.back 넣으면 반대방향으로 돔
            else
            {
                transform.RotateAround(player.transform.position, Vector3.back, spawnerspeed * Time.deltaTime);

            }
        }
        void squadEnemy()//
        {
            Vector3 vector = new Vector3(transform.position.x, transform.position.y);
            Vector3 vector1 = new Vector3(vector.x -1,vector.y+1);
            Vector3 vector2 = new Vector3(vector.x + 1, vector.y-1);

            Instantiate(enemyPrefab, vector, transform.rotation);
            Instantiate(enemyPrefab, vector1, transform.rotation);
            Instantiate(enemyPrefab, vector2, transform.rotation);

        }
        
    }
}