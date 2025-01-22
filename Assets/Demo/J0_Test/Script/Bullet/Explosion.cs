using ArmadaInvencible;

using UnityEngine;

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
            //Debug.Log("Àû ¸ÂÀ½");

            collision.GetComponent<IDamageable>()?.GetDamage(damage);
        }
    }
}