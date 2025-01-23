using ArmadaInvencible.ZL;

using UnityEngine;

namespace ArmadaInvencible.J0
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]

        protected Rigidbody2D bulletRigid;

        protected int damage;

        protected float speed;

        [SerializeField]

        protected TrailRenderer trailRenderer;

        protected virtual void Update()
        {
            BulletMovement();

            IfOutRange();
        }

        protected virtual void BulletMovement()
        {
            bulletRigid.AddForce(transform.up.normalized * speed * 5 * Time.timeScale, ForceMode2D.Impulse);
        }

        public void Initialize(int damage, float speed)
        {
            this.damage = damage;

            this.speed = speed;
        }

        protected virtual void OnDisable()
        {
            trailRenderer.Clear();
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<IDamageable>()?.GetDamage(damage);

                gameObject.SetActive(false);
            }
        }

        protected void IfOutRange()
        {
            if (gameObject.transform.position.x > 10f || gameObject.transform.position.x < -10f || gameObject.transform.position.y > 10f || gameObject.transform.position.y < -10f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}