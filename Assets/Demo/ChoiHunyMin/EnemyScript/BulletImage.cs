using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public GameObject bossBullet;
    [SerializeField]
    private float prefabSpeed;//������ ���� �ӵ�
    [SerializeField]
    private float coolTime;//��Ÿ��
   
    void Update()
    {
        coolTime += Time.deltaTime;

        if (coolTime > prefabSpeed)
        {

            //Instantiate(enemyPrefab, transform.position, transform.rotation);
            //������ �ֶ� �����ϴ� �ֶ� �Ȱ��� ��ġ�� ����

            Instantiate(bossBullet, transform.position, transform.rotation);

            coolTime = 0;
        }
    }
}
