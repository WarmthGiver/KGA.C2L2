/* 보스 움직임
 * 작성자 : 최현민
 * 플레이어에게 빙글빙글 회전하면서 움직임
 * 
*/

using UnityEngine;
using CC;


namespace CHM
{
    public class BossEnemyControl : Enemy
    {
        [SerializeField]
        private float prefabSpeed;//프리팹 생성 속도
        [SerializeField]
        public float Rspeed;//반지름 줄어드는 속도
        [SerializeField]
        float bossSpeed;//보스 이동속도
        [SerializeField]
        private float R ;//반지름        
        
        private float coolTime;//쿨타임
        private float speed;//증가하는 수 담을 변수

        private void Start()
        {
            R = 6f;

        }

        void Update()
        {
            if (R >= 4.5f)
            {
                R = R - Time.deltaTime * Rspeed;//반지름이 스피드 만큼 줄어듬
            }
            //NormalBulletHoming(target, start, 3, 3, 5, 1);
            speed += Time.deltaTime * bossSpeed;//보스 본체 이동속도

            float x = R * Mathf.Cos(speed);//원의 반지름 *  Mathf.Cos (증가식)
            float y = R * Mathf.Sin(speed);
            transform.position = new Vector2(x, y);

            //타겟(플레이어)을 바라보는식
            Vector2 dir = transform.position;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

            coolTime += Time.deltaTime;

            if (coolTime > prefabSpeed)
            {
                coolTime = 0;
            }
        }
       

        //void NormalBulletHoming(GameObject target, GameObject start, float f_xs, float f_ys, float f_ms, float f_a)
        //{
        //    Vector3 targetPos;
        //    Vector3 startPos;
        //
        //    targetPos = target.transform.position;
        //    float targetX = targetPos.x;
        //    float targetY = targetPos.y;
        //
        //    startPos = start.transform.position;
        //    startPos.x = (startPos.x - targetX) / Mathf.Pow((startPos.x - targetX) * (startPos.x - targetX) + (startPos.y - targetY) * (startPos.y - targetY), 0.5f) * f_a;
        //    startPos.y = (startPos.y - targetY) / Mathf.Pow((startPos.x - targetX) * (startPos.x - targetX) + (startPos.y - targetY) * (startPos.y - targetY), 0.5f) * f_a;
        //
        //    bulletXspeed = f_xs - targetPos.x;
        //    bulletYspeed = f_ys - targetPos.y;
        //
        //    MorethanMaxSpeed();
        //}
        //void MorethanMaxSpeed()
        //{
        //    float bulletSpeed = Mathf.Pow(bulletXspeed * bulletXspeed + bulletYspeed * bulletYspeed, 0.5f);
        //    if (bulletSpeed > bulletMaxSpeed)
        //    {
        //        bulletXspeed = bulletXspeed / bulletSpeed * bulletMaxSpeed;
        //        bulletYspeed = bulletYspeed / bulletSpeed * bulletMaxSpeed;
        //    }
        //}
    }
}
