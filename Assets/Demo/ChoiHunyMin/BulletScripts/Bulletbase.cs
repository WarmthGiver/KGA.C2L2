/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * 4���� �Ѿ� �˵� ����� �Ѿ� Ŭ����
*/
using UnityEngine;
using ZL.Unity.Collections;
using ZL.Unity.ObjectPooling;

namespace CHM
{
    public abstract class Bulletbase : MonoBehaviour
    {
        //������ �����

        //[SerializeField]
        //private GameObject hitEffect; //�ǰ� ����Ʈ ������
        protected MovementRigidbody2D movementRigidbody2D;//�̵����� MovementRigidbody2D ����
        //[SerializeField] private SerializableDictionary<string, GameObjectPool<Bulletbase>> bullet;

        //Setup �޼���� �ڽ� Ŭ�������� ������ �Ҽ� �ֵ��� virtual�޼���� ����
        //�� 4���� �Ű����� (��ǥ , ���ݷ� , �߻�ü ���� , �߻�ü ����)
        public virtual void Setup(Transform target, float damage, int maxCount = 1, int index = 0)
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
                //�ǰ� ������ ȣ���ϰ�
                //Instantiate(hitEffect, transform.position, Quaternion.identity);
                //�ڱ��ڽ� ����
                //Destroy(gameObject);
                gameObject.SetActive(false);
                //�� ĳ���� �ǰ� ó��
            }
        }
        //void squadEnemy()
        //{
        //    //Instantiate(dictinary, transform.position, transform.rotation);
        //    Bulletbase straightEnemy = dictinary["Buellet"].Generate();
        //    straightEnemy.transform.position = transform.position;
        //    straightEnemy.transform.rotation = transform.rotation;
        //}

    }
}