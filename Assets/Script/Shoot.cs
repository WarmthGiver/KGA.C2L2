/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 총알 발사 시 마우스 커서 위치를 향하도록 함
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] 
    ObjectPooligTest bullets;

    [SerializeField] 
    private float coolTime = 0.4f; // 임시 쿨타임

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
            ShootBullet(MouseCursor.directionVec.normalized * 10f); // 임시 총알 속도
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

    // 총알 발사 각도 조정(마우스 커서 향함)
    public float AngleCalculator()
    {
        // 방향벡터와 아크탄젠트를 사용해서 변화 각을 알아낸 다음 라디안값으로 변환시킴.
        return Mathf.Atan2(MouseCursor.directionVec.y, MouseCursor.directionVec.x) * Mathf.Rad2Deg + 90;
    } 
}
