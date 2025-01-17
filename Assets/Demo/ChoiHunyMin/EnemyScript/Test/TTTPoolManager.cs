using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHM
{
    public class TTTPoolManager : MonoBehaviour
    {
        public static TTTPoolManager instance;
        public GameObject[] enemyPrefabs;//적 프리팹
        List<GameObject>[] enemyPool;//풀 담당 리스트

        private void Awake()//enemypool 모든 오브젝트 풀 초기화
        {
            if (instance == null)
            {
            TTTPoolManager.instance = this;
            }

            enemyPool = new List<GameObject>[enemyPrefabs.Length];
            for (int index = 0; index < enemyPool.Length; index++)
            {
                enemyPool[index] = new List<GameObject>();
            }

        }
        public GameObject Get(int index)//오브젝트 반환 함수
        {
            GameObject select = null;

            foreach (GameObject enemy in enemyPool[index])
            {
                if (!enemy.activeSelf)
                {
                    select = enemy;
                    select.SetActive(true);
                    break;
                }
            }
            if (!select)
            {
                select = Instantiate(enemyPrefabs[index], transform);
                enemyPool[index].Add(select);
            }
            return select;
        }


        void Update()
        {
        }
    }
}