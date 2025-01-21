/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 4가지 총알 궤도 사용할 총알 클래스
*/
using UnityEngine;
using ZL.Unity.Collections;
using ZL.Unity.ObjectPooling;

namespace CHM
{
    public abstract class Bulletbase : MonoBehaviour
    {
        //프리팹 상속자

        //[SerializeField]
        //private GameObject hitEffect; //피격 임팩트 프리팹
        protected MovementRigidbody2D movementRigidbody2D;//이동제어 MovementRigidbody2D 변수
        //[SerializeField] private SerializableDictionary<string, GameObjectPool<Bulletbase>> bullet;

        //Setup 메서드는 자식 클래스에서 재정의 할수 있도록 virtual메서드로 만듬
        //총 4개의 매개변수 (목표 , 공격력 , 발사체 개수 , 발사체 순번)
        public virtual void Setup(Transform target, float damage, int maxCount = 1, int index = 0)
        {
            movementRigidbody2D = GetComponent<MovementRigidbody2D>();
        }
        private void Update()
        {
            Process();
            
        }
        //발사체가 업데이트 할 동안 호출할 Process 메서드
        //발사체 유형에 따라 자식 클래스에서 정의할수있도록 추상(abstract) 메서드로 만듬
        public abstract void Process();
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //피격 프리팹 호출하고
                //Instantiate(hitEffect, transform.position, Quaternion.identity);
                //자기자신 삭제
                //Destroy(gameObject);
                gameObject.SetActive(false);
                //적 캐릭터 피격 처리
            }
        }
        //void squadEnemy()
        //{
        //    //Instantiate(dictinary, transform.position, transform.rotation);
        //    Bulletbase straightEnemy = dictinary["Buellet"].Generate();
        //    straightEnemy.transform.position = transform.position;
        //    straightEnemy.transform.rotation = transform.rotation;
        //}

    }
}