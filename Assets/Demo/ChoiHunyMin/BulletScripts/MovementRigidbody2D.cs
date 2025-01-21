/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * ������ٵ� ���� �������� ��ũ��Ʈ
*/
using UnityEngine;

namespace CHM
{
    public class MovementRigidbody2D : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 10f;// �̵��ӵ�
        private Rigidbody2D rigid2D;//������ٵ� ����

        public float MoveSpeed => moveSpeed;//�ܺο��� �̵��ӵ� Ȯ���Ҽ��ֵ��� Get ������Ƽ

        private void Awake()
        {
            rigid2D = GetComponent<Rigidbody2D>();//������ ����
        }

        //�ܺο��� ���⼳���Ҷ� ȣ���ϴ� �޼���
        public void MoveTo(Vector3 direction)
        {
            rigid2D.velocity = direction * moveSpeed;
            //rigid2D.velocity(�ӷ�) = ����(direction) * �ӵ�(MoveSpeed)
        }

    }
}