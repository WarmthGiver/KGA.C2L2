/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/13
 * 수정 및 추가 내용: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Weapon클래스에서 넘어온 총알 정보를 받아서 발사하는 것 만 함.
public class BulletController : MonoBehaviour
{
    public ObjectPooligTest bulletPool;

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Range(경계 범위)에 닿으면
        if (collision.gameObject.tag == "Range")
        {
            // 오브젝트 비활성화
            gameObject.SetActive(false);
        }
    }

    // 오브젝트 비활성화 시 pool에 담기
    private void OnDisable()
    {
        bulletPool.EnqueueBullet(this);
    }
}
