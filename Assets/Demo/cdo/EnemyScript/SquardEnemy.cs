/* 
 * 작성자: 최동오
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 군집형 프리팹이 파괴되면 사라지게함
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHM
{

    public class SquardEnemy : MonoBehaviour
    {
        //enemy프리팹
        [SerializeField] private GameObject prefab1;
        [SerializeField] private GameObject prefab2;
        [SerializeField] private GameObject prefab3;

        private void Update()
        {

            //프리팹 다 파괴되면 오브젝트 파괴
            if (prefab1 == null && prefab2 == null && prefab3 == null)
            {
                Destroy(gameObject);

            }

        }

    }

}