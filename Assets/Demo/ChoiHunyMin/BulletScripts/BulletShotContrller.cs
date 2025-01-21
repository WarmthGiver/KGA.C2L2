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
            //�������� ����� ���ڿ� projectiles[]�� ����� ������ ��ȣ�� 0���̶�
            //(int)projectileType = 0 �迭 ���ȣ�� ����
            /*GameObject clone = 
            GameObject.Instantiate(projectiles[(int)projectileType], skillSpawnPoint.position, Quaternion.identity);

            //ProjectileBase.Setup()�Լ� ȣ�� ��ǥ Ʈ���� ���� �������� �־��� ��Ȳ
            clone.GetComponent<ProjectileBase>().Setup(target, 1);

            //currentCooldownTime�� ���� �ð� ���� �ð��� currentCooldownTime ��ŭ ������ ��ų ��밡��
            currentCooldownTime = Time.time;*/

            //attackRate �ֱ�� �߻�ü ����
            //�� �ð����� -currentAttackRate �� �� ���� attackRate���� ũ��
            if (Time.time - currentAttackRate > attackRate)
            {
                switch(bulletType)
                { 
                    case BulletType.Straight:
                     //SerializableDictionary Ŭ������ GameObjectPool �� Ű ���� projectileType = enum ������ ������
                     var clone = bullet[BulletType.Straight].Generate();
                     clone.transform.position = bulletSpawnPoint.position;
                     clone.transform.rotation = Quaternion.identity;
                     
                     //GameObject.Instantiate(projectiles[(int)projectileType], skillSpawnPoint.position, Quaternion.identity);
                     //squadEnemy();
                     //ProjectileBase.Setup() �޼����� �Ű������� 4���� �þ 
                     //�߻�ü ����(projectileCount),�߻�ü ���� ����(currentProjectileIndex)�� �߰���
                     clone.Setup(target, 1, bulletCount, currentBulletIndex);
                        currentBulletIndex++;//�߻�ü ������ ����
                     currentAttackRate = Time.time;//currentAttackRate ���� ����ð����� �ʱ�ȭ
                        break;

                    case BulletType.Homing:
                        var homing = bullet[BulletType.Homing].Generate();
                        homing.transform.position = bulletSpawnPoint.position;
                        homing.transform.rotation = Quaternion.identity;
                        homing.Setup(target, 1, bulletCount, currentBulletIndex);
                        currentBulletIndex++;//�߻�ü ������ ����
                        currentAttackRate = Time.time;
                        break;

                    case BulletType.QuadraticHoming:
                        var quadraticHoming = bullet[BulletType.QuadraticHoming].Generate();
                        quadraticHoming.transform.position = bulletSpawnPoint.position;
                        quadraticHoming.transform.rotation = Quaternion.identity;
                        quadraticHoming.Setup(target, 1, bulletCount, currentBulletIndex);
                        currentBulletIndex++;//�߻�ü ������ ����
                        currentAttackRate = Time.time;
                        break;

                    case BulletType.CubicHoming:
                        var cubicHoming = bullet[BulletType.CubicHoming].Generate();
                        cubicHoming.transform.position = bulletSpawnPoint.position;
                        cubicHoming.transform.rotation = Quaternion.identity;
                        cubicHoming.Setup(target, 1, bulletCount, currentBulletIndex);
                        currentBulletIndex++;//�߻�ü ������ ����
                        currentAttackRate = Time.time;
                        break;


                }




            }

            //projectileCount ������ŭ �߻�ü�� ������ �� ��Ÿ�� �ʱ�ȭ
            //������ ������ŭ �߻�ü�� ������ currentProjectileIndex�� projectileCount���� ũ�ų� ������
            if (currentBulletIndex >= bulletCount)
            {
                //currentProjectileIndex = 0;//currentProjectileIndex �� 0���� �����
                currentCooldownTime = Time.time;
                //currentCooldownTime�� ���� �ð����� �ʱ�ȭ�� �ٽ� ��ų ��Ÿ���� �ʱ�ȭ �ɶ� ���� �����
            }
        }
        

    }
}