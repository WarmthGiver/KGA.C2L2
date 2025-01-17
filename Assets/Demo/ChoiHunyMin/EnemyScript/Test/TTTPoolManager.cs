using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHM
{
    public class TTTPoolManager : MonoBehaviour
    {
        public static TTTPoolManager instance;
        public GameObject[] enemyPrefabs;//�� ������
        List<GameObject>[] enemyPool;//Ǯ ��� ����Ʈ

        private void Awake()//enemypool ��� ������Ʈ Ǯ �ʱ�ȭ
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
        public GameObject Get(int index)//������Ʈ ��ȯ �Լ�
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