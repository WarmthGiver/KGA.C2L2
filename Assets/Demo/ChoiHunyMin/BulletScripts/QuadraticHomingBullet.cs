/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 양옆으로 곡선 궤도 그리며 발사하는 총알
*/

using UnityEngine;

namespace CHM
{
    public class QuadraticHomingBullet : Bulletbase
    {
        //시작지점, 끝지점 (목표) ,중간지점
        private Vector2 start, end, point;

        //발사체 재생시간 , 보간위치를 위한 t
        private float duration, t = 0f;

        [SerializeField] private int indexx;

        //목표 지정
        private GameObject target;

        private float distance;

        public override void Setup(string v, GameObject target, int maxCount = 1, int index =0)
        {
            base.Setup("QuadraticHomingBullet", target);

            //매개변수로 가져온 타겟 담아주기
            this.target = target;
            this.indexx = index;
            //시작점은 현재위치
            start = transform.position;

            //끝 지점 목표의 트렌스폼
            end = this.target.transform.position;
            
            //시작 지점에서 목표까지의 거리 계산
            distance = Vector3.Distance(start, end);

            //재생시간 설정 (거리 / 이동속도)
            //거리에 따라 distance값이 달라지기 때문에 동일한 속도로 이동
            duration = distance/ movementRigidbody2D.MoveSpeed;

            //모든 발사체의 point를 동일하게 45도 각도 위치로 설정
            //float angle = 45;

            //순번에 따라 일정한 각도의 원형으로 위치 설정
            //0 부터 동일한 각도의 원둘레 위치를 포인트로 설정
            float angle = 360 / maxCount * index;

            //순번에 따라 위 or 아래 대각선 (45 or 315도)위치로 설정 index가 홀수면 45, 짝수면 315
            //float angle = 45 + 315 * (indexx % 2);

            //현재 시작위치의 회전 값 적용을 위해  angle 값에 더해준다
            angle += Utils.GetAngleFromPosition(start, end);

            //시작 지점에서 목표지점 사이의 angle 각도로 30% 떨어진위치
            point = Utils.GetCirclePoint(start, angle, distance * 0.2f);

            //poubt 위치 확인을 위한 디버깅 코드 [결과 확인후 삭제]
            //포인트위치에 오브ㅏ젝트를 생성하도록 디버깅 코드 작성
            //GameObject clone = Instantiate(gameObject, point, Quaternion.identity);

            //clone.GetComponent<QuadraticHoming>().enabled = false;

            //clone.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
        public override void Process()
        {
            //현재 목표의 위치값
            end = target.transform.position;

            //duration의 시간동안 t 가 0.0 ~ 1.0으로 점진적으로 바뀌도록 설정
            t += Time.deltaTime / duration; 

            //발사체의 현재위치는 Utils.QuadraticCurve메서드를 호출해
            //시작부터 목표까지 중간지점인 포인트 정보를 바탕으로 곡선이동하도록 설정
            transform.position = Utils.QuadraticCurve(start, point, end, t);

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