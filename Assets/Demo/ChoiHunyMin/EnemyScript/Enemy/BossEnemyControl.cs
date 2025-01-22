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
            gameObject.SetActive(false);
            //������ �Լ� ����
            Invoke("gameobjectSetActive", 10);
            R = 15f;
            
        }
        private void gameobjectSetActive()
        {
            gameObject.SetActive(true);
        }




        void Update()
        {
            
            if (R >= 4.5f)
            {
                R = R - Time.deltaTime * Rspeed;//�������� ���ǵ� ��ŭ �پ��
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
