using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CHM
{
    public class bulletScript : MonoBehaviour
    {
        [SerializeField] protected GameObject Tagetplayer;//목표
       
        

        void Start()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        void Update()
        {
            //타겟 바라보게 하려고함
            Vector3 direction = Tagetplayer.transform.position - transform.position;//타겟포지션 - 적포지션 값
            direction.Normalize();
            transform.position += direction * 2f * Time.deltaTime;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Vector3 vec = Tagetplayer.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(vec).normalized;
            


        }
    }
}