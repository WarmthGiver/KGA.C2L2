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

    public class BulletShotContrller : Bulletbase
    {
        
        [SerializeField]
        private BulletType bulletType;//�߻�ü ���� ������ ����
        [SerializeField]
        private int bulletCount;//�߻�ü ����
        [SerializeField]
        private int count;
        [SerializeField]
        private float cooldownTime;//��Ÿ��         
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
            // if (Input.GetKeyDown(KeyCode.V))
            // {
            // }

        }
        float time;
        public void OnSkill()
        {
            time += Time.deltaTime;
            
            //��ų�� ��� ������ �������� �˻� (��Ÿ��)
            if (IsSkillAvailable == false) return;

            //�߻�ü ����           
            //attackRate �ֱ�� �߻�ü ����
            //�� �ð����� -currentAttackRate �� �� ���� attackRate���� ũ��
            if (time > attackRate)
            {
                generationBullet();
                currentAttackRate = Time.time;//currentAttackRate ���� ����ð����� �ʱ�ȭ
                time = 0;                              

            }

            //BulletCount ������ŭ �߻�ü�� ������ �� ��Ÿ�� �ʱ�ȭ
            //������ ������ŭ �߻�ü�� ������ currentBulletIndex�� BuletCount���� ũ�ų� ������
            if (cooldownTime >= count)
            {
                //generationBullet();
                currentBulletIndex = 0;//currentProjectileIndex �� 0���� �����
                currentCooldownTime = Time.time;
                //currentCooldownTime�� ���� �ð����� �ʱ�ȭ�� �ٽ� ��ų ��Ÿ���� �ʱ�ȭ �ɶ� ���� �����
            }
        }
        public void generationBullet()
        {
            for (int i = 0; i < bulletCount; i++)
            {
                var clone = bullet[bulletType].Generate();
                clone.transform.position = bulletSpawnPoint.position;
                //Quaternion.identity  =���ʹϾ��� "ȸ�� ����"�� �ǹ� ������Ʈ�� �Ϻ��ϰ� ���� ��ǥ �� �Ǵ� �θ��� ������ ����
                clone.transform.rotation = Quaternion.identity;
                clone.Setup(target, count, currentBulletIndex);
                clone.gameObject.SetActive(true);
            }
        }

        public override void Process() { }
        

    }
}