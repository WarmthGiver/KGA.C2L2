/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * �翷���� � �˵� �׸��� �߻��ϴ� �Ѿ�
*/

using UnityEngine;

namespace CHM
{
    public class QuadraticHomingBullet : Bulletbase
    {
        //��������, ������ (��ǥ) ,�߰�����
        private Vector2 start, end, point;

        //�߻�ü ����ð� , ������ġ�� ���� t
        private float duration, t = 0f;

        [SerializeField] private int indexx;

        //��ǥ ����
        private GameObject target;

        private float distance;

        public override void Setup(string v, GameObject target, int maxCount = 1, int index =0)
        {
            base.Setup("QuadraticHomingBullet", target);

            //�Ű������� ������ Ÿ�� ����ֱ�
            this.target = target;
            this.indexx = index;
            //�������� ������ġ
            start = transform.position;

            //�� ���� ��ǥ�� Ʈ������
            end = this.target.transform.position;
            
            //���� �������� ��ǥ������ �Ÿ� ���
            distance = Vector3.Distance(start, end);

            //����ð� ���� (�Ÿ� / �̵��ӵ�)
            //�Ÿ��� ���� distance���� �޶����� ������ ������ �ӵ��� �̵�
            duration = distance/ movementRigidbody2D.MoveSpeed;

            //��� �߻�ü�� point�� �����ϰ� 45�� ���� ��ġ�� ����
            //float angle = 45;

            //������ ���� ������ ������ �������� ��ġ ����
            //0 ���� ������ ������ ���ѷ� ��ġ�� ����Ʈ�� ����
            float angle = 360 / maxCount * index;

            //������ ���� �� or �Ʒ� �밢�� (45 or 315��)��ġ�� ���� index�� Ȧ���� 45, ¦���� 315
            //float angle = 45 + 315 * (indexx % 2);

            //���� ������ġ�� ȸ�� �� ������ ����  angle ���� �����ش�
            angle += Utils.GetAngleFromPosition(start, end);

            //���� �������� ��ǥ���� ������ angle ������ 30% ��������ġ
            point = Utils.GetCirclePoint(start, angle, distance * 0.2f);

            //poubt ��ġ Ȯ���� ���� ����� �ڵ� [��� Ȯ���� ����]
            //����Ʈ��ġ�� ���ꤿ��Ʈ�� �����ϵ��� ����� �ڵ� �ۼ�
            //GameObject clone = Instantiate(gameObject, point, Quaternion.identity);

            //clone.GetComponent<QuadraticHoming>().enabled = false;

            //clone.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
        public override void Process()
        {
            //���� ��ǥ�� ��ġ��
            end = target.transform.position;

            //duration�� �ð����� t �� 0.0 ~ 1.0���� ���������� �ٲ�� ����
            t += Time.deltaTime / duration; 

            //�߻�ü�� ������ġ�� Utils.QuadraticCurve�޼��带 ȣ����
            //���ۺ��� ��ǥ���� �߰������� ����Ʈ ������ �������� ��̵��ϵ��� ����
            transform.position = Utils.QuadraticCurve(start, point, end, t);

            transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            t = 0;

            distance = Vector3.Distance(start, end);
        }
    }
}