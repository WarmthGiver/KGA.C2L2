/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * �߻��ϰ��� �ϴ� ������Ʈ�� ������ ��ũ��Ʈ
 * ���� ���� �߻簡�� Ǯ���ؾ���
*/
using Unity.VisualScripting;
using UnityEngine;
using ZL.Unity.Collections;
using ZL.Unity.ObjectPooling;
public enum BulletType { Straight, Homing, QuadraticHoming, CubicHoming }
//�߻�ü ���� ����, ���� , 2�������� �,3�� ������ �
namespace CHM
{

    public class BulletShotContrller : MonoBehaviour
    {
        
        [SerializeField]
        private BulletType bulletType;//�߻�ü ���� ������ ����
        [SerializeField]
        private int bulletCount = 5;//�߻�ü ����
        [SerializeField]
        private float cooldownTime = 2f;//��Ÿ��         
        [SerializeField]
        private Transform bulletSpawnPoint;//�߻�ü�� �����Ǵ� Ʈ������ ������Ʈ 
        [SerializeField]
        private GameObject target;//��ǥ��
        [SerializeField]
        private float attackRate ;//�߻�ü ������ ���� ����        
        [SerializeField] private SerializableDictionary<BulletType, GameObjectPool<Bulletbase>> bullet;
        
        private int currentBulletIndex = 0;//���� �߻�ü ����
        private float currentAttackRate = 0;//�߻�ü ������ ���� ���� ���� ����
        private float currentCooldownTime = 0;//��Ÿ�� ��������� ���� ����

        
        public bool IsSkillAvailable => (Time.time - currentCooldownTime > cooldownTime);
        //��ų ��� ���ɿ��� ��ȯ�ϴ� IsSkillAvailable ������Ƽ

      
        
        private void Update()
        {
            OnSkill();
            
        }
        public void OnSkill()
        {
            //��ų�� ��� ������ �������� �˻� (��Ÿ��)
            if (IsSkillAvailable == false) return;
            //�߻�ü ����           
            //attackRate �ֱ�� �߻�ü ����
            //�� �ð����� -currentAttackRate �� �� ���� attackRate���� ũ��
            if (Time.time - currentAttackRate > attackRate)
            {
                var clone = bullet[bulletType].Generate();
                clone.transform.position = bulletSpawnPoint.position;
                clone.transform.rotation = Quaternion.identity;

                clone.Setup(target, 1, bulletCount, currentBulletIndex);

                currentBulletIndex++;//�߻�ü ������ ����
                currentAttackRate = Time.time;//currentAttackRate ���� ����ð����� �ʱ�ȭ

                
            }

           this.gameObject.SetActive(true);
            //projectileCount ������ŭ �߻�ü�� ������ �� ��Ÿ�� �ʱ�ȭ
            //������ ������ŭ �߻�ü�� ������ currentProjectileIndex�� projectileCount���� ũ�ų� ������
            if (currentBulletIndex >= bulletCount)
            {
                currentBulletIndex = 0;//currentProjectileIndex �� 0���� �����
                currentCooldownTime = Time.time;
                //currentCooldownTime�� ���� �ð����� �ʱ�ȭ�� �ٽ� ��ų ��Ÿ���� �ʱ�ȭ �ɶ� ���� �����
            }
        }
        

    }
}