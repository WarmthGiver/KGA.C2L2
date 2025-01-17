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
        //[SerializeField]
        //private bool isRight = true;//�ݴ�� ������
        [SerializeField]
        private float spawnerspeed;//���ۺ��� ���� �ӵ�
        [SerializeField]
        private float prefabSpeed;//������ ���� �ӵ�
        [SerializeField]
        private float coolTime;//��Ÿ��
        [SerializeField]
        private int radius;
        float speed;
        
        private void Update()
        {
            coolTime += Time.deltaTime;
            speed += Time.deltaTime * spawnerspeed;


               LookTarget();
            
            if (coolTime > prefabSpeed)
            {
            
                squadEnemy();
                coolTime = 0;
            }
            
            //Rotating();
            
        }
        //void Rotating()
        //{
        //
        //    if (isRight == true)
        //    {
        //
        //       transform.RotateAround(dbj.transform.position, Vector3.forward, spawnerspeed * Time.deltaTime);
        //
        //    }
        //    //Vector3.back ������ �ݴ�������� ��
        //    else
        //    {
        //        transform.RotateAround(dbj.transform.position, Vector3.back, spawnerspeed * Time.deltaTime);
        //
        //    }
        //}
        void squadEnemy()
        {
            //get �Լ� ���ڰ���� �迭�� ���
            //PoolManager.instance.Get(Random.Range(0,10));

            Instantiate(enemyPrefab, transform.position, transform.rotation);

            //Vector3 vector = new Vector3(transform.position.x, transform.position.y);
            //Vector3 vector1 = new Vector3(vector.x -1,vector.y);
            ////Vector3 vector2 = new Vector3(vector.x + 1, vector.y);
            //
            //Instantiate(enemyPrefab, vector, transform.rotation);
            //Instantiate(enemyPrefab, vector1, transform.rotation);
            //Instantiate(enemyPrefab, vector2, transform.rotation);

        }
        void LookTarget()
        {

            var parentPos = transform.parent.position;//parent �� �θ��ִ°� �����ü� �ִ�
            Vector3 targetPos = parentPos;//��ǥ
            Vector2 spawnerPos = transform.position;      
            float x = radius * Mathf.Cos(speed);//������ �� * ������ �ӵ�
            float y = radius * Mathf.Sin(speed);
             
            //�̰��� ���� ���⼭ x�� ������ǥ?? ������ 0���� ������ �������̰�
            // �ű⼭ + �������� �ϴ� �������� ��ǥ�� �־������
            transform.position = new Vector3(x+targetPos.x, y+targetPos.y); 

            //��ǥ ���͸� �ٶ󺸴� �ڵ�
           
            var angle2 = GetAngle(spawnerPos, Vector2.zero);            
            transform.rotation = Quaternion.Euler(0, 0, angle2);
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