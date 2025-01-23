/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * �߻��ϰ��� �ϴ� ������Ʈ�� ������ ��ũ��Ʈ
 * ���� ���� �߻簡�� Ǯ���ؾ���
*/

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.ObjectPooling;

//�߻�ü ���� ����, ���� , 2�������� �,3�� ������ �
namespace ArmadaInvencible.CHM
{
    public class BulletShotContrller : MonoBehaviour
    {
        [SerializeField]

        //�߻�ü ���� ������ ����
        private BulletType bulletType;

        [SerializeField]

        //�߻�ü ���� 
        private int bulletCount;

        [SerializeField]

        //��Ÿ��
        private float cooldownTime;

        [SerializeField]

        //�߻�ü�� �����Ǵ� Ʈ������ ������Ʈ 
        private Transform bulletSpawnPoint;

        [SerializeField]

        //��ǥ��
        private GameObject target;

        [SerializeField]

        //�߻�ü ������ ���� ����  
        private float attackRate;

        [SerializeField]

        private SerializableDictionary<BulletType, GameObjectPool<Bulletbase>> bulletPool;

        //���� �߻�ü ����
        private int currentBulletIndex = 0;

        //�߻�ü ������ ���� ���� ���� ����
        private float currentAttackRate = 0;

        //��Ÿ�� ��������� ���� ����
        private float currentCooldownTime = 0;

        public bool IsSkillAvailable => (Time.time - currentCooldownTime > cooldownTime);
        //��ų ��� ���ɿ��� ��ȯ�ϴ� IsSkillAvailable ������Ƽ

        private void Update()
        {
            OnSkill();
        }

        public void OnSkill()
        {
            //��ų�� ��� ������ �������� �˻� (��Ÿ��)
            if (IsSkillAvailable == false)
            {
                return;
            }

            //�߻�ü ����           
            //attackRate �ֱ�� �߻�ü ����
            //�� �ð����� -currentAttackRate �� �� ���� attackRate���� ũ��
            if (Time.time - currentAttackRate > attackRate)
            {
                GenerationBullet();

                currentBulletIndex++;

                currentAttackRate = Time.time;//currentAttackRate ���� ����ð����� �ʱ�ȭ                                
            }

            //BulletCount ������ŭ �߻�ü�� ������ �� ��Ÿ�� �ʱ�ȭ
            //������ ������ŭ �߻�ü�� ������ currentBulletIndex�� BuletCount���� ũ�ų� ������
            if (currentBulletIndex >= bulletCount)
            {
                //��Ÿ�� �ʱ�ȭ
                currentCooldownTime = Time.time;

                //currentBulletIndex �ʱ�ȭ
                currentBulletIndex = 0;
            }
        }

        public void GenerationBullet()
        {
            var clone = bulletPool[bulletType].Generate();

            clone.transform.position = bulletSpawnPoint.transform.position;

            //Quaternion.identity�� "ȸ�� ����"�� �ǹ� ������Ʈ�� �Ϻ��ϰ� ���� ��ǥ �� �Ǵ� �θ��� ������ ����
            //clone.transform.rotation = Quaternion.identity;

            clone.Setup("Straight", target, bulletCount, currentBulletIndex);

            clone.gameObject.SetActive(true);
        }
    }

    public enum BulletType
    {
        Straight,

        Homing,

        QuadraticHoming,

        CubicHoming,

        BezierCurvesShot
    }
}