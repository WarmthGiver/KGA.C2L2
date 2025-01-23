/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 4가지 총알 궤도 사용할 총알 클래스
*/

using ArmadaInvencible;
using System;
using UnityEngine;

namespace CHM
{
    public abstract class Bulletbase : MonoBehaviour, IDamageable
    {
        [SerializeField]

        private int bulletHp;

        [SerializeField]

        private int bulletDMG;

        [SerializeField]

        private int resetHp;

        [SerializeField]

        protected TrailRenderer trailrenderer;


        //프리팹 상속자
        //private GameObject Animator;

        //[SerializeField]

        //피격 임팩트 프리팹
        //private GameObject hitEffect;

        //이동제어 MovementRigidbody2D 변수 
        protected MovementRigidbody2D movementRigidbody2D;

        //Setup 메서드는 자식 클래스에서 재정의 할수 있도록 virtual메서드로 만듬
        //총 4개의 매개변수 (목표 , 공격력 , 발사체 개수 , 발사체 순번)
        public virtual void Setup(string v, GameObject target, int maxCount = 10, int index = 0)
        {
            movementRigidbody2D = GetComponent<MovementRigidbody2D>();
        }

        private void Update()
        {
            Process();
        }

        //발사체가 업데이트 할 동안 호출할 Process 메서드
        //발사체 유형에 따라 자식 클래스에서 정의할수있도록 추상(abstract) 메서드로 만듬
        public abstract void Process();

        protected virtual void OnEnable()
        {
            bulletHp = resetHp;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var player = collision.GetComponent<IDamageable>();

                player.GetDamage(bulletDMG);
                gameObject.SetActive(false);
                //Dead();
            }
        }

        private void OnDisable()
        {
            trailrenderer.Clear();
        }


        public void GetDamage(int damage)
        {
            //불렛 hp를 줄여야댐
            bulletHp -= damage;

            if (bulletHp <= 0)
            {
                bulletHp = 0;

                Dead();
            }
        }

        private void Dead()
        {
            var fx = FXPoolManager.Instance.Generate("Explosion 1");

            fx.transform.position = transform.position;

            fx.gameObject.SetActive(true);

            var sfx = SFXPoolManager.Instance.Generate("Explosion 1");

            sfx.transform.position = transform.position;

            sfx.gameObject.SetActive(true);

            gameObject.SetActive(false);
        }

    }
}