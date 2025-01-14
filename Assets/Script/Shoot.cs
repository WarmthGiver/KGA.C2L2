/* 
 * �ۼ���: ���翵
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �Ѿ� �߻� �� ���콺 Ŀ�� ��ġ�� ���ϵ��� ��
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] 
    ObjectPooligTest bullets;

    [SerializeField] 
    private float coolTime = 0.4f; // �ӽ� ��Ÿ��

    private int bulletInitCount = 10;

    private float elapsedCoolTime;

    

    void Start()
    {
        elapsedCoolTime = coolTime;

        bullets.SetBullet(bulletInitCount);
    }

    void Update()
    {
        elapsedCoolTime += Time.deltaTime;

        if (elapsedCoolTime > coolTime)
        {
            ShootBullet(MouseCursor.directionVec.normalized * 10f); // �ӽ� �Ѿ� �ӵ�
        }
    }

    public void ShootBullet(Vector3 velocity)
    {
        var tempBullet = bullets.DequeueBullet();

        tempBullet.transform.position = transform.position;

        tempBullet.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator());

        tempBullet.GetComponent<Rigidbody2D>().velocity = velocity;

        elapsedCoolTime = 0;
    }

    // �Ѿ� �߻� ���� ����(���콺 Ŀ�� ����)
    public float AngleCalculator()
    {
        // ���⺤�Ϳ� ��ũź��Ʈ�� ����ؼ� ��ȭ ���� �˾Ƴ� ���� ���Ȱ����� ��ȯ��Ŵ.
        return Mathf.Atan2(MouseCursor.directionVec.y, MouseCursor.directionVec.x) * Mathf.Rad2Deg + 90;
    } 
}
