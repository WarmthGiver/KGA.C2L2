/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 3차 방정식을 이용한 총알 s 자 궤도
*/

using UnityEngine;

namespace ArmadaInvencible.CHM
{
    public class CubicHomingBullet : Bulletbase
    {
        private Vector2 start, end, point1, point2;

        private float duration, t = 0f;

        private GameObject target;

        private float distance;

        public override void Setup(string v, GameObject target, int maxCount = 1, int index= 0)
        {
            base.Setup("CubicHomingBullet", target);

            this.target = target;

            start =transform.position;

            end = this.target.transform.position;

            //시작 지점에서 목표까지의 거리 계산
            distance = Vector3.Distance(start,end);

            //재생시간 절성 (거리 / 이동속도)
            duration = distance / movementRigidbody2D.MoveSpeed;

            float angle = 45;

            //현재 플레이어의 회전 값 적용을 위해 angle 값에 더해준다
            angle += Utils.GetAngleFromPosition(start, end);

            //시작지점에서 목표지점 사이의 앵글, 앵글 * -1 각도로 30% 70% 떨어진 위치
            point1 = Utils.GetCirclePoint(start, angle,distance * 0.1f);

            point2 = Utils.GetCirclePoint(end, angle * -1, distance * 0.9f);

            //타겟 바라보게 함
        }
        public override void Process()
        {
            end = target.transform.position;

            t += Time.deltaTime / duration;

            transform.position = Utils.CubicCurve(start, point1, point2, end, t);

            transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
            
        }
        protected override void OnEnable()
        {
            base.OnEnable();

            t = 0;

            distance = Vector3.Distance(start, end);
        }
    }
}