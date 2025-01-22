using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;


namespace CC
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int resetEnemyhp;//초기 적 최대 체력
        [SerializeField] protected int enemyHp ;//적 체력
        [SerializeField] protected int enemyDamage = 1;//적 데미지
        [SerializeField] protected Vector3 target = new Vector3(0,0,0);//일단 중심점

        [SerializeField] protected GameObject explosionImage;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Explosion();
                //부딪히면 player의 hp의 데미지를 준다
                var player = collision.GetComponent<IDamageable>();
                player.GetDamage(enemyDamage);
                gameObject.SetActive(false);

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
                gameObject.SetActive(false);

                //터지는 기능
                Explosion();
            }

        }

        //파괴시 폭발 효과
        private void Explosion()
        {
            Instantiate(explosionImage).transform.position = transform.position;

        }
        protected virtual void OnEnable()
        {
            //초기화 기능 넣어야댐 
            //hp, 거리 등
            enemyHp = resetEnemyhp;

        }





    }
}
