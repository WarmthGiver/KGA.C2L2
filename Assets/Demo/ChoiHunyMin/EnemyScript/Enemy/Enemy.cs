using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float enemyHp;//적 체력
        //[SerializeField] protected float speed;
        [SerializeField] protected float damage;
        [SerializeField] protected Vector3 target = new Vector3(0,0,0);//일단 중심점
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
                //gameObject.SetActive(false);
            }


        }
    }

