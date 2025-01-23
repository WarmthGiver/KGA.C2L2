using ArmadaInvencible.ZL;

using UnityEngine;

namespace ArmadaInvencible.J0
{
    public class Explosion : MonoBehaviour
    {
        private int damage;

        public void Initialize(int damage)
        {
            this.damage = damage;
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<IDamageable>()?.GetDamage(damage);
            }
        }
    }
}