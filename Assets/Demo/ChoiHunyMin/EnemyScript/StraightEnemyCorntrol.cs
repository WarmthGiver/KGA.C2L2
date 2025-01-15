/*
 * 작성자: 최현민
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 직진하는 적 컨트롤
*/

using UnityEngine;

namespace KGA
{
    public class StraightEnemyCorntrol : Enemy
    {
       

        void Update()
        {
            Vector3 direction = playerObj.transform.position - transform.position;//타겟포지션 - 적포지션 값
            direction.Normalize();
            transform.position += direction * 0.5f * Time.deltaTime;
        }
    }
}