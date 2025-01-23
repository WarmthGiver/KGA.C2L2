using ArmadaInvencible.CDO;

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.ObjectPooling;

namespace ArmadaInvencible.CHM
{
    public class RandomSpawner : MonoBehaviour
    {
        [SerializeField]

        private SerializableDictionary<string, GameObjectPool<Enemy>> dictinary;      
        
        [SerializeField]

        //������ ��
        private float circleR;

        [SerializeField]

        //�帣�½ð�
        private float coolTimeup;

        [SerializeField]

        private float time;

        [SerializeField]

        //�帣�½ð�
        private float coolTimeCk;

        [SerializeField]

        //��Ÿ��
        private float coolTime;

        //���� ���� ����
        private bool isBossSpawn = false;

        private int counteBossSpawn = 0;

        public float CoolTime
        {
            get
            {
                return coolTime;
            }

            set
            {
                if (value < 0.5f)
                {
                    coolTime = 0.5f;
                }

                else
                {
                    coolTime = value;
                }
            }
        }

        private int circleRandom;

        //����
        private Vector3 targetPos = new Vector3(0, 0, 0);

        private void Update()
        {
            coolTimeup += Time.deltaTime;

            var angle = GetAngle(transform.position, targetPos);

            transform.rotation = Quaternion.Euler(0, 0, angle);

            Circle();

            if (coolTimeup>CoolTime)
            {
                circleRandom = Random.Range(0, 360);

                if (isBossSpawn == false)
                {
                    squadEnemy();
                }

                coolTimeup = 0;
            }

            coolTimeCk += Time.deltaTime;

            if (coolTimeCk > time)
            {
                CoolTime -= 1f;

                counteBossSpawn++;

                coolTimeCk = 0;
            }

            //���� ���� ����
            if (counteBossSpawn == 5)
            {
                isBossSpawn = true;
            }
        }

        private float GetAngle(Vector2 start, Vector2 end)
        {
            Vector2 ver2 = end - start;

            return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Rad2Deg - 90;

        }
        private void Circle()
        {
            //������ ��
            float x = circleR * Mathf.Cos(circleRandom);

            float y = circleR * Mathf.Sin(circleRandom);

            transform.position = new Vector3(x, y);
        }
        private void squadEnemy()
        {
            //Instantiate(dictinary, transform.position, transform.rotation);
            Enemy straightEnemy  = dictinary["StraightEnemy"].Generate();

            straightEnemy.transform.position = transform.position;

            straightEnemy.transform.rotation = transform.rotation;

            straightEnemy.gameObject.SetActive(true);
        }
    }
}