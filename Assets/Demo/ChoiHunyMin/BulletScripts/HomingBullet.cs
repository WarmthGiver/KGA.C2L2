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

        //Setup �޼��� ������
        public override void Setup(GameObject target, float damage, int maxCount = 1, int index = 0)
        {
            base.Setup(target, damage);

            this.target = target;//Ÿ�������� �޾ƿ� 
            
        }
        public override void Process()
        {
            movementRigidbody2D.MoveTo((target.transform.position - transform.position).normalized);

            transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
           
        }
    }
}