using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGA
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float enemyHp;//�� ü��
        //[SerializeField] protected float speed;
        [SerializeField] protected float damage;
        [SerializeField] protected GameObject playerObj;//�ϴ� �߽���

        



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Bullet")
            {
                enemyHp--;
                if (enemyHp <= 0)
                {
                    enemyHp = 0;
                    //Destroy(collision.gameObject);
                    Destroy(gameObject);

                }

            }
        }
    }
}
