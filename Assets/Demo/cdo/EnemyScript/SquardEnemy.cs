/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: ������ �������� �ı��Ǹ� ���������
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGA
{

    public class SquardEnemy : MonoBehaviour
    {
        //enemy������
        [SerializeField] private GameObject prefab1;
        [SerializeField] private GameObject prefab2;

        private void FixedUpdate()
        {
            //������ �� �ı��Ǹ� ������Ʈ �ı�
            if (prefab1 == null && prefab2 == null)
            {
                Destroy(gameObject);

            }

        }

    }

}