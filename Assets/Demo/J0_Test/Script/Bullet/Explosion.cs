using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private int time;

    private int damage;

    private void Start()
    {
        StartCoroutine(Remove());
    }

    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamageable>()?.GetDamage(damage);
            Debug.Log("Àû ¸ÂÀ½");
        }
    }


    IEnumerator Remove()
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
