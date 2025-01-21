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
    public abstract class Bulletbase : MonoBehaviour
    {
        //������ �����
        [SerializeField]
        private GameObject Animator;        
        
        //[SerializeField]
        //private GameObject hitEffect; //�ǰ� ����Ʈ ������
        protected MovementRigidbody2D movementRigidbody2D;//�̵����� MovementRigidbody2D ����       

        //Setup �޼���� �ڽ� Ŭ�������� ������ �Ҽ� �ֵ��� virtual�޼���� ����
        //�� 4���� �Ű����� (��ǥ , ���ݷ� , �߻�ü ���� , �߻�ü ����)
        public virtual void Setup(GameObject target, float damage, int maxCount = 1, int index = 0)
        {
            movementRigidbody2D = GetComponent<MovementRigidbody2D>();
        }
        private void Update()
        {
            Process();
            Test.stop();
        }
        //�߻�ü�� ������Ʈ �� ���� ȣ���� Process �޼���
        //�߻�ü ������ ���� �ڽ� Ŭ�������� �����Ҽ��ֵ��� �߻�(abstract) �޼���� ����
        public abstract void Process();
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                squadAnimator();  
                
                gameObject.SetActive(false);
               
            }
        }
        void squadAnimator()
        {
            Instantiate(Animator, transform.position, transform.rotation);
            
        }
       

        

    }
}