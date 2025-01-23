using ArmadaInvencible;

using UnityEngine;

namespace CC
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField]

        //초기 적 최대 체력
        private int resetEnemyhp;

        [SerializeField]

        //적 체력
        protected int enemyHp;

        [SerializeField]

        //적 데미지
        protected int enemyDamage = 1;

        [SerializeField]

        //일단 중심점
        protected Vector3 target = Vector3.zero;

        [SerializeField]

        protected string deadFX;

        protected virtual void OnEnable()
        {
            //초기화 기능 넣어야댐 
            //hp, 거리 등
            enemyHp = resetEnemyhp;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                //부딪히면 player의 hp의 데미지를 준다
                var player = collision.GetComponent<IDamageable>();

                player.GetDamage(enemyDamage);

                Dead();
            }
        }

        //데미지 입음
        public void GetDamage(int damage)
        {
            //플레이어 hp를 줄여야댐
            enemyHp -= damage;

            if(enemyHp <= 0)
            {
                enemyHp = 0;

                //터지는 기능
                Dead();
            }
        }

        //파괴시 폭발 효과
        protected virtual void Dead()
        {
            var fx = FXPoolManager.Instance.Generate(deadFX);
                
            fx.transform.position = transform.position;

            fx.gameObject.SetActive(true);

            var sfx = SFXPoolManager.Instance.Generate("Explosion 1");

            sfx.transform.position = transform.position;

            sfx.gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}