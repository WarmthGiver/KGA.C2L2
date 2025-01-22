/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * �翷���� � �˵� �׸��� �߻��ϴ� �Ѿ�
*/
using Unity.VisualScripting;
using UnityEngine;
namespace CHM
{
    public class QuadraticHomingBullet : Bulletbase
    {
        
        
        private Vector2 start, end, point;//��������, ������ (��ǥ) ,�߰�����
        private float duration, t = 0f;//�߻�ü ����ð� , ������ġ�� ���� t
        private GameObject target;//��ǥ ����
        private float distance;
        public override void Setup(GameObject target, int maxCount = 1, int index = 0)
        {
            base.Setup(target,maxCount);

            this.target = target;//�Ű������� ������ Ÿ�� ����ֱ�
            start = transform.position;//�������� ������ġ
            end = this.target.transform.position;//�� ���� ��ǥ�� Ʈ������
            
            //���� �������� ��ǥ������ �Ÿ� ���
            distance = Vector3.Distance(start, end);
            //����ð� ���� (�Ÿ� / �̵��ӵ�)
            //�Ÿ��� ���� distance���� �޶����� ������ ������ �ӵ��� �̵�
            duration = distance/ movementRigidbody2D.MoveSpeed;

            //��� �߻�ü�� point�� �����ϰ� 45�� ���� ��ġ�� ����
            //float angle = 45;

            //������ ���� ������ ������ �������� ��ġ ����
            //0 ���� ������ ������ ���ѷ� ��ġ�� ����Ʈ�� ����
            //float angle = 360 / maxCount * index;

            //������ ���� �� or �Ʒ� �밢�� (45 or 315��)��ġ�� ����
            float angle = 45 + 315 * (index % 2);

            //���� ������ġ�� ȸ�� �� ������ ����  angle ���� �����ش�
            angle += Utils.GetAngleFromPosition(start, end);

            //���� �������� ��ǥ���� ������ angle ������ 30% ��������ġ
            point = Utils.GetNewPoint(start, angle, distance * 0.9f);

            //poubt ��ġ Ȯ���� ���� ����� �ڵ� [��� Ȯ���� ����]
            //����Ʈ��ġ�� ���ꤿ��Ʈ�� �����ϵ��� ����� �ڵ� �ۼ�
            //GameObject clone = Instantiate(gameObject, point, Quaternion.identity);
            //clone.GetComponent<QuadraticHoming>().enabled = false;
            //clone.GetComponentInChildren<SpriteRenderer>().color = Color.black;


        }
        public override void Process()
        {
            end = target.transform.position;//���� ��ǥ�� ��ġ��
            t += Time.deltaTime / duration; //duration�� �ð����� t �� 0.0 ~ 1.0���� ���������� �ٲ�� ����
            //�߻�ü�� ������ġ�� Utils.QuadraticCurve�޼��带 ȣ����
            //���ۺ��� ��ǥ���� �߰������� ����Ʈ ������ �������� ��̵��ϵ��� ����
            transform.position = Utils.QuadraticCurve(start, point, end, t);
            transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
        }
        private void OnEnable()
        {
            t = 0;
            distance = Vector3.Distance(start, end);

        }

    }
}