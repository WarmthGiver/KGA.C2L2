/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * ������ٵ� ���� �������� ��ũ��Ʈ
*/

using UnityEngine;

namespace ArmadaInvencible.CHM
{
    public class MovementRigidbody2D : MonoBehaviour
    {
        [SerializeField]

        // �̵��ӵ�
        private float moveSpeed;

        //�ܺο��� �̵��ӵ� Ȯ���Ҽ��ֵ��� Get ������Ƽ
        public float MoveSpeed => moveSpeed;

        //������ٵ� ����
        private Rigidbody2D rigid2D;

        private void Awake()
        {
            rigid2D = GetComponent<Rigidbody2D>();//������ ����
        }

        //�ܺο��� ���⼳���Ҷ� ȣ���ϴ� �޼���
        public void MoveTo(Vector3 direction)
        {
            //rigid2D.velocity(�ӷ�) = ����(direction) * �ӵ�(MoveSpeed)
            rigid2D.velocity = direction * moveSpeed;
        }
    }
}