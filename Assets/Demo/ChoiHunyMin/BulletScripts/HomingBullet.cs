/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * �����Ѿ�
*/
using UnityEngine;
namespace CHM
{
    public class HomingBullet : Bulletbase
    {
        //���� �̻���
        private Transform target;

        //Setup �޼��� ������
        public override void Setup(Transform target, float damage, int maxCount = 1, int index = 0)
        {
            base.Setup(target, damage);

            this.target = target;//Ÿ�������� �޾ƿ� 
            
        }
        public override void Process()
        {
            movementRigidbody2D.MoveTo((target.position - transform.position).normalized);
            transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
            //�߻�ü �̵����� ����
            //transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
        }
    }
}