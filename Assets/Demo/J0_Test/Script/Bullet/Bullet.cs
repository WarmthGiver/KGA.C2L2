using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ZL.Unity;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D bulletRigid;

    protected int damage;
    protected float speed;

    protected virtual void Update()
    {
        BulletMovement();
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

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamageable>().GetDamage(damage);
            Debug.Log("적 맞음");
            gameObject.SetActive(false);
        }
    }
}
