/* 
 * 작성자: 최동오
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 나선형 적 생성(인스턴스)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cdo
{

    public class SpiralEnemySpawner : MonoBehaviour
    {
        //적 프리팹
        [SerializeField] private GameObject prefab;
        //나올 위치
        [SerializeField] private Transform spawnPoint;

        //임시 축
        public GameObject axis;

        //쿨타임
        [SerializeField] private float coolTime = 0;
        [SerializeField] private float timeDley = 100f;


        void Update()
        {
            
            if(coolTime> timeDley)
            {
                Instantiate(prefab, spawnPoint.position, transform.rotation);
                coolTime = 0;
            }

            //임시 나올자리 원으로 돔
            transform.RotateAround(axis.transform.position, Vector3.forward, 20 * Time.deltaTime);

            //마우스 클릭시 미사일 활성화
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(prefab, spawnPoint.position, transform.rotation);
                //obj1.SetActive(true);
            }
            if (Input.GetMouseButtonDown(1))
            {
                var dod = transform.rotation;
                dod.z = -180;
                transform.rotation = dod;
                transform.position = new Vector3(4.5f, 0, 0);
            }
           


        }



    }
}