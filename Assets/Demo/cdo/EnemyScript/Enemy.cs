using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;


namespace CC
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int resetEnemyhp;//�ʱ� �� �ִ� ü��
        [SerializeField] protected int enemyHp ;//�� ü��
        [SerializeField] protected int enemyDamage = 1;//�� ������
        [SerializeField] protected Vector3 target = new Vector3(0,0,0);//�ϴ� �߽���

        [SerializeField] protected GameObject explosionImage;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Explosion();
                //�ε����� player�� hp�� �������� �ش�
                var player = collision.GetComponent<IDamageable>();
                player.GetDamage(enemyDamage);
                gameObject.SetActive(false);

            }

        }

        //������ ����
        public void GetDamage(int damage)
        {
            //�÷��̾� hp�� �ٿ��ߴ�
            enemyHp -= damage;  
            if(enemyHp <= 0)
            {
                enemyHp = 0;
                gameObject.SetActive(false);

                //������ ���
                Explosion();
            }

        }

        //�ı��� ���� ȿ��
        private void Explosion()
        {
            Instantiate(explosionImage).transform.position = transform.position;

        }
        protected virtual void OnEnable()
        {
            //�ʱ�ȭ ��� �־�ߴ� 
            //hp, �Ÿ� ��
            enemyHp = resetEnemyhp;

        }





    }
}
