/*
 * �ۼ���: ������
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �����Ȳ ������ ���鿹����
 * �������Ʈ ���� �ڽ����� ���� ������ 5�� ���Ϳ��� ���缭 �д븦 ����
 * ������ : prefab1�� 0���� �������� ������� �ٰ��� ������� ��
 * �ǵ�� : �������� �Ѱ��� ���� ��ǥ���� �����ؼ� �д��������� ����� �ϴ� �� ��������
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquad : MonoBehaviour
{    
    [SerializeField]
    private GameObject[] prefab1;
    

    void Update()
    {
        //������ : prefab1�� 0���� �������� ������� �ٰ��� ������� ��
        //for (int i = 0; i < prefab1.Length; i++)
        //{
        //    if (prefab1[i] != null) 
        //        {
        //        return;
        //        }
        //
        //    if (prefab1[i] == null)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }
}
