/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 발사하고자 하는 오브젝트에 붙히는 스크립트
 * 종류 별로 발사가능 풀링해야함
*/
using Unity.VisualScripting;
using UnityEngine;
using ZL.Unity.Collections;
using ZL.Unity.ObjectPooling;
public enum BulletType { Straight, Homing, QuadraticHoming, CubicHoming }
//발사체 종류 직선, 유도 , 2차방정식 곡선,3차 방정식 곡선
namespace CHM
{

    public class BulletShotContrller : MonoBehaviour
    {
        
        [SerializeField]
        private BulletType bulletType;//발사체 선택 직선형 먼저
        [SerializeField]
        private int bulletCount = 5;//발사체 갯수
        [SerializeField]
        private float cooldownTime = 2f;//쿨타임         
        [SerializeField]
        private Transform bulletSpawnPoint;//발사체가 생성되는 트랜스폼 컴포넌트 
        [SerializeField]
        private GameObject target;//목표물
        [SerializeField]
        private float attackRate ;//발사체 사이의 사출 간격        
        [SerializeField] private SerializableDictionary<BulletType, GameObjectPool<Bulletbase>> bullet;
        
        private int currentBulletIndex = 0;//현재 발사체 순번
        private float currentAttackRate = 0;//발사체 사이의 사출 간격 연산 변수
        private float currentCooldownTime = 0;//쿨타임 계산을위해 만든 변수

        
        public bool IsSkillAvailable => (Time.time - currentCooldownTime > cooldownTime);
        //스킬 사용 가능여부 반환하는 IsSkillAvailable 프로퍼티

      

        private void Update()
        {
            OnSkill();
        }
        public void OnSkill()
        {
            //스킬이 사용 가능한 상태인지 검사 (쿨타임)
            if (IsSkillAvailable == false) return;

            //발사체 생성
            //열거형에 선언된 숫자와 projectiles[]에 등록할 직선형 번호는 0번이라
            //(int)projectileType = 0 배열 방번호랑 같음
            /*GameObject clone = 
            GameObject.Instantiate(projectiles[(int)projectileType], skillSpawnPoint.position, Quaternion.identity);

            //ProjectileBase.Setup()함수 호출 목표 트랜스 폼과 데미지를 넣어준 상황
            clone.GetComponent<ProjectileBase>().Setup(target, 1);

            //currentCooldownTime에 현재 시간 저장 시간이 currentCooldownTime 만큼 지나면 스킬 사용가능
            currentCooldownTime = Time.time;*/

            //attackRate 주기로 발사체 생성
            //현 시간에서 -currentAttackRate 를 뺀 값이 attackRate보다 크면
            if (Time.time - currentAttackRate > attackRate)
            {
                switch(bulletType)
                { 
                    case BulletType.Straight:
                     //SerializableDictionary 클래스의 GameObjectPool 의 키 값을 projectileType = enum 값으로 생성함
                     var clone = bullet[BulletType.Straight].Generate();
                     clone.transform.position = bulletSpawnPoint.position;
                     clone.transform.rotation = Quaternion.identity;
                     
                     //GameObject.Instantiate(projectiles[(int)projectileType], skillSpawnPoint.position, Quaternion.identity);
                     //squadEnemy();
                     //ProjectileBase.Setup() 메서드의 매개변수가 4개로 늘어남 
                     //발사체 갯수(projectileCount),발사체 현재 순번(currentProjectileIndex)를 추가함
                     clone.Setup(target, 1, bulletCount, currentBulletIndex);
                        currentBulletIndex++;//발사체 생성시 증가
                     currentAttackRate = Time.time;//currentAttackRate 값을 현재시간으로 초기화
                        break;

                    case BulletType.Homing:
                        var homing = bullet[BulletType.Homing].Generate();
                        homing.transform.position = bulletSpawnPoint.position;
                        homing.transform.rotation = Quaternion.identity;
                        homing.Setup(target, 1, bulletCount, currentBulletIndex);
                        currentBulletIndex++;//발사체 생성시 증가
                        currentAttackRate = Time.time;
                        break;

                    case BulletType.QuadraticHoming:
                        var quadraticHoming = bullet[BulletType.QuadraticHoming].Generate();
                        quadraticHoming.transform.position = bulletSpawnPoint.position;
                        quadraticHoming.transform.rotation = Quaternion.identity;
                        quadraticHoming.Setup(target, 1, bulletCount, currentBulletIndex);
                        currentBulletIndex++;//발사체 생성시 증가
                        currentAttackRate = Time.time;
                        break;

                    case BulletType.CubicHoming:
                        var cubicHoming = bullet[BulletType.CubicHoming].Generate();
                        cubicHoming.transform.position = bulletSpawnPoint.position;
                        cubicHoming.transform.rotation = Quaternion.identity;
                        cubicHoming.Setup(target, 1, bulletCount, currentBulletIndex);
                        currentBulletIndex++;//발사체 생성시 증가
                        currentAttackRate = Time.time;
                        break;


                }




            }

            //projectileCount 개수만큼 발사체를 생성한 후 쿨타임 초기화
            //지정된 개수만큼 발사체를 생성해 currentProjectileIndex가 projectileCount보다 크거나 같으면
            if (currentBulletIndex >= bulletCount)
            {
                //currentProjectileIndex = 0;//currentProjectileIndex 를 0으로 만들고
                currentCooldownTime = Time.time;
                //currentCooldownTime을 현재 시간으로 초기화해 다시 스킬 쿨타임이 초기화 될때 까지 대기함
            }
        }
        

    }
}