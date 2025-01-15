/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/15
 * 수정 및 추가 내용: 총알 발사 시 마우스 커서 위치를 향하도록 함 - 2일차
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMuzzle : MonoBehaviour
{
    [SerializeField] 
    ObjectPooligTest bullets;



    [SerializeField] 
    private float coolTime = 0.4f; // 임시 쿨타임

    private int bulletInitCount = 10;

    private float elapsedCoolTime;

    private float tempBulletSpeed;

    void Start()
    {
        tempBulletSpeed = 10f;

        elapsedCoolTime = coolTime;

        bullets.SetBullet(bulletInitCount);
    }

    void Update()
    {
        elapsedCoolTime += Time.deltaTime;

        if (elapsedCoolTime > coolTime)
        {
            // Shift 누를 시 마우스 커서로 집중공격
            if (Input.GetKey(KeyCode.LeftShift) == true)
            {
                // 집중공격
            }
            // 일반적인 평행 공격
            else
            {
                ParallelAttack(MouseCursor.mainDirectionVec.normalized * tempBulletSpeed);
                Debug.Log("main" + MouseCursor.mainDirectionVec);
            }
        }
    }

    //// 집중 공격
    //public void MassiveAttack(Vector3 velocity)

    // 평행 공격
    public void ParallelAttack(Vector3 velocity)
    {
        var tempBullet = bullets.DequeueBullet();

        tempBullet.transform.position = transform.position;

        tempBullet.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(MouseCursor.mainDirectionVec));

        tempBullet.GetComponent<Rigidbody2D>().velocity = velocity;

        elapsedCoolTime = 0;
    }

    // 마우스 커서 향하도록
    public float AngleCalculator(Vector3 headingTo)
    {
        // 방향벡터와 아크탄젠트를 사용해서 변화 각을 알아낸 다음 라디안값으로 변환시킴.  
        return Mathf.Atan2(headingTo.y, headingTo.x) * Mathf.Rad2Deg + 90;
    } 
}
