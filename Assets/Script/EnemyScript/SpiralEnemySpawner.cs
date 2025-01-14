/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: ������ �� ����(�ν��Ͻ�)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cdo
{

    public class SpiralEnemySpawner : MonoBehaviour
    {
        //�� ������
        [SerializeField] private GameObject prefab;
        //���� ��ġ
        [SerializeField] private Transform spawnPoint;

        //�ӽ� ��
        public GameObject axis;

        //��Ÿ��
        [SerializeField] private float coolTime = 0;
        [SerializeField] private float timeDley = 100f;


        void Update()
        {
            
            if(coolTime> timeDley)
            {
                Instantiate(prefab, spawnPoint.position, transform.rotation);
                coolTime = 0;
            }

            //�ӽ� �����ڸ� ������ ��
            transform.RotateAround(axis.transform.position, Vector3.forward, 20 * Time.deltaTime);

            //���콺 Ŭ���� �̻��� Ȱ��ȭ
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