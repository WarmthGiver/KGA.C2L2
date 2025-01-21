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
        public override void Setup(GameObject target, float damage, int maxCount = 1, int index = 0)
        {
            base.Setup(target, damage);
            
            //�߻�ü �̵����� ����
            //��ǥ��ġ - �� ��ġ �� �� ��ġ������ ��ǥ ��ġ�ΰ��� ���� ����
            //��Į�� ���Ե� �����̱� ������ ��ֶ������ 0.0 ~ 1.0 ������ ������ ����ȭ
            movementRigidbody2D.MoveTo((target.transform.position - transform.position).normalized);
            quaternion = Utils.LookTaget(transform.position, target.transform.position);
            
        }
        
        //�θ� Ŭ�������� �߻����� �����̵� �޼ҵ�� �ڽ�Ŭ�������� �� ������ �ؾ���
        //�ƹ�����̾�� Process() �޼ҵ� ����������� ������ �ȶ��
        public override void Process() 
        {
            transform.rotation = quaternion;
        }

        




    }
}