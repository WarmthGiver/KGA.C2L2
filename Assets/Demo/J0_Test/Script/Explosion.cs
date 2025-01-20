using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    int time;

    private void Start()
    {
        time = 1;
        StartCoroutine(Remove());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    IEnumerator Remove()
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
