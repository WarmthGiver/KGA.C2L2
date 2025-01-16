/*
 * �ۼ���: ������
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �����ϴ� �� �����ϴ� ������Ʈ
 * �ѹ��� ���� ��ü ����� �ϴ� �޼��常�� �ѹ��� ����� ����
*/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace CHM
{

    public class StraightEnemySpawner : MonoBehaviour
    {
        [SerializeField]
        protected GameObject enemyPrefab;
        [SerializeField]
        private bool isRight = true;//�ݴ�� ������
        [SerializeField]
        private float spawnerspeed;//���ۺ��� ���� �ӵ�
        [SerializeField]
        private float prefabSpeed;//������ ���� �ӵ�
        [SerializeField]
        private float coolTime;//��Ÿ��        
        float speed=0;
        public GameObject dbj;
        
        
        private void Update()
        {
            coolTime += Time.deltaTime;
            var parentPos = transform.parent.position;//parent �� �θ��ִ°� �����ü� �ִ�
            //�θ� �ٶ󺸸� ���ۺ��� �����ϱ�
            //Vector3 pos = parentPos.normalized;
            float x = parentPos.x * Mathf.Cos(speed);//������ �� * ������ �ӵ�
            float y = parentPos.y * Mathf.Sin(speed);
            Vector3 newPos = new Vector3(x, y);
            transform.position = newPos;




            //�̰� ��ǥ ���͸� �ٶ󺸴� �ڵ�
            Vector2 targetPos = new Vector3(0, 0, 0);
            Vector2 spawnerPos = transform.position;
            var angle2 = GetAngle(spawnerPos, targetPos);
            
            transform.rotation = Quaternion.Euler(0, 0, angle2);

            
            if (coolTime > prefabSpeed)
            {

                squadEnemy();
                coolTime = 0;
            }
            
            //Rotating();
            
        }
        void Rotating()
        {
        
            if (isRight == true)
            {
        
               transform.RotateAround(dbj.transform.position, Vector3.forward, spawnerspeed * Time.deltaTime);
        
            }
            //Vector3.back ������ �ݴ�������� ��
            else
            {
                transform.RotateAround(dbj.transform.position, Vector3.back, spawnerspeed * Time.deltaTime);
        
            }
        }
        void squadEnemy()
        {

            Instantiate(enemyPrefab, transform.position, transform.rotation);
            
            //Vector3 vector = new Vector3(transform.position.x, transform.position.y);
            //Vector3 vector1 = new Vector3(vector.x -1,vector.y);
            ////Vector3 vector2 = new Vector3(vector.x + 1, vector.y);
            //
            //Instantiate(enemyPrefab, vector, transform.rotation);
            //Instantiate(enemyPrefab, vector1, transform.rotation);
            //Instantiate(enemyPrefab, vector2, transform.rotation);

        }
        float GetAngle(Vector2 start, Vector2 end)//�������� ������ ������ ����
        {
            Vector2 ver2 = end - start;
            return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Rad2Deg-90;
            //ó���ִ� ��ġ�� ���� �޶���
            //���� ������ ��׸� ������ �ٲ� -90�ؾ� ��ǥ�� ������
            //���̿� �غ����� �־ 
        }
    }
}