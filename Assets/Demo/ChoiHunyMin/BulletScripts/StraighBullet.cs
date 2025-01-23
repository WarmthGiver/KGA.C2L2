/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * �������� ��� �Ѿ� ��ũ��Ʈ
*/
using Unity.Mathematics;
using UnityEngine;
namespace CHM
{
    public class StraighBullet : Bulletbase
    //ProjectileBase�� ��ӹ޴� ������ �߻�ü
    {
        //Setup �޼��带 ������(override)�ϰ� base.Setup���� �θ� Ŭ������ Setup�� ȣ����
        Quaternion quaternion;
        private GameObject target;
        public override void Setup(string v, GameObject target, int maxCount = 1, int index = 0)
        {
            base.Setup("StraighBullet", target, maxCount);
            this.target = target;
            //�߻�ü �̵����� ����
            //��ǥ��ġ - �� ��ġ �� �� ��ġ������ ��ǥ ��ġ�ΰ��� ���� ����
            //��Į�� ���Ե� �����̱� ������ ��ֶ������ 0.0 ~ 1.0 ������ ������ ����ȭ
            
        }
        
        //�θ� Ŭ�������� �߻����� ���ǵ� �޼ҵ�� �ڽ�Ŭ�������� �� ������ �ؾ���
        //�ƹ�����̾�� Process() �޼ҵ� ����������� ������ �ȶ��
        public override void Process() 
        {
            movementRigidbody2D.MoveTo((target.transform.position - transform.position).normalized);
            quaternion = Utils.LookTaget(transform.position, target.transform.position);
            transform.rotation = quaternion;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
           
        }




    }
}