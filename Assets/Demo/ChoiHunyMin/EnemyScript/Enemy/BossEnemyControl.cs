/* ���� ������
 * �ۼ��� : ������
 * �÷��̾�� ���ۺ��� ȸ���ϸ鼭 ������
 * 
*/

using UnityEngine;
using CC;


namespace CHM
{
    public class BossEnemyControl : Enemy
    {
        [SerializeField]
        private float prefabSpeed;//������ ���� �ӵ�
        [SerializeField]
        public float Rspeed;//������ �پ��� �ӵ�
        [SerializeField]
        float bossSpeed;//���� �̵��ӵ�
        [SerializeField]
        private float R ;//������        
        
        private float coolTime;//��Ÿ��
        private float speed;//�����ϴ� �� ���� ����

        private void Start()
        {
            R = 6f;

        }

        void Update()
        {
            if (R >= 4.5f)
            {
                R = R - Time.deltaTime * Rspeed;//�������� ���ǵ� ��ŭ �پ��
            }
            //NormalBulletHoming(target, start, 3, 3, 5, 1);
            speed += Time.deltaTime * bossSpeed;//���� ��ü �̵��ӵ�

            float x = R * Mathf.Cos(speed);//���� ������ *  Mathf.Cos (������)
            float y = R * Mathf.Sin(speed);
            transform.position = new Vector2(x, y);

            //Ÿ��(�÷��̾�)�� �ٶ󺸴½�
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
