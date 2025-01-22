/* ���� ������
 * �ۼ��� : ������
 * �÷��̾�� ���ۺ��� ȸ���ϸ鼭 ������
 * 
*/

using CC;

using UnityEngine;

namespace CHM
{
    public class BossEnemyControl : Enemy
    {
        [SerializeField]

        //������ ���� �ӵ�
        private float prefabSpeed;

        [SerializeField]

        //������ �پ��� �ӵ�
        public float Rspeed;

        [SerializeField]

        //���� �̵��ӵ�
        float bossSpeed;

        [SerializeField]

        //������  
        private float R ;

        //��Ÿ��
        private float coolTime;

        //�����ϴ� �� ���� ����
        private float speed;

        private void Start()
        {
            gameObject.SetActive(false);

            //������ �Լ� ����
            Invoke("gameobjectSetActive", 10);

            R = 15f;
        }

        private void gameobjectSetActive()
        {
            gameObject.SetActive(true);
        }

        private void Update()
        {
            if (R >= 4.5f)
            {
                //�������� ���ǵ� ��ŭ �پ��
                R = R - Time.deltaTime * Rspeed;

                bossSpeed = 0.5f;
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
    }
}