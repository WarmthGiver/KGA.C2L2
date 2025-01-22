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
        int count;
        //Setup �޼��� ������
        public override void Setup(GameObject target, int maxCount = 10, int index = 0)
        {
            base.Setup(target, maxCount);

            this.target = target;//Ÿ�������� �޾ƿ� 
            count = maxCount;
        }
        public override void Process()
        {
            movementRigidbody2D.MoveTo((target.transform.position - transform.position).normalized);

            transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
           
        }
       
    }
}