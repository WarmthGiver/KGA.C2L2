/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * 4���� �Ѿ� �˵� ����� �Ѿ� Ŭ����
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


        //������ �����
        //private GameObject Animator;

        //[SerializeField]

        //�ǰ� ����Ʈ ������
        //private GameObject hitEffect;

        //�̵����� MovementRigidbody2D ���� 
        protected MovementRigidbody2D movementRigidbody2D;

        //Setup �޼���� �ڽ� Ŭ�������� ������ �Ҽ� �ֵ��� virtual�޼���� ����
        //�� 4���� �Ű����� (��ǥ , ���ݷ� , �߻�ü ���� , �߻�ü ����)
        public virtual void Setup(string v, GameObject target, int maxCount = 10, int index = 0)
        {
            movementRigidbody2D = GetComponent<MovementRigidbody2D>();
        }

        private void Update()
        {
            Process();
        }

        //�߻�ü�� ������Ʈ �� ���� ȣ���� Process �޼���
        //�߻�ü ������ ���� �ڽ� Ŭ�������� �����Ҽ��ֵ��� �߻�(abstract) �޼���� ����
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
            //�ҷ� hp�� �ٿ��ߴ�
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