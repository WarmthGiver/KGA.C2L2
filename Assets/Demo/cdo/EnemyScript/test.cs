using System;
using System.Collections;
using System.Collections.Generic;
using CHM;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace KGA
{
    public class test : MonoBehaviour
    {
        //[SerializeField] private Enemy parentScript;

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.tag == "Bullet")
        //    {
        //        parentScript.hp;
        //        Destroy(gameObject);
        //    }
        //    //a.transform.parent.gameObject.SetActive(false);


        //}



        private void Update()
        {
            rCreateCluster();

        }

        private Vector3 center;
        private UnityEngine.Transform center1;
        private void Start()
        {
            center = Vector3.zero;
            
        }

        [SerializeField] private float EnemyPosition = 3;
        //반지름 간격(위치)으로 적 생성
        private void rCreateCluster()
        {
            EnemyPosition -= Time.deltaTime;
            
            float x = 5 * Mathf.Cos(EnemyPosition);
            float y = 5 * Mathf.Sin(EnemyPosition);
            transform.position = transform.parent.position +new Vector3(x,y);
        

            //var dd = transform.position - center;
            ////dd.z += 90;
            ////transform.rotation = Quaternion.LookRotation(Vector3.forward    ,dd );


            //var angde = sds(Vector2.zero, dd);
            //transform.rotation = Quaternion.Euler(0,0,angde);   



        }
        float sds(Vector2 start, Vector2 end)
        {
            Vector2 ver = end - start;
            return Mathf.Atan2(ver.y,ver.x)*Mathf.Rad2Deg-90;

        }


        //transform.RotateAround(Vector2.zero, Vector3.forward, angleSpeed * Time.deltaTime);

        ////카메라 내 좌표값을 사용할수 있게함
        //Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, mouse);
        //transform.position = mouse;


    }

}
