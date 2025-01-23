using ArmadaInvencible;

using UnityEngine;

namespace CC
{
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField]

        //�ʱ� �� �ִ� ü��
        private int resetEnemyhp;

        [SerializeField]

        //�� ü��
        protected int enemyHp;

        [SerializeField]

        //�� ������
        protected int enemyDamage = 1;

        [SerializeField]

        //�ϴ� �߽���
        protected Vector3 target = Vector3.zero;

        [SerializeField]

        protected string deadFX;

        protected virtual void OnEnable()
        {
            //�ʱ�ȭ ��� �־�ߴ� 
            //hp, �Ÿ� ��
            enemyHp = resetEnemyhp;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                //�ε����� player�� hp�� �������� �ش�
                var player = collision.GetComponent<IDamageable>();

                player.GetDamage(enemyDamage);

                Dead();
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

                //������ ���
                Dead();
            }
        }

        //�ı��� ���� ȿ��
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