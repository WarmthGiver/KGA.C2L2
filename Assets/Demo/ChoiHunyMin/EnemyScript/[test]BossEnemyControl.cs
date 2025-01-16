/*보스 움직임 테스트용
 * 
 * 
*/


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace CHM
{
    public class BossEnemyControl : Enemy
    {

        //public float radius = 4;
        //public float runningspeed = 1f;
        //float runningTime = 0;
        //float speed1=0.1f;
        //[SerializeField]
        //float circle;//원
        //[SerializeField]
        //float deg;//각도
        //[SerializeField]
        //float objSpeed;//원운동 속도

        //원 속도
        //[SerializeField] private float eulerEuler = 90f;

        //들어오는 간격 = 속도
        //[SerializeField] private float gap = 0.0005f;

        //거리
        //private float distance;

        float hypotenuse;//빗변
        //float height;//높이 
        //float width;//너비

        public float speed = 0.0001f;
        [SerializeField]
        float bossSpeed = 0;
        float R = 5;//반지름

        [SerializeField]
        private GameObject bullet;
        [SerializeField]
        private float prefabSpeed;//프리팹 생성 속도
        [SerializeField]
        private float coolTime;//쿨타임
        //[Header("Cricle")]
        //[SerializeField]
        //int i = 0;
        //[SerializeField]
        //float radius;//속도

        private void Start()
        {
            
            //distance = Vector2.Distance(playerObj.transform.position, transform.position);
            //height = playerObj.transform.position.y - transform.position.y;// = -2
            //width = playerObj.transform.position.x - transform.position.x;// = -6
            //transform.position = new Vector2(Mathf.Cos(width),Mathf.Sin(height));
        }
        //private void MoveCircle(float _radius)
        //{
        //    
        //   // var rad_Angle = DegreesToRadians(i);
        //    
        //    Vector2 direction = new Vector2(Mathf.Cos(height), Mathf.Sin(height));
        //    direction *= _radius;
        //    transform.Translate(direction * Time.fixedDeltaTime);
        //    //i++;
        //    //i = i > 360 ? 0 : i;
        //}
        //private float DegreesToRadians(float _angle)
        //{
        //    return _angle * Mathf.Deg2Rad;
        //}
        //private void FixedUpdate()
        //{
        //    MoveCircle(radius);
        //}
        void Update()
        {
            
            R = R - speed;//반지름이 스피드 만큼 줄어듬
            bossSpeed += 0.002f;//Time.deltaTime;//보스 본체 이동속도
            
            float x = R * Mathf.Cos(bossSpeed);//원의 반지름 *  Mathf.Cos (증가식)
            float y = R * Mathf.Sin(bossSpeed);
            transform.position = new Vector2(x, y);
            Vector2 dir = transform.position;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg);

            coolTime += Time.deltaTime;

            if (coolTime > prefabSpeed)
            {

                Instantiate(bullet, transform.position, bullet.transform.rotation);

                coolTime = 0;
            }

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

            //동오코드
            //transform.RotateAround(playerObj.transform.position, Vector3.forward, eulerEuler * Time.deltaTime);
            //
            //var direction = (transform.position - playerObj.transform.position).normalized;
            //distance -= gap;
            //transform.position = playerObj.transform.position + direction * distance;






        }
    }
}
