/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 직선으로 쏘는 총알 스크립트
*/
using Unity.Mathematics;
using UnityEngine;
namespace CHM
{
    public class StraighBullet : Bulletbase
    //ProjectileBase를 상속받는 직선형 발사체
    {
        //Setup 메서드를 재정의(override)하고 base.Setup으로 부모 클래스의 Setup을 호출함
        Quaternion quaternion;
        private GameObject target;
        public override void Setup(string v, GameObject target, int maxCount = 1, int index = 0)
        {
            base.Setup("StraighBullet", target, maxCount);
            this.target = target;
            //발사체 이동방향 설정
            //목표위치 - 내 위치 는 내 위치에ㅐ서 목표 위치로가는 벡터 생성
            //스칼라가 포함된 벡터이기 때문에 노멀라이즈로 0.0 ~ 1.0 사이의 값으로 정규화
            
        }
        
        //부모 클래스에서 추상으로 정의된 메소드는 자식클래스에서 꼭 재정의 해야함
        //아무기능이없어도 Process() 메소드 재정의해줘야 에러가 안뜬다
        public override void Process() 
        {
            movementRigidbody2D.MoveTo((target.transform.position - transform.position).normalized);
            quaternion = Utils.LookTaget(transform.position, target.transform.position);
            transform.rotation = quaternion;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
           
        }




    }
}