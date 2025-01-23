/*
 * 작성자: 최현민
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 직진하는 적 컨트롤
*/

using ArmadaInvencible.CDO;

using UnityEngine;

namespace ArmadaInvencible.CHM
{
    public class StraightEnemyCorntrol : Enemy
    {
        [SerializeField]
        
        private float speed;

        private void Update()
        {
            //타겟포지션 - 적포지션 값
            Vector3 direction = new Vector3(0,0,0) - transform.position;

            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }
    }
}