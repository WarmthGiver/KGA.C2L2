/*
 * �ۼ���: ������
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: �����ϴ� �� �����ϴ� ������Ʈ
 * �ѹ��� ���� ��ü ����� �ϴ� �޼��常�� �ѹ��� ����� ����
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace CHM
{
    public class StraightEnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;//�ϴ� ��ǥ�� ������
        [SerializeField]
        private GameObject enemyPrefab;//�� ������
        [SerializeField]
        public bool isRight = true;//�ݴ�� ������
        [SerializeField]
        private float spawnerspeed;//���ۺ��� ���� �ӵ�
        [SerializeField]
        private float prefabSpeed;//������ ���� �ӵ�
        [SerializeField]
        private float coolTime;//��Ÿ��

        void Start()
        {


        }


        void Update()
        {
            coolTime += Time.deltaTime;

            if (coolTime > prefabSpeed)
            {

                //Instantiate(enemyPrefab, transform.position, transform.rotation);
                //������ �ֶ� �����ϴ� �ֶ� �Ȱ��� ��ġ�� ����
                squadEnemy();

                coolTime = 0;
            }
            Rotating();
            
        }
        void Rotating()
        {
            if (isRight == true)
            {
                transform.RotateAround(player.transform.position, Vector3.forward, spawnerspeed * Time.deltaTime);

            }
            //Vector3.back ������ �ݴ�������� ��
            else
            {
                transform.RotateAround(player.transform.position, Vector3.back, spawnerspeed * Time.deltaTime);

            }
        }
        void squadEnemy()//
        {
            Vector3 vector = new Vector3(transform.position.x, transform.position.y);
            Vector3 vector1 = new Vector3(vector.x -1,vector.y+1);
            Vector3 vector2 = new Vector3(vector.x + 1, vector.y-1);

            Instantiate(enemyPrefab, vector, transform.rotation);
            Instantiate(enemyPrefab, vector1, transform.rotation);
            Instantiate(enemyPrefab, vector2, transform.rotation);

        }
        
    }
}