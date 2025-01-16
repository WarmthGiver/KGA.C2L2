using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CHM
{
    public class bulletScript : MonoBehaviour
    {
        Vector3 target = new Vector3(0,0,0);
        [SerializeField] private float bulletSpeed;        
        
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        void Update()
        {

            //Vector3 direction = targetplayer.transform.position - transform.position;//Ÿ�������� - �������� ��
            //direction.Normalize();
            //float xy= GetAngle(targetplayer.transform.position, direction);
            //
            

            Vector3 newPos = target - transform.position;//�������� ������ �Ÿ�            
                                                         //float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Deg2Rad;//���� �Ÿ��� ���̿� �غ��� �־� ��������
                                                         //������ ���ؼ�

            float rotZ = GetAngle(transform.position, target);
            newPos.Normalize();
            transform.position += newPos * bulletSpeed* Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            





        }
        float GetAngle(Vector2 start, Vector2 end)//�������� ������ ������ ����
        {
            Vector2 ver2 = end - start;

            Debug.Log(start);
            Debug.Log(end);

            //Vector2.Angle(start, end);


            return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Deg2Rad;
            
        }

    }
}