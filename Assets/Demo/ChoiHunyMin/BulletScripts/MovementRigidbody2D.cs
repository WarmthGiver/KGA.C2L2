/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 리지드바디 정보 가져오는 스크립트
*/
using UnityEngine;

namespace CHM
{
    public class MovementRigidbody2D : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 10f;// 이동속도
        private Rigidbody2D rigid2D;//리지드바디 정보

        public float MoveSpeed => moveSpeed;//외부에서 이동속도 확인할수있도록 Get 프로퍼티

        private void Awake()
        {
            rigid2D = GetComponent<Rigidbody2D>();//변수에 저장
        }

        //외부에서 방향설정할때 호출하는 메서드
        public void MoveTo(Vector3 direction)
        {
            rigid2D.velocity = direction * moveSpeed;
            //rigid2D.velocity(속력) = 방향(direction) * 속도(MoveSpeed)
        }

    }
}