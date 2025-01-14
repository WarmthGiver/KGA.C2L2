/*
 * 작성자: 최현민
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 직진하는 적 컨트롤
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace CHM
{
    public class StraightEnemyCorntrol : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;//목표물설정을 위해 받음
        [SerializeField]
        private float speed;//직진 속도
        [SerializeField]
        private int straightEnemyHP;//일단 HP생성
        void Start()
        {

        }
        void OnTriggerEnter2D(Collider2D collifer)//터렛 만나면 파괴
        {
            if (collifer.CompareTag("Player"))
            {
                Destroy(gameObject);//플레이어에 닿으면 사라짐
            }
            if (collifer.CompareTag("Bullet"))
            {
                Destroy(gameObject);//총알 닿으면 사라짐
            }
        }

        void Update()
        {
            Vector3 direction = player.transform.position - transform.position;//타겟포지션 - 적포지션 값
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}