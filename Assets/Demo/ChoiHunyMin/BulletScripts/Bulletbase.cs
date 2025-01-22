/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * 4���� �Ѿ� �˵� ����� �Ѿ� Ŭ����
*/
using CC;
using UnityEngine;
using ZL.Unity.Collections;
using ZL.Unity.ObjectPooling;

namespace CHM
{
    public abstract class Bulletbase : MonoBehaviour, IDamageable
    {
        [SerializeField] private int bulletHp;
        [SerializeField] private int bulletDMG;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        [SerializeField] private int resetHp;
=======
        [SerializeField] private int resetbulletHp;
        
>>>>>>> Stashed changes
=======
        [SerializeField] private int resetbulletHp;
        
>>>>>>> Stashed changes
        //������ �����
        [SerializeField]
        private GameObject Animator;        
        
        //[SerializeField]
        //private GameObject hitEffect; //�ǰ� ����Ʈ ������
        protected MovementRigidbody2D movementRigidbody2D;//�̵����� MovementRigidbody2D ����       

        //Setup �޼���� �ڽ� Ŭ�������� ������ �Ҽ� �ֵ��� virtual�޼���� ����
        //�� 4���� �Ű����� (��ǥ , ���ݷ� , �߻�ü ���� , �߻�ü ����)
        public virtual void Setup(GameObject target, int maxCount = 10, int index = 0)
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
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                squadAnimator();
                var player = collision.GetComponent<IDamageable>();
                player.GetDamage(bulletDMG);
                gameObject.SetActive(false);
                
               
            }          
        }
        void squadAnimator()
        {
            Instantiate(Animator, transform.position, transform.rotation);
            
        }

        public void GetDamage(int damage)
        {
            //�ҷ� hp�� �ٿ��ߴ�
            bulletHp -= damage;
            if (bulletHp <= 0)
            {
                bulletHp = 0;
                gameObject.SetActive(false);
            }
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        protected virtual void OnEnable()
        {
            bulletHp = resetHp;
=======
=======
>>>>>>> Stashed changes
        private void OnEnable()
        {
            bulletHp = resetbulletHp;


<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        }
    }
}