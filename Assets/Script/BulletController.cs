/* 
 * �ۼ���: ���翵
 * ���� ��¥: 25/01/13
 * ���� �� �߰� ����: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WeaponŬ�������� �Ѿ�� �Ѿ� ������ �޾Ƽ� �߻��ϴ� �� �� ��.
public class BulletController : MonoBehaviour
{
    public ObjectPooligTest bulletPool;

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Range(��� ����)�� ������
        if (collision.gameObject.tag == "Range")
        {
            // ������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }

    // ������Ʈ ��Ȱ��ȭ �� pool�� ���
    private void OnDisable()
    {
        bulletPool.EnqueueBullet(this);
    }
}
