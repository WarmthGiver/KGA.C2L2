/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * 3�� �������� �̿��� �Ѿ� s �� �˵�
*/
using UnityEngine;
namespace CHM
{
    public class CubicHomingBullet : Bulletbase
    {
        private Vector2 start,end,point1,point2;
        private float duration, t = 0f;
        private GameObject target;
        private float distance;

        public override void Setup(GameObject target, int maxCount = 1, int index= 0)
        {
            base.Setup(target,maxCount);

            this.target = target;
            start =transform.position;
            end = this.target.transform.position;

            //���� �������� ��ǥ������ �Ÿ� ���
            distance = Vector3.Distance(start,end);
            //����ð� ���� (�Ÿ� / �̵��ӵ�)
            duration = distance / movementRigidbody2D.MoveSpeed;

            float angle = 45;
            //���� �÷��̾��� ȸ�� �� ������ ���� angle ���� �����ش�
            angle += Utils.GetAngleFromPosition(start, end);
            //������������ ��ǥ���� ������ �ޱ�, �ޱ� * -1 ������ 30% 70% ������ ��ġ
            point1 = Utils.GetNewPoint(start, angle,distance * 0.1f);
            point2 = Utils.GetNewPoint(end, angle * -1, distance * 0.9f);
            //Ÿ�� �ٶ󺸰� ��
        }
        public override void Process()
        {
            end = this.target.transform.position;
            t += Time.deltaTime / duration;
            transform.position = Utils.CubicCurve(start, point1, point2, end, t);
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