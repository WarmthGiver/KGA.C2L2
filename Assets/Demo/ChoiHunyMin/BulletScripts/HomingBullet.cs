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
        private GameObject target;

        private int count;

        //Setup �޼��� ������
        public override void Setup(string v, GameObject target, int maxCount = 10, int index = 0)
        {
            base.Setup("HomingBullet",target);

            //Ÿ�������� �޾ƿ� 
            this.target = target;

            count = maxCount;
        }
        public override void Process()
        {
            movementRigidbody2D.MoveTo((target.transform.position - transform.position).normalized);

            transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
        }
    }
}