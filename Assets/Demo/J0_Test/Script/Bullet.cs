using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D bulletRigid;

    private int damage;
    private float speed;

    void Start()
    {
        
    }

    void Update()
    {
        bulletRigid.AddForce(transform.up.normalized * speed, ForceMode2D.Impulse);

        // 범위 밖 나가면 지우기
        if (transform.position.x < -20f || transform.position.x > 20f || transform.position.y < -20f || transform.position.y > 20f)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(int damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
    }
}
