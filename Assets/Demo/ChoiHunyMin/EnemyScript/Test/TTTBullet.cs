using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTTBullet : MonoBehaviour
{
    
    [SerializeField] protected float enemyBulletHp;
    [SerializeField] protected float enemyBulletDmg;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyBulletHp--;
            if (enemyBulletHp <= 0)
            {
                enemyBulletHp = 0;
                //Destroy(collision.gameObject);//총알을 지우는 코드
                Destroy(gameObject);

            }

        }
    }
}