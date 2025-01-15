using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CHM
{
    public class bulletScript : MonoBehaviour
    {
        [SerializeField] protected GameObject Tagetplayer;//��ǥ
       
        

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
            //Ÿ�� �ٶ󺸰� �Ϸ�����
            Vector3 direction = Tagetplayer.transform.position - transform.position;//Ÿ�������� - �������� ��
            direction.Normalize();
            transform.position += direction * 2f * Time.deltaTime;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Vector3 vec = Tagetplayer.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(vec).normalized;
            


        }
    }
}