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
            Debug.Log("적 맞음");
            gameObject.SetActive(false);
        }
    }
    protected void IfOutRange()
    {
        if (gameObject.transform.position.x > 10f || gameObject.transform.position.x < -10f || gameObject.transform.position.y > 10f || gameObject.transform.position.y < -10f)
        {
            Debug.Log("범위 밖");
            gameObject.SetActive(false);
        }
    }
}
