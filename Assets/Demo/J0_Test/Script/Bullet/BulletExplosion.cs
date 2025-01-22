using UnityEngine;

using ZL.Unity.ObjectPooling;

public class BulletExplosion : Bullet
{
    [SerializeField]

    protected GameObjectPool<Explosion> explosionPool;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        // 적 닿으면 폭발이 일어나고 사라짐
        if (collision.CompareTag("Enemy"))
        {
            var explosion = explosionPool.Generate();

            explosion.transform.position = transform.position;

            explosion.Initialize(damage);

            explosion.gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
