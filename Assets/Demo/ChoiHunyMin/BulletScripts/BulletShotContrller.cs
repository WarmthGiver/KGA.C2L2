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

    public class BulletShotContrller : Bulletbase
    {
        
        [SerializeField]
        private BulletType bulletType;//발사체 선택 직선형 먼저
        [SerializeField]
        private int bulletCount;//발사체 갯수
        [SerializeField]
        private int count;
        [SerializeField]
        private float cooldownTime;//쿨타임         
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
            // if (Input.GetKeyDown(KeyCode.V))
            // {
            // }

        }
        float time;
        public void OnSkill()
        {
            time += Time.deltaTime;
            
            //스킬이 사용 가능한 상태인지 검사 (쿨타임)
            if (IsSkillAvailable == false) return;

            //발사체 생성           
            //attackRate 주기로 발사체 생성
            //현 시간에서 -currentAttackRate 를 뺀 값이 attackRate보다 크면
            if (time > attackRate)
            {
                generationBullet();
                currentAttackRate = Time.time;//currentAttackRate 값을 현재시간으로 초기화
                time = 0;                              

            }

            //BulletCount 개수만큼 발사체를 생성한 후 쿨타임 초기화
            //지정된 개수만큼 발사체를 생성해 currentBulletIndex가 BuletCount보다 크거나 같으면
            if (cooldownTime >= count)
            {
                //generationBullet();
                currentBulletIndex = 0;//currentProjectileIndex 를 0으로 만들고
                currentCooldownTime = Time.time;
                //currentCooldownTime을 현재 시간으로 초기화해 다시 스킬 쿨타임이 초기화 될때 까지 대기함
            }
        }
        public void generationBullet()
        {
            for (int i = 0; i < bulletCount; i++)
            {
                var clone = bullet[bulletType].Generate();
                clone.transform.position = bulletSpawnPoint.position;
                //Quaternion.identity  =쿼터니언은 "회전 없음"을 의미 오브젝트는 완벽하게 월드 좌표 축 또는 부모의 축으로 정렬
                clone.transform.rotation = Quaternion.identity;
                clone.Setup(target, count, currentBulletIndex);
                clone.gameObject.SetActive(true);
            }
        }

        public override void Process() { }
        

    }
}