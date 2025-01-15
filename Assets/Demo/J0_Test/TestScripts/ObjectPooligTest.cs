/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/13
 * 수정 및 추가 내용: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPooligTest
{
    [SerializeField] 
    private BulletController bullet;

    public Queue<BulletController> bulletQueue = new Queue<BulletController>();

    // 총알 생성
    public BulletController InstantiateBullet()
    {
        BulletController bullet = Object.Instantiate(this.bullet);
        bullet.bulletPool = this;

        return bullet;
    }

    // 총알 Count개 초기화
    public void SetBullet(int Count)
    {
        if(bulletQueue == null)
        {
            for (int i = 0; i < Count; i++)
            {
                BulletController tempBullet = InstantiateBullet();
                bulletQueue.Enqueue(tempBullet);
            }
        }
    }

    public BulletController DequeueBullet()
    {
        BulletController bullet;

        if(bulletQueue.Count > 0)
        {
            bullet = bulletQueue.Dequeue();
        }

        else
        {
            bullet = InstantiateBullet();
        }

        bullet.gameObject.SetActive(true);

        return bullet;
    }
    
    public void EnqueueBullet(BulletController bullet)
    {
        bulletQueue.Enqueue(bullet);
    }
}
