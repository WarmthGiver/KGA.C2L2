using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace KGA
{
    public class test : MonoBehaviour
    {
        [SerializeField] private SpiralEnemy parentScript;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                parentScript.spiralEnemyHp--;
                Destroy(gameObject);
            }
            //a.transform.parent.gameObject.SetActive(false);


        }

    }

}
