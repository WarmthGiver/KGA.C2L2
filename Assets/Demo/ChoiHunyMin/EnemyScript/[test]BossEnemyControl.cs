using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CHM
{
    public class BossEnemyControl : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;//목표물설정을 위해 받음
        [SerializeField]
        private float speed;//직진 속도
        [SerializeField]
        private int straightEnemyHP;//일단 HP생성

        //public float radius = 4;
        //public float runningspeed = 1f;
        //float runningTime = 0;
        //float speed1=0.1f;
        [SerializeField]
        float circle;//원
        [SerializeField]
        float deg;//각도
        [SerializeField]
        float objSpeed;//원운동 속도

        
        void OnTriggerEnter2D(Collider2D collifer)
        {
            if (collifer.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }

            void Update()
        {

            //float positionX = player.transform.position.x - transform.position.x;
            //float positionY = player.transform.position.y - transform.position.y;

            //positionX -= 0.001f;
            //positionY -= 0.0001f;

            //Vector3 direction = player.transform.position - transform.position;//타겟포지션 - 적포지션 값
            //direction.Normalize();
            //Vector2 vector = new Vector2(positionX, positionY);
            //transform.position -= direction * positionX * Time.deltaTime;
            //transform.position -= direction * positionY * Time.deltaTime;

            //transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);

            //원형

            //runningTime += Time.deltaTime * speed1;
            //radius -= runningspeed;            
            //float x = Mathf.Cos(positionX * Mathf.Deg2Rad) * radius;
            //float y = Mathf.Sin(positionY * Mathf.Deg2Rad) * radius;
            //transform.position = new Vector2(x, y);

            //Vector2 pos;
            //pos.x = Mathf.Cos(Time.time* 360 * Mathf.Deg2Rad);
            //pos.y = Mathf.Sin(Time.time* 360 * Mathf.Deg2Rad);
            //transform.position = pos;

            //deg += Time.deltaTime * objSpeed;
            //if (deg < 360)
            //{
            //    var rad = Mathf.Deg2Rad* (deg);
            //    var y = circle * Mathf.Sin(rad);
            //    var x = circle * Mathf.Cos(rad);
            //    player.transform.position = this.transform.position + new Vector3(x, y) ;
            //    player.transform.rotation = Quaternion.Euler(0, 0, deg * -1);
            //}
            //else
            //{
            //    deg = 0;
            //}

            
            
            



        }
    }
}
