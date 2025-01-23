/* 
 * 작성자: 최동오
 * 수정 날짜: 25/01/20
 * 내용: 나선형 적 구현
 */

using UnityEngine;

namespace ArmadaInvencible.CDO
{
    public class SpiralEnemy : Enemy
    {
        //거리
        private float distance;

        [Header("시간 증가 시")]

        [SerializeField]

        //들어오는 간격 = 속도
        private float gap = 0.0005f;

        
        [SerializeField]

        //원 속도
        private float eulerEuler = 90f;

        private Vector3 center;

        private Vector3 direction;

        private void Start()
        {
            center = Vector3.zero;

            //Distance(A,B) => A,B 사이 거리를 구함
            distance = Vector2.Distance(Vector2.zero, transform.position);
        }

        //활성화될때 실행된다
        protected override void OnEnable()
        {
            base.OnEnable();

            distance = Vector2.Distance(Vector2.zero, transform.position);
        }

        //방향을 구하고, 거리에서 간격을 계속 빼는식으로 들어오는 느낌을 줌
        private void Update()
        {
            //양의 z축 기준으로 오브젝트 주위를 eulerEuler(각도)로 돌고, player쪽으로 들어와 나선형으로 보임
            transform.RotateAround(center, Vector3.forward, eulerEuler * Time.deltaTime);

            direction = (transform.position - center).normalized;

            distance -= gap * Time.timeScale;

            transform.position = center + direction * distance;
        }
    }
}